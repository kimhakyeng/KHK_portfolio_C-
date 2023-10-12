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
using System.Diagnostics;
using System.Net;

namespace KHK_portfolio
{
    public partial class LoginForm : Form
    {

        private string loginYN = "N";
        public string LoginYN
        {
            get { return loginYN; }
            set { loginYN = value; }
        }

        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (NullCheck())
            {
                if (SearchData())
                {
                    LoginForm.ActiveForm.Close();
                }              
            }
            else
            {
                return;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
           
        }

        private void btnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (NullCheck())
                {
                    if (SearchData())
                    {
                        LoginForm.ActiveForm.Close();
                    }
                }
                else
                {
                    return;
                }
            }
        }
      

        private void btnEXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private bool SearchData()
        {
            try
            {
                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();

                //Set Procedure Name
                dbhandle.ProcedureName = "USER_CHECK_R";

                //Create parameter lists.
                ArrayList param = new ArrayList();
                param.Add(new ParamList("IN_FUNC", "R", 10));
               
                param.Add(new ParamList("IN_ID", txtID.Text.Trim(), 20));
                param.Add(new ParamList("IN_PW", txtPW.Text.Trim(), 20));
               
                param.Add(new ParamList("RET_CODE", "", -1));
                param.Add(new ParamList("RET_MSG", "", 250));

                //Create Procedure Parameters.
                dbhandle.CreateParam(CommandType.StoredProcedure, param);

                //Create parameter string for debugging
                string paramString = dbhandle.GetParamString();
                DataTable hmDT = dbhandle.SelectDataDT();

                if (hmDT != null)
                {
                    //스프레드 초기화
                    //fpsWorkOrderList.ActiveSheet.Rows.Clear();

                    ////스프레드 데이터 뿌려주기
                    //SpreadUtil.SetSpreadValue(fpsWorkOrderList, hmDT);
                 
                    UserInfo.User_ID = hmDT.Rows[0]["ID"].ToString().Trim();
                    UserInfo.User_PW = hmDT.Rows[0]["PW"].ToString().Trim();
                    UserInfo.User_Name = hmDT.Rows[0]["NAME"].ToString().Trim();                  
                }

                if (dbhandle.GetRetParamValue("RET_CODE") == "0")
                {                                   
                    MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                    return true;
                    loginYN = "Y";
                }
                else
                {               
                    MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                    return false;
                    loginYN = "N";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
           
        }


        private bool NullCheck()
        {          
            if (string.IsNullOrEmpty(txtID.Text.Trim()))
            {
                MessageBox.Show("ID를 입력하세요.");
                txtID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPW.Text.Trim()))
            {
                MessageBox.Show("PW를 입력하세요.");
                txtPW.Focus();
                return false;
            }

            return true;
        }

        private void txtPW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (NullCheck())
                {
                    if (SearchData())
                    {
                        LoginForm.ActiveForm.Close();
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (NullCheck())
                {
                    if (SearchData())
                    {
                        LoginForm.ActiveForm.Close();
                    }                
                }
                else
                {
                    return;
                }
            }           
        }


    }
}
