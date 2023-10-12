using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Common;
//using System.Windows.Forms;
using System.Collections;

namespace KHK_portfolio
{
    public class SQLDBClass : IDBFunction
    {
        private string conString = string.Empty;

        public string ConString
        {
            get { return conString; }
        }

        private SqlConnection sqlCnn = null; // Sql 연결
        private DataSet sqlDS = new DataSet(); // sql 값 가져오는 
        private DatabaseInfo dbInfo;
        private SqlParameter[] sqlParams = null; // sql 배열

        //서버 접속정보 입력
        public const string DBUserID = "sa";
        public const string DBPassword = "hm@sys8822";
        public const string DBNM = "PortfolioDB";

        public SQLDBClass(DatabaseInfo agDBInfo)
        {
            this.dbInfo = agDBInfo;

            if (string.IsNullOrEmpty(dbInfo.DBType))
                throw new Exception("DB Connection String is missing.");

            conString = "UID=" + DBUserID + ";Password=" + DBPassword + ";initial catalog=" + DBNM + ";Data Source=" + UserInfo.g_DBIP + ";Connect Timeout=30;";
        }

        public SQLDBClass(string sIP)
        {
            conString = "UID=" + DBUserID + ";Password=" + DBPassword + ";initial catalog=" + DBNM + ";Data Source=" + sIP + ";Connect Timeout=30";
        }



        //sql command 에 계속 더해주는 함수 
        private void AddParameters(SqlCommand command)
        {
            if(command == null)
            {
                throw new Exception("null Command");
            }
            else
            {
                if(this.sqlParams != null)
                {
                    for (int i = 0; i < this.sqlParams.Length; i++)
                    {
                        command.Parameters.Add(this.sqlParams[i]);
                    }
                }
            }
        }



        // DB 타입 가져오는 함수
        private SqlDbType GetMSSQLDbType(string dataType)
        {
            foreach (SqlDbType sdt in Enum.GetValues(typeof(SqlDbType)))
            {
                if(sdt.ToString().ToUpper() == dataType.ToUpper())
                {
                    return sdt;
                }
            }
            return SqlDbType.NVarChar;
        }


        
        //이거는 매개변수로 받아오는거에 @ 붙여주는 프로그램인거같은데 
        private int GetParamIndexFromName(string paramName)
        {
            if(this.sqlParams == null)
            {
                throw new Exception("parameter list is null.");
            }
            else
            {
                for (int i = 0; i < this.sqlParams.Length; i++)
                {
                    if(this.sqlParams[i].ParameterName == (paramName.Substring(0,1) == "@" ? paramName : "@"+paramName))
                    {
                        return i;
                    }

                }
                throw new Exception("Can not find parameter name (" + paramName + ")");
            }
        }


        public string GetUserID()
        {
            string[] tmpCnn = conString.Split(new char[] { ':' });

            for (int inx = 0; inx < tmpCnn.Length; inx++)
            {
                string title = tmpCnn[inx].Substring(0, tmpCnn[inx].IndexOf('='));
                if(title.Trim().ToUpper() == "USER ID" || title.Trim().ToUpper() == "UID")
                {
                    string[] tmpInfo = tmpCnn[inx].Split(new char[] { '=' });

                    if(tmpInfo.Length == 2)
                    {
                        return tmpInfo[1];
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            return string.Empty;
        }

        //DB 연결하고 에러생기면 출력까지 하는 함수.
        public bool DBOpen()
        {
            StringBuilder errorMessages = new StringBuilder();

            try
            {
                sqlCnn = new SqlConnection(conString);
                //접속정보로 SQL DB 접근
                sqlCnn.Open();
                //open
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Proceduer: " + ex.Errors[i].Procedure + "\n");
                }

                throw new Exception("Error : " + errorMessages.ToString());
            }
            return true;
        }

        public bool DBClose()
        {
            StringBuilder errorMessages = new StringBuilder();

            try
            {
                sqlCnn.Close();
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }

                throw new Exception("Error : " + errorMessages.ToString());
            }

            return true;
        }

        //SQL 에 쿼리문 전달해서 리턴 받은 값을 SET 해주는 함수
        public DataSet GetDataSet(CommandType commandType ,  string commandText)
        {
            StringBuilder errorMessages = new StringBuilder();

            if (DBOpen())
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    using (SqlCommand command = new SqlCommand(commandText, sqlCnn))
                    {
                        command.CommandType = commandType;
                        command.CommandTimeout = dbInfo.DBCommandTimeOut;

                        this.AddParameters(command);

                        adapter.SelectCommand = command;

                        sqlDS.Tables.Clear();

                        adapter.Fill(sqlDS, commandText);

                        if (sqlDS == null) throw new Exception("DataSet in null");

                        if(sqlDS.Tables.Count > 0)
                        {
                            return sqlDS;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }
                    throw new Exception("Error : " + errorMessages.ToString());
                }
                finally
                {
                    if(sqlCnn.State == ConnectionState.Open)
                    {
                        sqlCnn.Close();
                    }
                }
            }
            else
            {
                return null;
            }
        }

