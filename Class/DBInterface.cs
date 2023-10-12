using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;

namespace KHK_portfolio
{
    public interface IDBFunction
    {
        bool DBOpen();

        bool DBClose();

        string ConString
        {
            get;
        }

        string GetUserID();


        /// <summary>
        /// SELECT 결과를 DataSet으로 Return한다. 두개 이상의 SELECT 결과가 있을 때 사용함.
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        DataSet GetDataSet(CommandType commandType, string commandText);

        /// <summary>
        /// SELECT 결과를 DataTable로 Return한다. 한개의 SELECT 결과가 있을 때 사용함.
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        DataTable GetDataTable(CommandType commandType, string commandText);

        /// <summary>
        /// Select가 없는 데이터처리 프로시저 수행하기.
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ProcessDataSave(CommandType commandType, string commandText);

        /// <summary>
        /// ParamList 구조체의 파라미터 정보를 가지고 프로시저로 넘길 파라미터를 생성한다.
        /// </summary>
        /// <param name="param"></param>
        void CreateParameter(ArrayList param, DataTable paramDBList);

        /// <summary>
        /// ParamList 구조체의 파라미터 정보를 가지고 텍스트 쿼리의 파라미터를 생성한다. 모두 스트링인 경우만...
        /// </summary>
        /// <param name="param"></param>
        void CreateParameter(ArrayList param);

        /// <summary>
        /// 프로시저를 수행할 파라미터 리스트를 조회한다.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        string GetParameterString(string commandText);

        /// <summary>
        /// 파라미터 이름에 해당하는 값 가져온다.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        string GetRetParamValue(string paramName);
    }

    public struct DatabaseInfo
    {
        public int DBCommandTimeOut;
        public string DBType;
        public string DBConnName;   //app.config에 설정된 Connection String 이름 
    }

    public enum HMDbType
    {
        String = 0,
        FixedString = 1,
        Int = 2,
        Double = 3,
        Date = 4,
        Cursor = 29,
        Image = 30,
    }
}
