using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Collections;

namespace KHK_portfolio
{
    public partial class MYHOPE : MenuChildForm
    {
        GroupBox group;
        GroupBox[] arr;
        Panel[] pnlarr;
        TextBox txtbox;
        Thread tread;
        

        public MYHOPE()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
        public override void P_RowAdd()
        {
            string BoxName = AddCheck(VisionBox0, VisionBox1, VisionBox2, VisionBox3, VisionBox4);
            ShowGroupBox(BoxName);
        }

        public override void P_RowDel()
        {
            string BoxName = DelCheck(VisionBox0, VisionBox1, VisionBox2, VisionBox3, VisionBox4);
            HideGroupBox(BoxName);
        }

        private void HideVisionBox()
        {
            VisionBox0.Visible = false;
            VisionBox1.Visible = false;
            VisionBox2.Visible = false;
            VisionBox3.Visible = false;
            VisionBox4.Visible = false;
        }

        private void HideVisionPanel()
        {
            Visionpanel0.Visible = false;
            Visionpanel1.Visible = false;
            Visionpanel2.Visible = false;
            Visionpanel3.Visible = false;
            Visionpanel4.Visible = false;
        }


        private void MYHOPE_Load(object sender, EventArgs e)
        {
            HideVisionBox();
            HideVisionPanel();          
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            
        }

        private string AddCheck(GroupBox gru0 , GroupBox gru1, GroupBox gru2 , GroupBox gru3 , GroupBox gru4) //비지블 아닌 그룹박스 이름을 리턴하고 
        {
            arr = new GroupBox[5];
            arr[0] = gru0;
            arr[1] = gru1;
            arr[2] = gru2;
            arr[3] = gru3;
            arr[4] = gru4;

            string Name = string.Empty;

            for (int i = 0; i <arr.Length ; i++)
            {
                if(arr[i].Visible == false)
                {
                    Name = arr[i].Name.ToString();
                    break;
                }              
            }
            return Name;
        }

        private void ShowGroupBox(string groupBoxName)
        {          
            try
            {
                group = new GroupBox();
                this.Controls.Find(groupBoxName, true)[0].Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("더 이상 생성할 수 없습니다.");
            }              
        }