        // 데이터를 테이블에 set 해주는 함수
        public DataTable GetDataTable(CommandType commandType , string commandText)
        {
            StringBuilder errorMessages = new StringBuilder();

            if (DBOpen())
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    using (SqlCommand comaand = new SqlCommand (commandText , sqlCnn))
                    {
                        comaand.CommandType = commandType;
                        comaand.CommandTimeout = dbInfo.DBCommandTimeOut;

                        this.AddParameters(comaand);

                        adapter.SelectCommand = comaand;

                        sqlDS.Tables.Clear();

                        adapter.Fill(sqlDS, commandText);

                        if (sqlDS == null) throw new Exception("Datatable is null.");

                        if (sqlDS.Tables.Count > 0)
                            return sqlDS.Tables[0];
                        else
                        {
                            return null;
                        }
                    }
                    
                }
                catch (SqlException ex)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }

                    throw new Exception("Error : " + errorMessages.ToString());
                }
                finally
                {
                    if (sqlCnn.State == ConnectionState.Open)
                    {
                        sqlCnn.Close();
                    }
                }
            }
            else
            {
                return null;
            }
        }

        // Sql 쿼리 실행해서 영향을 받는 행의 갯수를 리턴 
        public int ProcessDataSave(CommandType commandType , string commandText)
        {
            StringBuilder errorMessages = new StringBuilder();

            if (DBOpen())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(commandText  , sqlCnn))
                    {
                        command.CommandType = commandType;

                        this.AddParameters(command);

                        command.CommandTimeout = dbInfo.DBCommandTimeOut;
                        return command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }
                    throw new Exception("Error : " + errorMessages.ToString());
                }
                finally
                {
                    if(sqlCnn.State == ConnectionState.Open)
                    {
                        sqlCnn.Close();
                    }
                }
            }
            else
            {
                return -1;
            }
        }

        private SqlParameter CreateOaraneter(string name , SqlDbType dataType  , object parameterValue)
        {
            return this.CreateParameter("@" + name, dataType, parameterValue, -1, ParameterDirection.Input);
        }

        private SqlParameter CreateParameter(string name, SqlDbType dataType, object parameterValue, int size)
        {
            return this.CreateParameter("@" + name, dataType, parameterValue, size, ParameterDirection.Input);
        }

        private SqlParameter CreateParameter(string name , SqlDbType dataType , object parameterValue , int size , ParameterDirection direction)
        {
            SqlParameter parameter;

            parameter = new SqlParameter((name.Substring(0, 1) == "@" ? name : "@" + name), dataType);

            parameter.Value = parameterValue;
            parameter.Direction = direction;

            if(size >= 0)
            {
                parameter.Size = size;
            }
            return parameter;
        }


        public void CreateParameter(ArrayList param, DataTable paramDBList)
        {
            if (paramDBList == null || paramDBList.Rows.Count == 0)
            {
                throw new Exception("Can not find the procedure in the Database.");
            }

            int paramCount = paramDBList.Rows.Count;

            try
            {
                this.sqlParams = new SqlParameter[paramCount];
                for (int inx = 0; inx < paramCount; inx++)
                {
                    string parameterName = paramDBList.Rows[inx]["PARAMETER_NAME"].ToString().Replace("@", "");
                    SqlDbType dbType = GetMSSQLDbType(paramDBList.Rows[inx]["DATA_TYPE"].ToString());
                    string parameterMode = paramDBList.Rows[inx]["PARAMETER_MODE"].ToString();
                    int dataLength = Convert.ToInt32(paramDBList.Rows[inx]["DATA_LENGTH"].ToString());

                    for (int index = 0; index < param.Count; index++)
                    {
                        ParamList pl = (ParamList)param[index];

                        if (pl.KeyName == parameterName)
                        {
                            this.sqlParams[inx] = this.CreateParameter(pl.KeyName, dbType, pl.KeyValue, pl.DataLength
                                , (parameterMode == "INPUT" ? ParameterDirection.Input : ParameterDirection.Output));

                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }



        //SQL 파라메터에 키 이름 , DBType , KeyValue , DataLength
        public void CreateParameter(ArrayList param)
        {
            try
            {
                this.sqlParams = new SqlParameter[param.Count];
                for (int index = 0; index < param.Count; index++)
                {
                    ParamListSQL pl = (ParamListSQL)param[index];

                    this.sqlParams[index] = this.CreateParameter(pl.KeyName, pl.DbTypeSQL, pl.KeyValue, pl.DataLength
                        , ParameterDirection.Input);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }

        public string GetParameterString(string commandText)
        {
            SqlParameter tmpParam;
            string tranStart = "BEGIN TRAN";
            string tranEnd = "--COMMIT TRAN\r\nROLLBACK TRAN";
            string paramHeader = "EXEC " + commandText + " ";
            string paramDetail = string.Empty;
            string paramDeclare = "DECLARE ";
            string paramSelect = "SELECT ";

            if (this.sqlParams != null)
            {
                for (int i = 0; i < this.sqlParams.Length; i++)
                {
                    tmpParam = this.sqlParams[i];

                    if (tmpParam.Direction == ParameterDirection.Input)
                    {
                        if (tmpParam.Value == null || string.IsNullOrEmpty(tmpParam.Value.ToString()))
                        {
                            if (tmpParam.SqlDbType == SqlDbType.NVarChar || tmpParam.SqlDbType == SqlDbType.NChar)
                                paramDetail += tmpParam.ParameterName + " = N'',";
                            else
                                paramDetail += tmpParam.ParameterName + " = '',";
                        }
                        else
                        {
                            if (tmpParam.SqlDbType == SqlDbType.NVarChar || tmpParam.SqlDbType == SqlDbType.NChar)
                                paramDetail += tmpParam.ParameterName + " = N'" + tmpParam.Value.ToString() + "',";
                            else
                                paramDetail += tmpParam.ParameterName + " = '" + tmpParam.Value.ToString() + "',";
                        }

                        paramDetail += "\r\n\t";
                    }
                    else if (tmpParam.Direction == ParameterDirection.Output)
                    {
                        paramDetail += tmpParam.ParameterName + " = " + tmpParam.ParameterName + " OUTPUT,";

                        if (tmpParam.SqlDbType == SqlDbType.NVarChar || tmpParam.SqlDbType == SqlDbType.NChar)
                        {
                            paramDeclare += tmpParam.ParameterName + " " + tmpParam.SqlDbType.ToString() + " (" + tmpParam.Size.ToString() + "), ";
                        }
                        else
                        {
                            paramDeclare += tmpParam.ParameterName + " " + tmpParam.SqlDbType.ToString() + ", ";
                        }

                        paramSelect += tmpParam.ParameterName + " AS " + tmpParam.ParameterName.Replace("@", "") + ", ";
                        paramSelect += "\r\n\t";
                    }
                    else
                    {
                        throw new Exception("ParameterDirection error occurs.");
                    }
                }
            }

            paramDeclare = paramDeclare.Trim().Substring(0, paramDeclare.Trim().Length - 1);
            paramSelect = paramSelect.Trim().Substring(0, paramSelect.Trim().Length - 1);

            return tranStart + "\r\n"
                + paramDeclare.ToUpper() + "\r\n"
                + paramHeader + paramDetail.Substring(0, paramDetail.Length - 1) + "\r\n"
                + paramSelect + "\r\n"
                + tranEnd;
        }

        public string GetRetParamValue(string paramName)
        {
            return this.sqlParams[GetParamIndexFromName(paramName)].Value.ToString();
        }

      
    }
}
