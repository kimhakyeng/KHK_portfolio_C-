using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;


namespace KHK_portfolio
{
    public partial class AbilityForm : MenuChildForm
    {
        FpSpread fpsSpread;

        static string control = "";

        public AbilityForm()
        {
            InitializeComponent();
        }

        public override void P_ReadDBInfo()
        {
            Work_SearchList(); // 경력
            Ability_SearchList(); // 장점
            Skill_SearchList(); //자격증
            Experience_SearchList();  // 경험
        }

        public override void P_Save() // 저장
        {
            switch (control)
            {
                case "W":
                    if (SaveWORK())
                    {
                        Work_SearchList();
                    }
                    break;

                case "S":
                    if (SaveSKILL())
                    {
                        Skill_SearchList();
                    }
                    break;

                case "E":
                    if (EXPERIENCE_Save())
                    {
                        Experience_SearchList();
                    }
                    break;
                case "A":
                    if (ABILITY_Save())
                    {
                        Ability_SearchList();
                    }
                    break;
                default:
                    break;
            }
        }

        public override void P_New()
        {
            base.P_New();
        }

        public override void P_RowAdd()
        {
            if (fpsSpread == null)
            {
                MessageBox.Show("스프레드를 먼저 선택해주세요");
                return;
            }
            try
            {
                SpreadUtil.AddRow(fpsSpread, fpsSpread.ActiveSheet.Rows.Count);
            }
            catch (Exception)
            {
                MessageBox.Show("스프레드를 먼저 선택해주세요.");
            }
        }

        public override void P_RowDel() // 삭제 
        {
            if (fpsSpread == null)
            {
                MessageBox.Show("스프레드를 먼저 선택해주세요");
                return;
            }
            if (fpsSpread.ActiveSheet.Rows.Count == 0)
            {
                return;
            }

            try
            {
                if (SpreadUtil.GetText(fpsSpread, fpsSpread.ActiveSheet.ActiveRowIndex, "NAME") 
                    == string.Empty && SpreadUtil.GetText(fpsSpread, fpsSpread.ActiveSheet.ActiveRowIndex, "REMARK") == string.Empty)
                {
                    SpreadUtil.RemoveRow(fpsSpread, fpsSpread.ActiveSheet.ActiveRow.Index);
                }
                else
                {
                    switch (control)
                    {
                        case "W":
                            if (WORKBomDel())
                            {
                                Work_SearchList();
                            }
                            break;

                        case "S":
                            if (SKILLBomDel())
                            {
                                Skill_SearchList();
                            }
                            break;

                        case "E":
                            if (EXPERIENCE_BomDel())
                            {
                                Experience_SearchList();
                            }
                            break;
                        case "A":
                            if (ABILITY_BomDel())
                            {
                                Ability_SearchList();
                            }
                            break;
                        default:
                            break;
                    }          
                }
            }
            catch (Exception)
            {
               
            }
            
        }



        private void AbilityForm_Load(object sender, EventArgs e)
        {

        }


        private void fpsSkills_CellClick(object sender, CellClickEventArgs e)
        {
            fpsSpread = this.fpsSkills;
            control = "S";
        }

        private void fpsWork_CellClick(object sender, CellClickEventArgs e)
        {
            fpsSpread = this.fpsWork;
            control = "W";
        }

        private void fpsExperience_CellClick(object sender, CellClickEventArgs e)
        {
            fpsSpread = this.fpsExperience;
            control = "E";
        }

        private void fpsAbility_CellClick(object sender, CellClickEventArgs e)
        {
            fpsSpread = this.fpsAbility;
            control = "A";
        }

        private bool Skill_SearchList()
        {
            //Create DB handle object.
            DBHandler dbhandle = new DBHandler();

            //Set Procedure Name
            dbhandle.ProcedureName = "SKILL_R";

            //Create parameter lists.
            ArrayList param = new ArrayList();
            param.Add(new ParamList("IN_FUNC", "R", 10));
            param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));

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
                fpsSkills.ActiveSheet.Rows.Clear();

