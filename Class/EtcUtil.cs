using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace KHK_portfolio
{
    public class EtcUtil
    {
        public static string GetMiddleString(string str, string begin, string end)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            string result = null;

            if (str.IndexOf(begin) > -1)
            {
                str = str.Substring(str.IndexOf(begin) + begin.Length);

                if (str.IndexOf(end) > -1) result = str.Substring(0, str.IndexOf(end));
                else result = str;
            }

            return result;
        }

        //콤보 박스의 문자를 찾는다. : 코드는 반드시 왼쪽에 ...
        public static void FindComboData(ComboBox cbo, string findStr, int len)
        {
            for (int index = 0; index < cbo.Items.Count; index++)
            {
                string pTarget = cbo.Items[index].ToString();

                if (pTarget.Trim() != string.Empty && pTarget.Substring(0, len).Trim() == findStr.Trim())
                {
                    cbo.SelectedIndex = index;
                    return;
                }
            }

            cbo.SelectedIndex = -1;
        }

        public static void FindComboData(ComboBox cbo, string findStr)
        {
            for (int index = 0; index < cbo.Items.Count; index++)
            {
                string pTarget = cbo.Items[index].ToString();

                if (pTarget.Trim() != string.Empty && pTarget.Trim() == findStr.Trim())
                {
                    cbo.SelectedIndex = index;
                    return;
                }
            }

            cbo.SelectedIndex = -1;
        }

        public static void SetMessage(System.Windows.Forms.Label lblMsg, MsgType mt, string msg)
        {
            switch (mt)
            {
                case MsgType.ERROR:
                    lblMsg.BackColor = Color.Yellow;
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "ERROR - " + msg;
                    break;
                case MsgType.OK:
                    lblMsg.BackColor = Color.Black;
                    lblMsg.ForeColor = Color.White;
                    lblMsg.Text = "OK - " + msg;
                    break;
                case MsgType.WARNING:
                    lblMsg.BackColor = Color.Black;
                    lblMsg.ForeColor = Color.Yellow;
                    lblMsg.Text = "WARNING - " + msg;
                    break;
                case MsgType.INFO:
                    lblMsg.BackColor = Color.Black;
                    lblMsg.ForeColor = Color.Yellow;
                    lblMsg.Text = "INFO - " + msg;
                    break;
                default:
                    break;
            }
        }

        public static void SetMessage(System.Windows.Forms.ToolStripStatusLabel lblMsg, MsgType mt, string msg)
        {
            StatusStrip ss = (StatusStrip)lblMsg.GetCurrentParent();
            Color backColor;
            backColor = ss.BackColor;

            switch (mt)
            {
                case MsgType.ERROR:
                    //ss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(26)))), ((int)(((byte)(89)))));
                    lblMsg.BackColor = backColor;
                    lblMsg.ForeColor = Color.FromArgb(255, 0, 130);
                    lblMsg.Text = "ERROR - " + msg;
                    break;
                case MsgType.OK:
                    //ss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
                    //lblMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
                    lblMsg.BackColor = backColor;
                    lblMsg.ForeColor = Color.White;
                    lblMsg.Text = "OK - " + msg;
                    break;
                case MsgType.WARNING:
                    //ss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
                    //lblMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
                    lblMsg.BackColor = backColor;
                    lblMsg.ForeColor = Color.Yellow;
                    lblMsg.Text = "WARNING - " + msg;
                    break;
                case MsgType.INFO:
                    //ss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
                    lblMsg.BackColor = backColor;
                    lblMsg.ForeColor = Color.Yellow;
                    lblMsg.Text = "INFO - " + msg;
                    break;
                default:
                    break;
            }
        }

        public static void SetFormInfo(string mainKeyName, string formName, string subFormKeyName, string regKeyName, string regValue)
        {
            Microsoft.Win32.RegistryKey mainKey = null;
            Microsoft.Win32.RegistryKey frmKey = null;
            Microsoft.Win32.RegistryKey subFormKey = null;
            mainKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(mainKeyName);
            frmKey = mainKey.CreateSubKey(formName);

            if (string.IsNullOrEmpty(subFormKeyName))
            {
                frmKey.SetValue(regKeyName, regValue);
            }
            else
            {
                subFormKey = frmKey.CreateSubKey(formName);
                subFormKey.SetValue(regKeyName, regValue);
            }
        }

        public static string GetFormInfo(string mainKeyName, string formName, string subFormKeyName, string regKeyName)
        {
            Microsoft.Win32.RegistryKey mainKey = null;
            Microsoft.Win32.RegistryKey frmKey = null;
            Microsoft.Win32.RegistryKey subFormKey = null;

            mainKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(mainKeyName);

            if (mainKey != null)
            {
                frmKey = mainKey.OpenSubKey(formName);

                if (frmKey != null)
                {
                    if (string.IsNullOrEmpty(subFormKeyName))
                    {
                        if (!string.IsNullOrEmpty((string)frmKey.GetValue(regKeyName)))
                            return (string)frmKey.GetValue(regKeyName);
                        else
                            return string.Empty;
                    }
                    else
                    {
                        subFormKey = frmKey.OpenSubKey(subFormKeyName);

                        if (!string.IsNullOrEmpty((string)subFormKey.GetValue(regKeyName)))
                            return (string)subFormKey.GetValue(regKeyName);
                        else
                            return string.Empty;
                    }
                }
            }

            return string.Empty;
        }

        public static double DateDiff(string Interval, DateTime Date1, DateTime Date2)
        {
            double diff = 0;
            TimeSpan ts = Date2 - Date1;

            switch (Interval.ToLower())
            {
                case "y":
                    ts = DateTime.Parse(Date2.ToString("yyyy-01-01")) - DateTime.Parse(Date1.ToString("yyyy-01-01"));
                    diff = Convert.ToDouble(ts.TotalDays / 365);
                    break;
                case "m":
                    ts = DateTime.Parse(Date2.ToString("yyyy-MM-01")) - DateTime.Parse(Date1.ToString("yyyy-MM-01"));
                    diff = Convert.ToDouble((ts.TotalDays / 365) * 12);
                    break;
                case "d":
                    ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd"));
                    diff = ts.Days;
                    break;
                case "h":
                    ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd HH:00:00")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd HH:00:00"));
                    diff = ts.TotalHours;
                    break;
                case "n":
                    ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd HH:mm:00")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd HH:mm:00"));
                    diff = ts.TotalMinutes;
                    break;
                case "s":
                    ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd HH:mm:ss")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd HH:mm:ss"));
                    diff = ts.TotalSeconds;
                    break;
                case "ms":
                    diff = ts.TotalMilliseconds;
                    break;
            }

            return diff;
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);

            return returnImage;
        }

        public static string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    return printer;
            }
            return string.Empty;
        }

        public static string GetXMLFromUGrid(Dictionary<string, string>[] dic)
        {
            if (dic.Length == 0)
            {
                throw new Exception("There is no data in dictionary.");
            }

            DataSet _dsInit = new DataSet("ROOT");
            DataTable DATA = new DataTable("DATA");

            //첫번째 값으로만 컬럼을 생성한다.
            foreach (KeyValuePair<string, string> kv in dic[0])
            {
                DataColumn column = new DataColumn(kv.Key, typeof(string));
                DATA.Columns.Add(column);
            }

            for (int index = 0; index < dic.Length; index++)
            {
                DataRow ADDDATE = DATA.NewRow();

                foreach (KeyValuePair<string, string> kv in dic[index])
                {
                    ADDDATE[kv.Key] = kv.Value;
                }

                DATA.Rows.Add(ADDDATE);
            }

            _dsInit.Tables.Add(DATA);

            return _dsInit.GetXml();
        }

        public static string GetRegistry(RegistryType Type)
        {
            string sData = string.Empty;

            if (Type == RegistryType.ENTP_CODE || Type == RegistryType.USER_ID)
            {
                Microsoft.Win32.RegistryKey WorkCenter = null;
                WorkCenter = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(KHK_portfolio.Properties.Resources.g_RegistryAPPSet);

                if (WorkCenter == null) { return sData; }

                sData = (string)WorkCenter.GetValue(KHK_portfolio.Properties.Resources.g_RegKeyUserID);
            }

            if (Type == RegistryType.SERVER_IP || Type == RegistryType.SERVER_URL)
            {
                Microsoft.Win32.RegistryKey SERVERInfo = null;
                SERVERInfo = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(KHK_portfolio.Properties.Resources.g_RegistryServerInfo);

                if (SERVERInfo == null) { return sData; }

                if (Type == RegistryType.SERVER_IP)
                {
                    sData = (string)SERVERInfo.GetValue(KHK_portfolio.Properties.Resources.g_RegKeyDBServerIP);
                }
                if (Type == RegistryType.SERVER_URL)
                {
                    sData = (string)SERVERInfo.GetValue(KHK_portfolio.Properties.Resources.g_RegKeyDownLoadPath);
                }
            }

            return sData;
        }

        public static void SetRegistry(RegistryType Type, string sData)
        {
            if (Type == RegistryType.ENTP_CODE || Type == RegistryType.USER_ID)
            {
                Microsoft.Win32.RegistryKey WorkCenter = null;
                WorkCenter = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(KHK_portfolio.Properties.Resources.g_RegistryAPPSet);
                WorkCenter.SetValue(KHK_portfolio.Properties.Resources.g_RegKeyUserID, sData);
            }

            if (Type == RegistryType.SERVER_IP || Type == RegistryType.SERVER_URL)
            {
                Microsoft.Win32.RegistryKey SERVERInfo = null;
                SERVERInfo = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(KHK_portfolio.Properties.Resources.g_RegistryServerInfo);

                if (Type == RegistryType.SERVER_IP)
                {
                    SERVERInfo.SetValue(KHK_portfolio.Properties.Resources.g_RegKeyDBServerIP, sData);
                }
                if (Type == RegistryType.SERVER_URL)
                {
                    SERVERInfo.SetValue(KHK_portfolio.Properties.Resources.g_RegKeyDownLoadPath, sData);
                }
            }
        }

        /// <summary>
        /// 김현준 : 팝업시 부모창 흐리게 
        /// </summary>
        public static void PopupBackGround(ref Form backForm)
        {
            Form formbackground = new Form();
            backForm = formbackground;

            try
            {
                formbackground.StartPosition = FormStartPosition.Manual;
                formbackground.FormBorderStyle = FormBorderStyle.None;
                formbackground.Opacity = .70d;
                formbackground.BackColor = System.Drawing.Color.FromArgb(46, 49, 60);
                formbackground.WindowState = FormWindowState.Maximized;
                formbackground.TopMost = true;
                formbackground.Location = new System.Drawing.Point(1, 25);
                formbackground.ShowInTaskbar = false;
                formbackground.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
            }
        }
    }
}

