using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Collections;

namespace KHK_portfolio
{
    class UserInfo
    {
        public static string User_ID = "";
        public static string User_PW = "";
        public static string User_Name = "";

        public static string g_DBIP = "";
        public static string g_DownLoadPath = "";

        public static string g_SaUpID = "";
        public static string g_SaUpName = "";

        public static string g_UserID = "";
        public static string g_UserName = "";
        public static string g_UserDept = "";
        public static string g_UserCust = "";
        public static string g_UserCustName = "";
        public static string g_UserType = "";
        public static string g_ProgID = "";
    }
}
