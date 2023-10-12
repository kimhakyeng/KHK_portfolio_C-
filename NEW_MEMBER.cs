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
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System.Collections;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using System.Threading;

namespace KHK_portfolio
{
    public partial class NEW_MEMBER : BaseForm.PopupChildForm
    {
        public NEW_MEMBER()
        {
            InitializeComponent();
        }

        private bool comboLock = true;

        public bool ComboLock { get => comboLock; set => comboLock = value; } // 이게 텍스트 박스 조작가능하게 만들어주는건가보다.

        private void NEW_MEMBER_Load(object sender, EventArgs e)
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
                    //UserInfo.User_Name = hmDT.Rows[0]["NAME"].ToString().Trim();
                }

                if (dbhandle.GetRetParamValue("RET_CODE") == "0")
                {
                    MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                    return true;                  
                }
                else
                {
                    MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                    return false;                 
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

        private bool DataSave()
        {
            //if (lblCRUD.Text.Trim() == "C")
            //{
            //    if (frmMessageBox.Show("저장하시겠습니까?", "저장", MessageBoxButtons.YesNo) != DialogResult.Yes)
            //    {
            //        return false;
            //    }
            //}
           

            try
            {
                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();

                //Set Procedure Name
                dbhandle.ProcedureName = "USER_CHECK_C";

                //Create parameter lists.
                ArrayList param = new ArrayList();
                param.Add(new ParamList("IN_FUNC", "C", 10));            

                param.Add(new ParamList("IN_USER_NAME", txtName.Text.Trim(), 20));
                param.Add(new ParamList("IN_USER_ID", txtID.Text.Trim(), 30));
                param.Add(new ParamList("IN_USER_PW", txtPW.Text.Trim(), 30));
                param.Add(new ParamList("IN_USER_PW2", txtPW2.Text.Trim(), 30));


                param.Add(new ParamList("RET_CODE", string.Empty, -1));
                param.Add(new ParamList("RET_MSG", string.Empty, 255));

                //Create Procedure Parameters.
                dbhandle.CreateParam(CommandType.StoredProcedure, param);

                //Create parameter string for debugging
                string paramString = dbhandle.GetParamString();
                int hmINT = dbhandle.ProcessDataSave();

                if (dbhandle.GetRetParamValue("RET_CODE") == "0")  //ret_code
                {
                    MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                    return true;
                }
                else
                {            
                    MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                    return false;
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



        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataSave();
        }

        private void btnEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPW_KeyDown(object sender, KeyEventArgs e)
        {
            EtcUtil.SetRegistry(RegistryType.USER_ID, txtID.Text.Trim());
        }
    }
}