                //스프레드 데이터 뿌려주기
                SpreadUtil.SetSpreadValue(fpsSkills, hmDT);
            }

            if (dbhandle.GetRetParamValue("RET_CODE") == "0")
            {
                //EtcUtil.SetMessage(lblMessage, MsgType.OK, dbhandle.GetRetParamValue("RET_MSG"));
                //MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                return true;
            }
            else
            {
                //EtcUtil.SetMessage(lblMessage, MsgType.ERROR, dbhandle.GetRetParamValue("RET_MSG"));
                MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                return false;
            }
        }

        private bool Work_SearchList()
        {
            //Create DB handle object.
            DBHandler dbhandle = new DBHandler();

            //Set Procedure Name
            dbhandle.ProcedureName = "WORK_R";

            //Create parameter lists.
            ArrayList param = new ArrayList();
            param.Add(new ParamList("IN_FUNC", "R", 10));
            param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));
            param.Add(new ParamList("IN_REMARK", UserInfo.User_ID, 20));

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
                fpsWork.ActiveSheet.Rows.Clear();

                //스프레드 데이터 뿌려주기
                SpreadUtil.SetSpreadValue(fpsWork, hmDT);
            }

            if (dbhandle.GetRetParamValue("RET_CODE") == "0")
            {
                //EtcUtil.SetMessage(lblMessage, MsgType.OK, dbhandle.GetRetParamValue("RET_MSG"));
                //MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                return true;
            }
            else
            {
                //EtcUtil.SetMessage(lblMessage, MsgType.ERROR, dbhandle.GetRetParamValue("RET_MSG"));
                MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                return false;
            }
        }




        private bool Experience_SearchList()
        {
            //Create DB handle object.
            DBHandler dbhandle = new DBHandler();

            //Set Procedure Name
            dbhandle.ProcedureName = "EXPERIENCE_R";

            //Create parameter lists.
            ArrayList param = new ArrayList();
            param.Add(new ParamList("IN_FUNC", "R", 10));
            param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));

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
                fpsExperience.ActiveSheet.Rows.Clear();

                //스프레드 데이터 뿌려주기
                SpreadUtil.SetSpreadValue(fpsExperience, hmDT);
            }

            if (dbhandle.GetRetParamValue("RET_CODE") == "0")
            {
                //EtcUtil.SetMessage(lblMessage, MsgType.OK, dbhandle.GetRetParamValue("RET_MSG"));
                //MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                return true;
            }
            else
            {
                //EtcUtil.SetMessage(lblMessage, MsgType.ERROR, dbhandle.GetRetParamValue("RET_MSG"));
                MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                return false;
            }
        }




        private bool Ability_SearchList()
        {
            //Create DB handle object.
            DBHandler dbhandle = new DBHandler();

            //Set Procedure Name
            dbhandle.ProcedureName = "ABILITY_R";

            //Create parameter lists.
            ArrayList param = new ArrayList();
            param.Add(new ParamList("IN_FUNC", "R", 10));
            param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));

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
                fpsAbility.ActiveSheet.Rows.Clear();

                //스프레드 데이터 뿌려주기
                SpreadUtil.SetSpreadValue(fpsAbility, hmDT);
            }

            if (dbhandle.GetRetParamValue("RET_CODE") == "0")
            {
                //EtcUtil.SetMessage(lblMessage, MsgType.OK, dbhandle.GetRetParamValue("RET_MSG"));
                //MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                return true;
            }
            else
            {
                //EtcUtil.SetMessage(lblMessage, MsgType.ERROR, dbhandle.GetRetParamValue("RET_MSG"));
                MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                return false;
            }
        }




      
        private bool SaveWORK()
        {
            if (MessageBox.Show("저장 하시겠습니까?", "저장", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return false;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                Dictionary<string, string>[] XmlData = new Dictionary<string, string>[fpsWork.ActiveSheet.Rows.Count];

                foreach (FarPoint.Win.Spread.Row TmRow in fpsWork.ActiveSheet.Rows)
                {
                    XmlData[TmRow.Index] = new Dictionary<string, string>();

                    XmlData[TmRow.Index].Add("WORK_DATE", SpreadUtil.GetText(fpsWork, TmRow.Index, "DATE"));
                    XmlData[TmRow.Index].Add("WORK_NAME", SpreadUtil.GetText(fpsWork, TmRow.Index, "NAME"));
                    XmlData[TmRow.Index].Add("WORK_REMARK", SpreadUtil.GetText(fpsWork, TmRow.Index, "REMARK"));

                    XmlData[TmRow.Index].Add("SEQ", (TmRow.Index + 1).ToString());
                }

                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();

                //Set Procedure Name
                dbhandle.ProcedureName = "WORK_SAVE_C";

                //Create parameter lists.
                ArrayList param = new ArrayList();
                param.Add(new ParamList("IN_FUNC", "W", 10));
           
                param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));
                param.Add(new ParamList("IN_USER_NAME", UserInfo.User_Name, 10));
                param.Add(new ParamList("IN_NAME", SpreadUtil.GetText(fpsWork, fpsWork.ActiveSheet.ActiveRowIndex, "NAME"), 30));
                param.Add(new ParamList("IN_REMARK", SpreadUtil.GetText(fpsWork, fpsWork.ActiveSheet.ActiveRowIndex, "REMARK"),100));

                param.Add(new ParamList("IN_XML_CONTENTS", XmlData.Length == 0 ? string.Empty : EtcUtil.GetXMLFromUGrid(XmlData), -1));

                param.Add(new ParamList("RET_PO_NO", string.Empty, 20));
                param.Add(new ParamList("RET_CODE", string.Empty, 10));
                param.Add(new ParamList("RET_MSG", string.Empty, 255));

                //Create Procedure Parameters.
                dbhandle.CreateParam(CommandType.StoredProcedure, param);

                //Create parameter string for debugging
                string paramString = dbhandle.GetParamString();
                int hmINT = dbhandle.ProcessDataSave();

                if (dbhandle.GetRetParamValue("RET_CODE") == "0")  //ret_code
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.OK, dbhandle.GetRetParamValue("RET_MSG"));
                    //MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                    return true;
                }
                else
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.ERROR, dbhandle.GetRetParamValue("RET_MSG"));
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


        private bool WORKBomDel()
        {
            if (MessageBox.Show("삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return false;
            }

            try
            {
                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();

                //Set Procedure Name
                dbhandle.ProcedureName = "WORK_SAVE_C";

                //Create parameter lists.
                ArrayList param = new ArrayList();

                param.Add(new ParamList("IN_FUNC", "D", 10));

                param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));
                param.Add(new ParamList("IN_USER_NAME", UserInfo.User_Name, 10));
                param.Add(new ParamList("IN_NAME", SpreadUtil.GetText(fpsWork, fpsWork.ActiveSheet.ActiveRowIndex, "NAME"), 30));
                param.Add(new ParamList("IN_REMARK", SpreadUtil.GetText(fpsWork, fpsWork.ActiveSheet.ActiveRowIndex, "REMARK"), 100));
                param.Add(new ParamList("IN_XML_CONTENTS", "", -1));

                //Create Procedure Parameters.
                dbhandle.CreateParam(CommandType.StoredProcedure, param);

                //Create parameter string for debugging
                string paramString = dbhandle.GetParamString();

                int hmINT = dbhandle.ProcessDataSave();

                if (dbhandle.GetRetParamValue("RET_CODE") == "0")  //ret_code
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.OK, dbhandle.GetRetParamValue("RET_MSG"));
                    //MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                }
                else
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.ERROR, dbhandle.GetRetParamValue("RET_MSG"));
                    MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                    return false;
                }
                return true;
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



        private bool SaveSKILL()
        {
            if (MessageBox.Show("저장 하시겠습니까?", "저장", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return false;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                Dictionary<string, string>[] XmlData = new Dictionary<string, string>[fpsSkills.ActiveSheet.Rows.Count];

                foreach (FarPoint.Win.Spread.Row TmRow in fpsSkills.ActiveSheet.Rows)
                {
                    XmlData[TmRow.Index] = new Dictionary<string, string>();

                    XmlData[TmRow.Index].Add("WORK_DATE", SpreadUtil.GetText(fpsSkills, TmRow.Index, "DATE"));
                    XmlData[TmRow.Index].Add("WORK_NAME", SpreadUtil.GetText(fpsSkills, TmRow.Index, "NAME"));
                    XmlData[TmRow.Index].Add("WORK_REMARK", SpreadUtil.GetText(fpsSkills, TmRow.Index, "REMARK"));

                    XmlData[TmRow.Index].Add("SEQ", (TmRow.Index + 1).ToString());
                }

                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();

                //Set Procedure Name
                dbhandle.ProcedureName = "SKILLSAVE_C";

                //Create parameter lists.
                ArrayList param = new ArrayList();
                param.Add(new ParamList("IN_FUNC", "S", 10));

                param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));
                param.Add(new ParamList("IN_USER_NAME", UserInfo.User_Name, 10));
                param.Add(new ParamList("IN_NAME", SpreadUtil.GetText(fpsSkills, fpsSkills.ActiveSheet.ActiveRowIndex, "NAME"), 30));
                param.Add(new ParamList("IN_REMARK", SpreadUtil.GetText(fpsSkills, fpsSkills.ActiveSheet.ActiveRowIndex, "REMARK"), 100));

                param.Add(new ParamList("IN_XML_CONTENTS", XmlData.Length == 0 ? string.Empty : EtcUtil.GetXMLFromUGrid(XmlData), -1));

                param.Add(new ParamList("RET_PO_NO", string.Empty, 20));
                param.Add(new ParamList("RET_CODE", string.Empty, 10));
                param.Add(new ParamList("RET_MSG", string.Empty, 255));

                //Create Procedure Parameters.
                dbhandle.CreateParam(CommandType.StoredProcedure, param);

                //Create parameter string for debugging
                string paramString = dbhandle.GetParamString();
                int hmINT = dbhandle.ProcessDataSave();

                if (dbhandle.GetRetParamValue("RET_CODE") == "0")  //ret_code
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.OK, dbhandle.GetRetParamValue("RET_MSG"));
                    //MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                    return true;
                }
                else
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.ERROR, dbhandle.GetRetParamValue("RET_MSG"));
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




        private bool SKILLBomDel()
        {
            if (MessageBox.Show("삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return false;
            }

            try
            {
                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();

                //Set Procedure Name
                dbhandle.ProcedureName = "SKILLSAVE_C";

                //Create parameter lists.
                ArrayList param = new ArrayList();

                param.Add(new ParamList("IN_FUNC", "D", 10));

                param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));
                param.Add(new ParamList("IN_USER_NAME", UserInfo.User_Name, 10));
                param.Add(new ParamList("IN_NAME", SpreadUtil.GetText(fpsSkills , fpsSkills.ActiveSheet.ActiveRowIndex ,"NAME"), 30));
                param.Add(new ParamList("IN_REMARK", SpreadUtil.GetText(fpsSkills, fpsSkills.ActiveSheet.ActiveRowIndex, "REMARK"), 100));
                param.Add(new ParamList("IN_XML_CONTENTS", "", -1));

                //Create Procedure Parameters.
                dbhandle.CreateParam(CommandType.StoredProcedure, param);

                //Create parameter string for debugging
                string paramString = dbhandle.GetParamString();

                int hmINT = dbhandle.ProcessDataSave();

                if (dbhandle.GetRetParamValue("RET_CODE") == "0")  //ret_code
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.OK, dbhandle.GetRetParamValue("RET_MSG"));
                    //MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                }
                else
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.ERROR, dbhandle.GetRetParamValue("RET_MSG"));
                    MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                    return false;
                }
                return true;
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

    

        private bool EXPERIENCE_Save()
        {
            if (MessageBox.Show("저장 하시겠습니까?", "저장", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return false;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                Dictionary<string, string>[] XmlData = new Dictionary<string, string>[fpsExperience.ActiveSheet.Rows.Count];

                foreach (FarPoint.Win.Spread.Row TmRow in fpsExperience.ActiveSheet.Rows)
                {
                    XmlData[TmRow.Index] = new Dictionary<string, string>();

                    XmlData[TmRow.Index].Add("WORK_DATE", SpreadUtil.GetText(fpsExperience, TmRow.Index, "DATE"));
                    XmlData[TmRow.Index].Add("WORK_NAME", SpreadUtil.GetText(fpsExperience, TmRow.Index, "NAME"));
                    XmlData[TmRow.Index].Add("WORK_REMARK", SpreadUtil.GetText(fpsExperience, TmRow.Index, "REMARK"));

                    XmlData[TmRow.Index].Add("SEQ", (TmRow.Index + 1).ToString());
                }

                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();

                //Set Procedure Name
                dbhandle.ProcedureName = "EXPERIENCE_SAVE_C";

                //Create parameter lists.
                ArrayList param = new ArrayList();
                param.Add(new ParamList("IN_FUNC", "E", 10));

                param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));
                param.Add(new ParamList("IN_USER_NAME", UserInfo.User_Name, 10));
                param.Add(new ParamList("IN_NAME", SpreadUtil.GetText(fpsExperience, fpsExperience.ActiveSheet.ActiveRowIndex, "NAME"), 30));
                param.Add(new ParamList("IN_REMARK", SpreadUtil.GetText(fpsExperience, fpsExperience.ActiveSheet.ActiveRowIndex, "REMARK"), 100));

                param.Add(new ParamList("IN_XML_CONTENTS", XmlData.Length == 0 ? string.Empty : EtcUtil.GetXMLFromUGrid(XmlData), -1));

                param.Add(new ParamList("RET_PO_NO", string.Empty, 20));
                param.Add(new ParamList("RET_CODE", string.Empty, 10));
                param.Add(new ParamList("RET_MSG", string.Empty, 255));

                //Create Procedure Parameters.
                dbhandle.CreateParam(CommandType.StoredProcedure, param);

                //Create parameter string for debugging
                string paramString = dbhandle.GetParamString();
                int hmINT = dbhandle.ProcessDataSave();

                if (dbhandle.GetRetParamValue("RET_CODE") == "0")  //ret_code
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.OK, dbhandle.GetRetParamValue("RET_MSG"));
                    //MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                    return true;
                }
                else
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.ERROR, dbhandle.GetRetParamValue("RET_MSG"));
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


        private bool EXPERIENCE_BomDel()
        {
            if (MessageBox.Show("삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return false;
            }

            try
            {
                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();

                //Set Procedure Name
                dbhandle.ProcedureName = "EXPERIENCE_SAVE_C";

                //Create parameter lists.
                ArrayList param = new ArrayList();

                param.Add(new ParamList("IN_FUNC", "D", 10));

                param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));
                param.Add(new ParamList("IN_USER_NAME", UserInfo.User_Name, 10));
                param.Add(new ParamList("IN_NAME", SpreadUtil.GetText(fpsExperience, fpsExperience.ActiveSheet.ActiveRowIndex, "NAME"), 30));
                param.Add(new ParamList("IN_REMARK", SpreadUtil.GetText(fpsExperience, fpsExperience.ActiveSheet.ActiveRowIndex, "REMARK"), 100));
                param.Add(new ParamList("IN_XML_CONTENTS", "", -1));

                //Create Procedure Parameters.
                dbhandle.CreateParam(CommandType.StoredProcedure, param);

                //Create parameter string for debugging
                string paramString = dbhandle.GetParamString();

                int hmINT = dbhandle.ProcessDataSave();

                if (dbhandle.GetRetParamValue("RET_CODE") == "0")  //ret_code
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.OK, dbhandle.GetRetParamValue("RET_MSG"));
                    //MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                }
                else
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.ERROR, dbhandle.GetRetParamValue("RET_MSG"));
                    MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                    return false;
                }
                return true;
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




        private bool ABILITY_Save()
        {
            if (MessageBox.Show("저장 하시겠습니까?", "저장", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return false;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                Dictionary<string, string>[] XmlData = new Dictionary<string, string>[fpsAbility.ActiveSheet.Rows.Count];

                foreach (FarPoint.Win.Spread.Row TmRow in fpsAbility.ActiveSheet.Rows)
                {
                    XmlData[TmRow.Index] = new Dictionary<string, string>();

                    //XmlData[TmRow.Index].Add("WORK_DATE", SpreadUtil.GetText(fpsAbility, TmRow.Index, "DATE"));
                    XmlData[TmRow.Index].Add("WORK_NAME", SpreadUtil.GetText(fpsAbility, TmRow.Index, "NAME"));
                    XmlData[TmRow.Index].Add("WORK_REMARK", SpreadUtil.GetText(fpsAbility, TmRow.Index, "REMARK"));

                    XmlData[TmRow.Index].Add("SEQ", (TmRow.Index + 1).ToString());
                }

                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();

                //Set Procedure Name
                dbhandle.ProcedureName = "ABILITY_SAVE_C";

                //Create parameter lists.
                ArrayList param = new ArrayList();
                param.Add(new ParamList("IN_FUNC", "A", 10));

                param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));
                param.Add(new ParamList("IN_USER_NAME", UserInfo.User_Name, 10));
                param.Add(new ParamList("IN_NAME", SpreadUtil.GetText(fpsAbility, fpsAbility.ActiveSheet.ActiveRowIndex, "NAME"), 30));
                param.Add(new ParamList("IN_REMARK", SpreadUtil.GetText(fpsAbility, fpsAbility.ActiveSheet.ActiveRowIndex, "REMARK"), 100));

                param.Add(new ParamList("IN_XML_CONTENTS", XmlData.Length == 0 ? string.Empty : EtcUtil.GetXMLFromUGrid(XmlData), -1));

                param.Add(new ParamList("RET_PO_NO", string.Empty, 20));
                param.Add(new ParamList("RET_CODE", string.Empty, 10));
                param.Add(new ParamList("RET_MSG", string.Empty, 255));

                //Create Procedure Parameters.
                dbhandle.CreateParam(CommandType.StoredProcedure, param);

                //Create parameter string for debugging
                string paramString = dbhandle.GetParamString();
                int hmINT = dbhandle.ProcessDataSave();

                if (dbhandle.GetRetParamValue("RET_CODE") == "0")  //ret_code
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.OK, dbhandle.GetRetParamValue("RET_MSG"));
                    //MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                    return true;
                }
                else
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.ERROR, dbhandle.GetRetParamValue("RET_MSG"));
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


        private bool ABILITY_BomDel()
        {
            if (MessageBox.Show("삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return false;
            }

            try
            {
                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();

                //Set Procedure Name
                dbhandle.ProcedureName = "ABILITY_SAVE_C";

                //Create parameter lists.
                ArrayList param = new ArrayList();

                param.Add(new ParamList("IN_FUNC", "D", 10));

                param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));
                param.Add(new ParamList("IN_USER_NAME", UserInfo.User_Name, 10));
                param.Add(new ParamList("IN_NAME", SpreadUtil.GetText(fpsAbility, fpsAbility.ActiveSheet.ActiveRowIndex, "NAME"), 30));
                param.Add(new ParamList("IN_REMARK", SpreadUtil.GetText(fpsAbility, fpsAbility.ActiveSheet.ActiveRowIndex, "REMARK"), 100));
                param.Add(new ParamList("IN_XML_CONTENTS", "", -1));

                //Create Procedure Parameters.
                dbhandle.CreateParam(CommandType.StoredProcedure, param);

                //Create parameter string for debugging
                string paramString = dbhandle.GetParamString();

                int hmINT = dbhandle.ProcessDataSave();

                if (dbhandle.GetRetParamValue("RET_CODE") == "0")  //ret_code
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.OK, dbhandle.GetRetParamValue("RET_MSG"));
                    //MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                }
                else
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.ERROR, dbhandle.GetRetParamValue("RET_MSG"));
                    MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
                    return false;
                }
                return true;
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

    }
}
