using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using HMAppReg;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Oracle.DataAccess.Client;
//using Oracle.DataAccess.Types;
//using System.Data.OracleClient;
using System.Windows.Forms;

namespace KHK_portfolio
{
    public class DBClass
    {
        public IDBFunction GetDBClass()
        {
            DatabaseInfo dbinfo = new DatabaseInfo();

            try
            {
                //AppRegSetInfo.ManageSysRegInfo(WorkType.GET);


                dbinfo.DBCommandTimeOut = 30; //Convert.ToInt16(AppRegSetInfo.DB_TIMEOUT);
                dbinfo.DBType = "MSSQL2008"; //DBType;         // AppRegSetInfo.DB_TYPE;
                dbinfo.DBConnName = ""; // DBConnName; // AppRegSetInfo.DB_CONN;

                if (string.IsNullOrEmpty(dbinfo.DBType))
                    throw new Exception("Do not set DB Type information(Config).");

                switch (dbinfo.DBType)
                {
                    case "MSSQL2008":   //MSSQL
                        return new SQLDBClass(dbinfo);
                    case "ORACLE11G":   //Oracle
                        //return new OraDBClass(dbinfo);
                        throw new Exception("Do not support for Oracle Database.");
                    default:
                        throw new Exception("Do not set DB Type information(Config).");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IDBFunction GetDBClass(string DBType, string DBConnName)
        {
            DatabaseInfo dbinfo = new DatabaseInfo();

            try
            {
                //AppRegSetInfo.ManageSysRegInfo(WorkType.GET);

                dbinfo.DBCommandTimeOut = 30; //Convert.ToInt16(AppRegSetInfo.DB_TIMEOUT);
                dbinfo.DBType = "MSSQL2008"; //DBType;         // AppRegSetInfo.DB_TYPE;
                dbinfo.DBConnName = ""; // DBConnName; // AppRegSetInfo.DB_CONN;

                if (string.IsNullOrEmpty(dbinfo.DBType))
                    throw new Exception("Do not set DB Type information(Config).");

                switch (dbinfo.DBType)
                {
                    case "MSSQL2008":   //MSSQL
                        return new SQLDBClass(dbinfo);
                    case "ORACLE11G":   //Oracle
                        //return new OraDBClass(dbinfo);
                        throw new Exception("Do not support for Oracle Database.");
                    default:
                        throw new Exception("Do not set DB Type information(Config).");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public struct ParamList
    {
        private string keyName;
        private object keyValue;
        private int dataLength;

        public string KeyName
        {
            get { return keyName; }
        }
        public object KeyValue
        {
            get { return keyValue; }
        }
        public int DataLength
        {
            get { return dataLength; }
        }

        public ParamList(string keyName, object keyValue, int dataLength)
        {
            this.keyName = keyName;
            this.keyValue = keyValue;
            this.dataLength = dataLength;
        }
    }

    public struct ParamListSQL
    {
        private string keyName;
        private object keyValue;
        private int dataLength;
        private SqlDbType dbTypeSQL;

        public SqlDbType DbTypeSQL
        {
            get { return dbTypeSQL; }
        }

        public string KeyName
        {
            get { return keyName; }
        }
        public object KeyValue
        {
            get { return keyValue; }
        }
        public int DataLength
        {
            get { return dataLength; }
        }

        public ParamListSQL(string keyName, object keyValue, int dataLength, SqlDbType dbTypeSQL)
        {
            this.keyName = keyName;
            this.keyValue = keyValue;
            this.dataLength = dataLength;
            this.dbTypeSQL = dbTypeSQL;
        }
    }

    public struct ParamListOra
    {
        //private string keyName;
        //private object keyValue;
        //private int dataLength;
        //private OracleType dbTypeOra;

        //public OracleType DbTypeOra
        //{
        //    get { return dbTypeOra; }
        //}

        //public string KeyName
        //{
        //    get { return keyName; }
        //}
        //public object KeyValue
        //{
        //    get { return keyValue; }
        //}
        //public int DataLength
        //{
        //    get { return dataLength; }
        //}

        ////////public ParamListOra(string keyName, object keyValue, int dataLength, OracleType dbTypeOra)
        ////////{
        ////////    this.keyName = keyName;
        ////////    this.keyValue = keyValue;
        ////////    this.dataLength = dataLength;
        ////////    this.dbTypeOra = dbTypeOra;
        ////////}
    }

    public class DBHandler
    {
        DBClass dbcla;
        IDBFunction hmdb;

        //Procedure Name
        private string procedureName;
        CommandType commType = CommandType.Text;
        private string dbType = "MSSQL2008";
        private string userID = string.Empty;

        public DBHandler()
        {
            this.dbcla = new DBClass();
            this.hmdb = dbcla.GetDBClass();

            userID = hmdb.GetUserID();
        }

        public string ProcedureName
        {
            set { this.procedureName = value; }
        }

        public string GetParamString()
        {
            //Clipboard.SetText(hmdb.GetParameterString(this.procedureName));
            return hmdb.GetParameterString(this.procedureName);
        }

        public string GetRetParamValue(string paramName)
        {
            return hmdb.GetRetParamValue(paramName);
        }

        public void CreateParam(CommandType ct, ArrayList param)
        {
            if (param == null || param.Count == 0)
            {
                throw new Exception("Parameter list does not set.");
            }

            commType = ct;

            if (this.commType == CommandType.StoredProcedure)
            {
                if (!param[0].GetType().Equals(typeof(ParamList)))
                {
                    throw new Exception("Parameter type is incorrect. Use 'ParamList' structure.");
                }

                CreateParamSP(param);
            }
            else
            {
                if (!param[0].GetType().Equals(typeof(ParamListSQL)) && !param[0].GetType().Equals(typeof(ParamListOra)))
                {
                    throw new Exception("Parameter type is incorrect. Use 'ParamList' structure.");
                }

                CreateParamQry(param);
            }
        }

        /// <summary>
        /// Create default parameter when the parameter is missing.
        /// </summary>
        /// <param name="param"></param>
        private void CreateParamSP(ArrayList param) // 이 코드를 분석해보자~~
        {
            DataTable paramDBList = new DataTable();

            if (this.dbType == "MSSQL2008")
                paramDBList = GetParameterListSQL2008(this.procedureName);
            //////////else if (this.dbType == "ORACLE11G")
            //////////    paramDBList = GetParameterListORACLE11G(this.procedureName);
            else
                throw new Exception("The database is not supported.");

            if (paramDBList == null || paramDBList.Rows.Count == 0)
            {
                throw new Exception("Can not retrieve procedure information.");
            }

            int paramCount = paramDBList.Rows.Count;

            try
            {
                bool findParam = false;

                for (int inx = 0; inx < paramCount; inx++)
                {
                    string parameterName = paramDBList.Rows[inx]["PARAMETER_NAME"].ToString().Replace("@", "");
                    string dataType = paramDBList.Rows[inx]["DATA_TYPE"].ToString();
                    string parameterMode = paramDBList.Rows[inx]["PARAMETER_MODE"].ToString();
                    int dataLength = Convert.ToInt32(paramDBList.Rows[inx]["DATA_LENGTH"].ToString());

                    for (int index = 0; index < param.Count; index++)
                    {
                        ParamList pl = (ParamList)param[index];

                        if (pl.KeyName == parameterName)
                        {
                            findParam = true;
                            break;
                        }
                    }

                    if (!findParam) //못찾았으면 
                    {
                        if (parameterName == "IN_ENTP_CODE")
                            param.Add(new ParamList("IN_ENTP_CODE", "TEST", dataLength));
                        //else if (parameterName == "IN_MSG_LANG")
                        //    param.Add(new ParamList("IN_MSG_LANG", AppRegSetInfo.LANGUAGE, dataLength));
                        else if (parameterName == "IN_USER_ID")
                            param.Add(new ParamList("IN_USER_ID", "test", dataLength));
                        else if (parameterName == "RET_CODE")
                            param.Add(new ParamList("RET_CODE", 0, 4));
                        else if (parameterName == "RET_MSG")
                            param.Add(new ParamList("RET_MSG", "", 255));
                        //else if (parameterName == "RET_CURSOR")
                        //    param.Add(new ParamList("RET_CURSOR", "", -1));
                        else
                        {
                            throw new Exception("Do not set Parammeter value ( " + parameterName + ") ");
                            //param.Add(new ParamList(parameterName, "", dataLength));
                        }
                    }

                    findParam = false;
                }

                hmdb.CreateParameter(param, paramDBList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }

        private void CreateParamQry(ArrayList param)
        {
            try
            {
                hmdb.CreateParameter(param);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }

        //////////private DataTable GetParameterListORACLE11G(string procedureName)
        //////////{
        //////////    DataTable hmDT = null;

        //////////    try
        //////////    {
        //////////        DBClass tmpDbcla = new DBClass();
        //////////        IDBFunction tmpHmdb = tmpDbcla.GetDBClass();

        //////////        string queryText = "";
        //////////        queryText += "SELECT IN_OUT AS PARAMETER_MODE " + "\r\n";
        //////////        queryText += "    ,ARGUMENT_NAME AS PARAMETER_NAME " + "\r\n";
        //////////        queryText += "    ,DATA_TYPE " + "\r\n";
        //////////        queryText += "    ,-1 AS DATA_LENGTH " + "\r\n";
        //////////        queryText += "FROM ALL_ARGUMENTS " + "\r\n";
        //////////        queryText += "WHERE OBJECT_ID = (SELECT OBJECT_ID FROM ALL_OBJECTS  " + "\r\n";
        //////////        //queryText += "                   WHERE OWNER = '" + txtUserID.Text.Trim() + "' " + "\r\n";
        //////////        //queryText += "                   AND OBJECT_NAME ='" + procedureName + "' " + "\r\n";
        //////////        queryText += "                   WHERE OWNER = :IN_OWNER " + "\r\n";
        //////////        queryText += "                   AND OBJECT_NAME = :IN_PROCEDURE_NAME " + "\r\n";
        //////////        queryText += "                   AND OBJECT_TYPE ='PROCEDURE') " + "\r\n";
        //////////        queryText += "ORDER BY OBJECT_NAME, OVERLOAD, SEQUENCE " + "\r\n";

        //////////        ArrayList param = new ArrayList();

        //////////        param.Add(new ParamListOra("IN_OWNER", userID, 20, OracleType.NVarChar));
        //////////        param.Add(new ParamListOra("IN_PROCEDURE_NAME", procedureName, 50, OracleType.NVarChar));

        //////////        //파라미터 정보를 생성한다.
        //////////        tmpHmdb.CreateParameter(param);

        //////////        hmDT = tmpHmdb.GetDataTable(CommandType.Text, queryText);

        //////////        return hmDT;
        //////////    }
        //////////    catch (Exception ex)
        //////////    {
        //////////        throw new Exception(ex.Message);
        //////////    }
        //////////    finally
        //////////    {
        //////////    }
        //////////}


        /// <summary>
        /// 수정일자 : 2017-08-07
        /// 수 정 자 : 이동윤
        /// 수정내용 :  stringBuilder사용해서 변경함
        /// </summary>
        /// <param name="procedureName"></param>
        /// <returns></returns>
        private DataTable GetParameterListSQL2008(string procedureName)
        {
            DataTable hmDT = new DataTable();

            try
            {
                DBClass tmpDbcla = new DBClass();
                IDBFunction tmpHmdb = tmpDbcla.GetDBClass();

                //string queryText = "";
                //queryText += "SELECT CASE WHEN B.IS_OUTPUT = 1 THEN 'OUTPUT' ELSE 'INPUT' END AS PARAMETER_MODE " + "\r\n";
                //queryText += "	,B.NAME AS PARAMETER_NAME " + "\r\n";
                //queryText += "	,UPPER(C.NAME) AS DATA_TYPE	" + "\r\n";
                //queryText += "	,CASE WHEN UPPER(C.NAME) IN ('NVARCHAR','NCHAR') THEN B.MAX_LENGTH / 2 ELSE B.MAX_LENGTH END AS DATA_LENGTH " + "\r\n";
                //queryText += "FROM SYS.PROCEDURES A " + "\r\n";
                //queryText += "	INNER JOIN SYS.PARAMETERS B " + "\r\n";
                //queryText += "		ON (A.OBJECT_ID = B.OBJECT_ID) " + "\r\n";
                //queryText += "	INNER JOIN SYS.TYPES C " + "\r\n";
                //queryText += "		ON (B.SYSTEM_TYPE_ID = C.SYSTEM_TYPE_ID AND B.USER_TYPE_ID = C.USER_TYPE_ID) " + "\r\n";
                //queryText += "WHERE A.NAME = @IN_PROCEDURE_NAME " + "\r\n";
                //queryText += "ORDER BY B.PARAMETER_ID " + "\r\n";

                StringBuilder SB = new StringBuilder();
                SB.Append("SELECT CASE WHEN B.IS_OUTPUT = 1 THEN 'OUTPUT' ELSE 'INPUT' END AS PARAMETER_MODE " + "\r\n");
                SB.Append("	,B.NAME AS PARAMETER_NAME " + "\r\n");
                SB.Append("	,UPPER(C.NAME) AS DATA_TYPE	" + "\r\n");
                SB.Append("	,CASE WHEN UPPER(C.NAME) IN ('NVARCHAR','NCHAR') THEN B.MAX_LENGTH / 2 ELSE B.MAX_LENGTH END AS DATA_LENGTH " + "\r\n");
                SB.Append("FROM SYS.PROCEDURES A " + "\r\n");
                SB.Append("	INNER JOIN SYS.PARAMETERS B " + "\r\n");
                SB.Append("		ON (A.OBJECT_ID = B.OBJECT_ID) " + "\r\n");
                SB.Append("	INNER JOIN SYS.TYPES C " + "\r\n");
                SB.Append("		ON (B.SYSTEM_TYPE_ID = C.SYSTEM_TYPE_ID AND B.USER_TYPE_ID = C.USER_TYPE_ID) " + "\r\n");
                SB.Append("WHERE A.NAME = @IN_PROCEDURE_NAME " + "\r\n");
                SB.Append("ORDER BY B.PARAMETER_ID " + "\r\n");

                ArrayList param = new ArrayList();

                param.Add(new ParamListSQL("IN_PROCEDURE_NAME", procedureName, 50, SqlDbType.NVarChar));

                //파라미터 정보를 생성한다.
                tmpHmdb.CreateParameter(param);

                //hmDT = tmpHmdb.GetDataTable(CommandType.Text, queryText);
                hmDT = tmpHmdb.GetDataTable(CommandType.Text, SB.ToString());

                return hmDT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }

        public DataSet SelectDataDS()
        {
            DataSet hmDS = new DataSet();

            try
            {
                hmDS = hmdb.GetDataSet(commType, procedureName);

                return hmDS;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }

        public DataTable SelectDataDT()
        {
            DataTable hmDT = new DataTable();

            try
            {
                hmDT = hmdb.GetDataTable(commType, procedureName);

                return hmDT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }

        public int ProcessDataSave()
        {
            try
            {
                return hmdb.ProcessDataSave(commType, procedureName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }
    }
}