        private void HideGroupBox(string groupBoxName)
        {          
            try
            {
                string num = groupBoxName.Substring(groupBoxName.Length - 1);
                string txtName = "textBox" + num.Trim();
                string title = "txtVisionTiltle" + num.Trim();
                string per = "txtVisionPer"+ num.Trim();
                try
                {
                    group = new GroupBox();
                    this.Controls.Find(groupBoxName, true)[0].Visible = false;
                    this.Controls.Find(txtName, true)[0].Text = string.Empty;
                    this.Controls.Find(title, true)[0].Text = string.Empty;
                    this.Controls.Find(per, true)[0].Text = "0";
                }
                catch (Exception ex)
                {
                    VisionBox0.Visible = false;
                    textBox0.Text = string.Empty;
                    txtVisionPer0.Text = "0";
                    printVisonTitle0.Text = string.Empty;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("더이상 삭제할 수 없습니다.");
            }    
        }



        private string DelCheck(GroupBox gru0, GroupBox gru1, GroupBox gru2, GroupBox gru3, GroupBox gru4) //비지블 아닌 그룹박스 이름을 리턴하고 
        {
            arr = new GroupBox[5];
            arr[0] = gru0;
            arr[1] = gru1;
            arr[2] = gru2;
            arr[3] = gru3;
            arr[4] = gru4;

            string Name = string.Empty;

            for (int i = arr.Length-1; i >= 0; i --)
            {
                if (arr[i].Visible == true)
                {
                    Name = arr[i].Name.ToString();
                    break;
                }
            }
            return Name;
        }


        //private int ReturnArrCount(GroupBox gru0, GroupBox gru1, GroupBox gru2, GroupBox gru3, GroupBox gru4) //그룹박스 보이는 갯수 구하고
        //{
        //    arr = new GroupBox[5];
        //    arr[0] = gru0;
        //    arr[1] = gru1;
        //    arr[2] = gru2;
        //    arr[3] = gru3;
        //    arr[4] = gru4;

        //    int count = 0;

        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        if (arr[i].Visible == true)
        //        {
        //            count++;
        //        }
        //    }
        //    return count;
        //}
  

        private void ShowPanel(Panel pnl1 , Panel pnl2, Panel pnl3, Panel pnl4, Panel pnl5
                               ,GroupBox gru0, GroupBox gru1, GroupBox gru2, GroupBox gru3, GroupBox gru4)
        {
            pnlarr = new Panel[5];

            arr = new GroupBox[5];

            pnlarr[0] = pnl1;
            pnlarr[1] = pnl2;
            pnlarr[2] = pnl3;
            pnlarr[3] = pnl4;
            pnlarr[4] = pnl5;

            arr[0] = gru0;
            arr[1] = gru1;
            arr[2] = gru2;
            arr[3] = gru3;
            arr[4] = gru4;

            try
            {
                for (int i = 0; i < pnlarr.Length; i++)
                {
                    if (arr[i].Visible == true)
                    {
                        pnlarr[i].Visible = true;
                    }
                    else
                    {
                        pnlarr[i].Visible = false;
                    }
                }
            }
            catch (Exception)
            {       
            }
            
        }

        private void SetPrintString()
        {
            printVisonTitle0.Text = txtVisionTiltle0.Text;
            printVisonTitle1.Text = txtVisionTiltle1.Text;
            printVisonTitle2.Text = txtVisionTiltle2.Text;
            printVisonTitle3.Text = txtVisionTiltle3.Text;
            printVisonTitle4.Text = txtVisionTiltle4.Text;


            Probar0.Text = txtVisionPer0.Text + "%".Trim();
            Probar1.Text = txtVisionPer1.Text + "%".Trim();
            Probar2.Text = txtVisionPer2.Text + "%".Trim();
            Probar3.Text = txtVisionPer3.Text + "%".Trim();         
            Probar4.Text = txtVisionPer4.Text + "%".Trim();
        }

        private void ProgressBarEvent1(double per0 , double per1, double per2, double per3, double per4)
        {                
            try
            {
                Thread.Sleep(10);                        
                for (int a = 1; a <= per0; a++)
                {                   
                    Probar0.Value = a;
                    Probar0.Update();
                }
                for (int b = 1; b <= per1; b++)
                {                   
                    Probar1.Value = b;
                    Probar1.Update();               
                }
                for (int c = 1; c <= per2; c++)
                {                 
                    Probar2.Value = c;
                    Probar2.Update();                  
                }
                for (int d = 1; d <= per3; d++)
                {                   
                    Probar3.Value = d;
                    Probar3.Update();              
                }
                for (int e = 1; e <= per4; e++)
                {                 
                    Probar4.Value = e;
                    Probar4.Update();                   
                }
                Thread.ResetAbort();
            }
            catch (Exception)
            {              
                return;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }

        

        private void SetProgressBar()
        {

            Probar0.Value = 0;
            Probar0.Minimum = 0;
            Probar0.Maximum = 100;

            Probar1.Value = 0;
            Probar1.Minimum = 0;
            Probar1.Maximum = 100;

            Probar2.Value = 0;
            Probar2.Minimum = 0;
            Probar2.Maximum = 100;

            Probar3.Value = 0;
            Probar3.Minimum = 0;
            Probar3.Maximum = 100;

            Probar4.Value = 0;
            Probar4.Minimum = 0;
            Probar4.Maximum = 100;
        }
        
        private bool CheckData()
        {
            double result;

            try
            {
                if (txtVisionPer0.Text == string.Empty)
                {
                    MessageBox.Show("1 번 진행도를 확인해주세요");
                    return false;
                }
                else if (!double.TryParse(txtVisionPer0.Text.Trim(), out result))
                {
                    MessageBox.Show("1 번 진행도에는 숫자만 입력하실수 있습니다.");
                    return false;
                }
                else if (Convert.ToInt32(txtVisionPer0.Text) > 100)
                {
                    MessageBox.Show("1 번 진행도의 최대값은 100입니다.");
                    return false;
                }
                else if (Convert.ToInt32(txtVisionPer0.Text) < 0)
                {
                    MessageBox.Show("1 번 진행도의 최소값은 0입니다.");
                    return false;
                }




                if (txtVisionPer1.Text == string.Empty)
                {
                    MessageBox.Show("2 번 진행도를 확인해주세요");
                    return false;
                }
                else if (!double.TryParse(txtVisionPer1.Text.Trim(), out result))
                {
                    MessageBox.Show("2 번 진행도에는 숫자만 입력하실수 있습니다.");
                    return false;
                }
                else if (Convert.ToInt32(txtVisionPer1.Text) > 100)
                {
                    MessageBox.Show("2 번 진행도의 최대값은 100입니다.");
                    return false;
                }
                else if (Convert.ToInt32(txtVisionPer1.Text) < 0)
                {
                    MessageBox.Show("2 번 진행도의 최소값은 0입니다.");
                    return false;
                }




                if (txtVisionPer2.Text == string.Empty)
                {
                    MessageBox.Show("3 번 진행도를 확인해주세요");
                    return false;
                }
                else if (!double.TryParse(txtVisionPer2.Text.Trim(), out result))
                {
                    MessageBox.Show("3 번 진행도에는 숫자만 입력하실수 있습니다.");
                    return false;
                }
                else if (Convert.ToInt32(txtVisionPer2.Text) > 100)
                {
                    MessageBox.Show("3 번 진행도의 최대값은 100입니다.");
                    return false;
                }
                else if (Convert.ToInt32(txtVisionPer2.Text) < 0)
                {
                    MessageBox.Show("3 번 진행도의 최소값은 0입니다.");
                    return false;
                }




                if (txtVisionPer3.Text == string.Empty)
                {
                    MessageBox.Show("4 번 진행도를 확인해주세요");
                    return false;
                }
                else if (!double.TryParse(txtVisionPer3.Text.Trim(), out result))
                {
                    MessageBox.Show("4 번 진행도에는 숫자만 입력하실수 있습니다.");
                    return false;
                }
                else if (Convert.ToInt32(txtVisionPer3.Text) > 100)
                {
                    MessageBox.Show("4 번 진행도의 최대값은 100입니다.");
                    return false;
                }
                else if (Convert.ToInt32(txtVisionPer3.Text) < 0)
                {
                    MessageBox.Show("4 번 진행도의 최소값은 0입니다.");
                    return false;
                }




                if (txtVisionPer4.Text == string.Empty)
                {
                    MessageBox.Show("5 번 진행도를 확인해주세요");
                    return false;
                }
                else if (!double.TryParse(txtVisionPer4.Text.Trim(), out result))
                {
                    MessageBox.Show("5 번 진행도에는 숫자만 입력하실수 있습니다.");
                    return false;
                }
                else if (Convert.ToInt32(txtVisionPer4.Text) > 100)
                {
                    MessageBox.Show("5 번 진행도의 최대값은 100입니다.");
                    return false;
                }
                else if (Convert.ToInt32(txtVisionPer4.Text) < 0)
                {
                    MessageBox.Show("5 번 진행도의 최소값은 0입니다.");
                    return false;
                }

            }
            catch (Exception)
            {

               
            }
            return true;
        }

        private void btnPrint_MouseHover(object sender, EventArgs e)
        {
            
        }

        public override void P_ReadDBInfo()
        {
            if (SearchWorkInfo())
            {
                DrawColor();
            }
           
        }

        public override void P_Save()
        {
            SaveData();
        }

        private void DrawColor()
        {
            if (CheckData() == true)
            {
                SetProgressBar();

                //int boxcount = ReturnArrCount(VisionBox0, VisionBox1, VisionBox2, VisionBox3, VisionBox4);

                SetPrintString();

                ShowPanel(Visionpanel0, Visionpanel1, Visionpanel2, Visionpanel3, Visionpanel4
                    , VisionBox0, VisionBox1, VisionBox2, VisionBox3, VisionBox4);

                ProgressBarEvent1(Double.Parse(txtVisionPer0.Text.Trim()), Double.Parse(txtVisionPer1.Text.Trim()),
                    Double.Parse(txtVisionPer2.Text.Trim()), Double.Parse(txtVisionPer3.Text.Trim()), Double.Parse(txtVisionPer4.Text.Trim()));
              
            }
            else
            {
                return;
            }
        }

        private void txtVisionPer0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtVisionPer1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtVisionPer2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtVisionPer3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtVisionPer4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private bool AllClear()
        {
            if (MessageBox.Show("초기화 하시겠습니까?", "신규", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return false;
            }

            textBox0.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;

            txtVisionTiltle4.Text = string.Empty;
            txtVisionTiltle3.Text = string.Empty;
            txtVisionTiltle2.Text = string.Empty;
            txtVisionTiltle1.Text = string.Empty;
            txtVisionTiltle0.Text = string.Empty;

            return true;
        }

        public override void P_New()
        {
            AllClear();
        }
     

        private bool SaveData() // 이미지 저장
        {        
            if (MessageBox.Show("저장 하시겠습니까?", "저장", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return false;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {       
                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();

                //Set Procedure Name
                dbhandle.ProcedureName = "MYHOPE_C";

                //Create parameter lists.
                ArrayList param = new ArrayList();
                param.Add(new ParamList("IN_FUNC", "C", 10));

                param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));
                param.Add(new ParamList("IN_NAME", UserInfo.User_Name, 20));

                param.Add(new ParamList("IN_TEXTBOX0", textBox0.Text.Trim(), 300));
                param.Add(new ParamList("IN_TEXTBOX1", textBox1.Text.Trim(), 300));
                param.Add(new ParamList("IN_TEXTBOX2", textBox2.Text.Trim(), 300));
                param.Add(new ParamList("IN_TEXTBOX3", textBox3.Text.Trim(), 300));
                param.Add(new ParamList("IN_TEXTBOX4", textBox4.Text.Trim(), 300));

                param.Add(new ParamList("IN_LBLTEXT0", txtVisionTiltle0.Text.Trim(), 30));
                param.Add(new ParamList("IN_LBLTEXT1", txtVisionTiltle1.Text.Trim(), 30));
                param.Add(new ParamList("IN_LBLTEXT2", txtVisionTiltle2.Text.Trim(), 30));
                param.Add(new ParamList("IN_LBLTEXT3", txtVisionTiltle3.Text.Trim(), 30));
                param.Add(new ParamList("IN_LBLTEXT4", txtVisionTiltle4.Text.Trim(), 30));


                param.Add(new ParamList("RET_CODE", string.Empty, 10));
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



        private bool SearchWorkInfo()
        {

            try
            {
                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();

                //Set Procedure Name
                dbhandle.ProcedureName = "MYHOPE_R";

                //Create parameter lists.
                ArrayList param = new ArrayList();
                param.Add(new ParamList("IN_FUNC", "R", 10));

                param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));
                param.Add(new ParamList("IN_NAME", UserInfo.User_Name, 20));

                param.Add(new ParamList("IN_TEXTBOX0", string.Empty, 300));
                param.Add(new ParamList("IN_TEXTBOX1", string.Empty, 300));
                param.Add(new ParamList("IN_TEXTBOX2", string.Empty, 300));
                param.Add(new ParamList("IN_TEXTBOX3", string.Empty, 300));
                param.Add(new ParamList("IN_TEXTBOX4", string.Empty, 300));

                param.Add(new ParamList("IN_LBLTEXT0", string.Empty, 30));
                param.Add(new ParamList("IN_LBLTEXT1", string.Empty, 30));
                param.Add(new ParamList("IN_LBLTEXT2", string.Empty, 30));
                param.Add(new ParamList("IN_LBLTEXT3", string.Empty, 30));
                param.Add(new ParamList("IN_LBLTEXT4", string.Empty, 30));

                param.Add(new ParamList("RET_CODE", "", -1));
                param.Add(new ParamList("RET_MSG", "", 250));

                //Create Procedure Parameters.
                dbhandle.CreateParam(CommandType.StoredProcedure, param);

                //Create parameter string for debugging
                string paramString = dbhandle.GetParamString();
                DataTable hmDT = dbhandle.SelectDataDT();

                if (hmDT != null)
                {
                    textBox0.Text = hmDT.Rows[0]["TEXTBOX1"].ToString().Trim();                   
                    textBox1.Text = hmDT.Rows[0]["TEXTBOX2"].ToString().Trim();
                    textBox2.Text = hmDT.Rows[0]["TEXTBOX3"].ToString().Trim();
                    textBox3.Text = hmDT.Rows[0]["TEXTBOX4"].ToString().Trim();
                    textBox4.Text = hmDT.Rows[0]["TEXTBOX5"].ToString().Trim();

                    txtVisionTiltle0.Text = hmDT.Rows[0]["TITLE1"].ToString().Trim();
                    txtVisionTiltle1.Text = hmDT.Rows[0]["TITLE2"].ToString().Trim();
                    txtVisionTiltle2.Text = hmDT.Rows[0]["TITLE3"].ToString().Trim();
                    txtVisionTiltle3.Text = hmDT.Rows[0]["TITLE4"].ToString().Trim();
                    txtVisionTiltle4.Text = hmDT.Rows[0]["TITLE5"].ToString().Trim();

                    if(textBox0.Text == string.Empty && txtVisionTiltle0.Text == string.Empty)
                    {
                        VisionBox0.Visible = false;
                    }
                    else
                    {
                        VisionBox0.Visible = true;
                    }

                    if (textBox1.Text == string.Empty && txtVisionTiltle1.Text == string.Empty)
                    {
                        VisionBox1.Visible = false;
                    }
                    else
                    {
                        VisionBox1.Visible = true;
                    }

                    if (textBox2.Text == string.Empty && txtVisionTiltle2.Text == string.Empty)
                    {
                        VisionBox2.Visible = false;
                    }
                    else
                    {
                        VisionBox2.Visible = true;
                    }

                    if (textBox3.Text == string.Empty && txtVisionTiltle3.Text == string.Empty)
                    {
                        VisionBox3.Visible = false;
                    }
                    else
                    {
                        VisionBox3.Visible = true;
                    }

                    if (textBox4.Text == string.Empty && txtVisionTiltle4.Text == string.Empty)
                    {
                        VisionBox4.Visible = false;
                    }
                    else
                    {
                        VisionBox4.Visible = true;
                    }
                }

                if (dbhandle.GetRetParamValue("RET_CODE") == "0")
                {
                    //EtcUtil.SetMessage(lblMessage, MsgType.OK, dbhandle.GetRetParamValue("RET_MSG"));
                    MessageBox.Show(dbhandle.GetRetParamValue("RET_MSG"));
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

    }
}
