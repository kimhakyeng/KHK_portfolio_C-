using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Web;
using System.Windows;
using System.Web.UI;
using System.Collections;

using System.Windows.Forms.DataVisualization.Charting;


using System.Resources; // 리소스
using System.Reflection; // 어샘블리 



namespace KHK_portfolio
{
    public partial class MYSELF : MenuChildForm
    {
        static string saveFolder = @"C:\Users\HMS_003\Desktop\김하경 포트폴리오\KHK_portfolio\Image"; //이미지 저장경로

        OpenFileDialog openFile;
     

        static string selectionMbti = string.Empty;

        static string selectAdress = string.Empty;

        static string NEW = "Y";

      
        public string SELECTMBTI
        {
            get { return selectionMbti; }
            set { selectionMbti = value; }
        }

        public string MyAdress
        {
            get { return selectAdress; }
            set { selectAdress = value; }
        }

        public MYSELF()
        {
            InitializeComponent();               
        }

        private void MYSELF_Load(object sender, EventArgs e)
        {
            ComboBoxSet();                 
        }  

        private void ComboBoxSet()
        {
            comMBTI.Items.Add("INTP");
            comMBTI.Items.Add("INTJ");
            comMBTI.Items.Add("ENTJ");
            comMBTI.Items.Add("ENTP");

            comMBTI.Items.Add("ISFP");
            comMBTI.Items.Add("ISTP");
            comMBTI.Items.Add("ESTP");
            comMBTI.Items.Add("ESFP");

            comMBTI.Items.Add("INFP");
            comMBTI.Items.Add("INFJ");
            comMBTI.Items.Add("ENFJ");
            comMBTI.Items.Add("ENFP");

            comMBTI.Items.Add("ESTJ");
            comMBTI.Items.Add("ESFJ");
            comMBTI.Items.Add("ISTJ");
            comMBTI.Items.Add("ISFJ");

            comMBTI.SelectedIndex = -1;
        }

       
        private void comMBTI_SelectedIndexChanged(object sender, EventArgs e)
        {          
            //selectionMbti = comMBTI.Text;

            //string Image = GetPath(selectionMbti);

            //picMBTI.Load(Image);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string position = gMapControl3.Position.ToString();
            //string[] positions = position.Split(',');

            //string Xposition = positions[0].ToString().Substring(positions[0].ToString().IndexOf('=') + 1).Trim();
            //string Yposition1 = positions[1].ToString().Substring(positions[1].ToString().IndexOf('=') + 1).Trim();

            //string[] Yposition = Yposition1.Split('}');

            ////좌표 추출
            //MessageBox.Show(Xposition);
            //MessageBox.Show(Yposition[0].ToString());

        }

        private void picSelf_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _open = new OpenFileDialog();// 파일열기 대화상자 

                _open.Title = "OpenPicture"; // 제목

                //_open.Filter = "(JPEG FILE)|*.jpg|(Bitmap FILE)|*.bmp|(ALL FILE)|*.*"; // 필터
                _open.Filter = "(ALL FILE)|*.*"; // 필터

                _open.FilterIndex = 1;// 인덱스 

                _open.RestoreDirectory = true; // 최근 열었던 폴더 저장

                if (_open.ShowDialog() == DialogResult.OK)// 사용자가 대화상자에서 OK 눌렀을경우
                {
                    FileStream imgs = new FileStream(_open.FileName, FileMode.Open, FileAccess.Read);// 그림을 열어줄 FileStream 생성

                    Image img = Image.FromStream(imgs);// 열어준 그림을 담을 Image개체 생성

                    picSelf.Image = img;// 저장할 그림을 보여줄 PictureBox에 그림 넣고

                    picSelf.Tag = _open.FileName;// Tag속성에 해당그림 경로/파일명 저장
                }
            }
            catch (Exception)
            {
                MessageBox.Show("지원하지 않는 이미지 형식입니다.");
                return;
            }
        }

        private string GetResourceFileName()
        {
            // My Project Resource에 있는 파일의 Full Path를 가져오는 코드 
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName).ToString();
     
            Stream s = this.GetType().Assembly.GetManifestResourceStream("KHK_portfolio\\Properties\\Resources\\ISTJ.png");

           
            return strAppPath;

        }

        protected object LoadProjectResource(string mbtiImage)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string strBaseName = assembly.GetName().Name + "." + "Properties.Resources."+ mbtiImage;
            // strBaseName = "csharp_ResourceTest.Properties.Resources";
            //ResourceManager rm = new ResourceManager(strBaseName, assembly);
            //return rm.GetObject(strResName); // load resource from item name
            return strBaseName;
        }

        private string GetPath(string imageName)
        {
            string resourcePath = Path.GetFullPath(Assembly.GetExecutingAssembly().Location + @"\..\..\..\..\KHK_portfolio\Resources");

            string dayWallpaper = resourcePath +@"\"+imageName+".png";

            return dayWallpaper;
        }

       

        private void picHobby_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _open = new OpenFileDialog();// 파일열기 대화상자 

                _open.Title = "OpenPicture"; // 제목

                //_open.Filter = "(JPEG FILE)|*.jpg|(Bitmap FILE)|*.bmp|(ALL FILE)|*.*"; // 필터
                _open.Filter = "(ALL FILE)|*.*"; // 필터

                _open.FilterIndex = 1;// 인덱스 

                _open.RestoreDirectory = true; // 최근 열었던 폴더 저장

                if (_open.ShowDialog() == DialogResult.OK)// 사용자가 대화상자에서 OK 눌렀을경우
                {
                    FileStream imgs = new FileStream(_open.FileName, FileMode.Open, FileAccess.Read);// 그림을 열어줄 FileStream 생성

                    Image img = Image.FromStream(imgs);// 열어준 그림을 담을 Image개체 생성

                    picHobby.Image = img;// 저장할 그림을 보여줄 PictureBox에 그림 넣고

                    picHobby.Tag = _open.FileName;// Tag속성에 해당그림 경로/파일명 저장
                }
            }
            catch (Exception)
            {
                MessageBox.Show("지원하지 않는 이미지 형식입니다.");
                return;
            }

            
        }

        private void picAddress_DoubleClick(object sender, EventArgs e)
        {
           if(MessageBox.Show("해당 주소로 검색 하시겠습니끼?" , "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                selectAdress = txtLocalBox.Text.ToString();
                SearchMap searchMap = new SearchMap();

                searchMap.ShowDialog();
            }
            else
            {
                return;
            }
        }

        private void picHobby_Click(object sender, EventArgs e)
        {

        }

        public override void P_ReadDBInfo()
        {         
            SearchInspList();          
        }

        public void textboxHide()
        {
            if (MessageBox.Show("입력란을 여시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                txtNameBox.Visible = true;
                txtAgeBox.Visible = true;
                txtMailBox.Visible = true;
                txtPhoneNumberBox.Visible = true;
                txtTitleBox.Visible = true;
                txtLocalBox.Visible = true;
                comMBTI.Visible = true;               
            }
            else
            {
                txtNameBox.Visible = false;
                txtAgeBox.Visible = false;
                txtMailBox.Visible = false;
                txtPhoneNumberBox.Visible = false;
                txtTitleBox.Visible = false;
                txtLocalBox.Visible = false;
                comMBTI.Visible = false;              
            }  
        }

        public void SetTextBoxtolbl()
        {
            lblName.Text = txtNameBox.Text;
            lblAge.Text = txtAgeBox.Text;
            lblMail.Text = txtMailBox.Text;
            lblPhone.Text = txtPhoneNumberBox.Text;
            lblTitle.Text = txtTitleBox.Text;
            lblAdress.Text = txtLocalBox.Text;
        }

        public void SetlbltoTextBox()
        {
            txtNameBox.Text = lblName.Text;
            txtAgeBox.Text = lblAge.Text;
            txtMailBox.Text = lblMail.Text;
            txtPhoneNumberBox.Text = lblPhone.Text;
            txtTitleBox.Text = lblTitle.Text;
            txtLocalBox.Text = lblAdress.Text;
        }

        public void NullTextBox()
        {
            txtNameBox.Text = string.Empty;
            txtAgeBox.Text = string.Empty;
            txtMailBox.Text = string.Empty;
            txtPhoneNumberBox.Text = string.Empty;
            txtTitleBox.Text = string.Empty;
            txtLocalBox.Text = string.Empty;
        }


        public override void P_RowAdd()
        {
            SpreadUtil.AddRow(fpsAbility, fpsAbility.ActiveSheet.Rows.Count);
        }

        public override void P_RowDel()
        {
            if (fpsAbility.ActiveSheet.Rows.Count == 0)
            {
                return;
            }
            else
            {
                SpreadUtil.RemoveRow(fpsAbility, fpsAbility.ActiveSheet.ActiveRow.Index);
            }
            
        }


        private void DrawPieChart(Chart chart, string title, int count)
        {
            int sent = 100;

            //reset your chart series and legends
            chart.Series.Clear();
            chart.Legends.Clear();
            chart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));

            //Add a new Legend(if needed) and do some formating   
            chart.Legends.Add("MyLegend");
            chart.Legends[0].LegendStyle = LegendStyle.Table;
            chart.Legends[0].Docking = Docking.Top;
            chart.Legends[0].Alignment = StringAlignment.Center;
            chart.Legends[0].Title = title;
            chart.Legends[0].TitleFont = new Font("굴림", 10, FontStyle.Regular);
            chart.Legends[0].Font = new Font("굴림", 10, FontStyle.Regular);
            chart.Legends[0].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            chart.Legends[0].ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            chart.Legends[0].TitleForeColor = System.Drawing.Color.White;
            chart.Legends[0].Enabled = false;
            

            //Add a new chart-series
            string seriesname = "MySeriesName";
            chart.Series.Add(seriesname);
            //set the chart-type to "Pie"
            chart.Series[seriesname].ChartType = SeriesChartType.Doughnut;

            //Add some datapoints so the series. in this case you can pass the values to this method
            //chart.Series[0].Points.AddXY("MyPointName", sent/count);
            //chart.Series[0].Points.AddXY("MyPointName1", sent / count);
            //chart.Series[0].Points.AddXY("MyPointName2", sent / count);
            //chart.Series[0].Points.AddXY("MyPointName3", sent / count);
            //chart.Series[0].Points.AddXY("MyPointName4", sent / count);

            for (int i = 0; i < fpsAbility.ActiveSheet.Rows.Count; i++)
            {
                chart.Series[0].Points.AddXY(/*SpreadUtil.GetText(fpsAbility, i, "ABILITY_NAME")*/"", sent / count);
            }
            chart1.Series[0].Font = new Font("굴림", 10, FontStyle.Regular);
            chart1.Series[0].LabelBackColor= System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
        }

        private void fpsAbility_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                DrawPieChart(chart1, "MyAbility", fpsAbility.ActiveSheet.Rows.Count);
            }
        }

        public override void P_Save()
        {
            if (SaveData())
            {
                
            }
            
        }


        private bool SaveData() // 이미지 저장
        {
            string ability = "";
            byte[] imageData = new Byte[0];          

            if (MessageBox.Show("저장 하시겠습니까?", "저장", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return false;
            }

            SetTextBoxtolbl();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                for (int i = 0; i < fpsAbility.ActiveSheet.RowCount; i++)
                {
                    ability+=SpreadUtil.GetText(fpsAbility, i, "ABILITY_NAME")+",".Trim();
                }
               

                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();

                //Set Procedure Name
                dbhandle.ProcedureName = "MYSELF_C";

                //Create parameter lists.
                ArrayList param = new ArrayList();
                param.Add(new ParamList("IN_FUNC", "C", 10));             

                param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));
                param.Add(new ParamList("IN_NAME", lblName.Text, 20));

                param.Add(new ParamList("IN_TITLE", lblTitle.Text.Trim(), 20));
                param.Add(new ParamList("IN_AGE", lblAge.Text.Trim(), 20)); ;
                param.Add(new ParamList("IN_MAIL", lblMail.Text.Trim(), 50));
                param.Add(new ParamList("IN_PHONE_NUMBER", lblPhone.Text.Trim(), 20));
                param.Add(new ParamList("IN_ADRESS", lblAdress.Text.Trim(), 50)); ;

                if(picSelf.Image != null)
                {
                    param.Add(new ParamList("IN_SELF_IMAGE", EtcUtil.imageToByteArray(picSelf.Image), -1));
                }
                else
                {
                    param.Add(new ParamList("IN_SELF_IMAGE", imageData, -1));
                }            
                param.Add(new ParamList("IN_MBTI", comMBTI.Text.ToString(), 20));            
                if (picHobby.Image != null)
                {
                    param.Add(new ParamList("IN_HOBBY", EtcUtil.imageToByteArray(picHobby.Image), -1));
                }
                else
                {
                    param.Add(new ParamList("IN_HOBBY", imageData, -1));
                }
                param.Add(new ParamList("IN_ABILITY", ability, 100));
                param.Add(new ParamList("IN_Educational_History", txtEducationalHistory.Text.Trim(), 100));
                param.Add(new ParamList("IN_Career", txtWorkHistory.Text.Trim(), 100));
                param.Add(new ParamList("IN_Salary", txtSalary.Text.Trim(), 100));
                param.Add(new ParamList("IN_WorkState", txthopeState.Text.Trim(), 100));
                param.Add(new ParamList("IN_Portfolio", txtportfolio.Text.Trim(), 100));


                param.Add(new ParamList("RET_CODE", string.Empty, 10));
                param.Add(new ParamList("RET_MSG", string.Empty, 255));

                //Create Procedure Parameters.
                dbhandle.CreateParam(CommandType.StoredProcedure, param);

                //Create parameter string for debugging
                string paramString = dbhandle.GetParamString();
                int hmINT = dbhandle.ProcessDataSave();
                UserInfo.User_Name = lblTitle.Text.Trim();

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
                UserInfo.User_Name = lblName.Text.Trim();
            }
        }




        private bool SearchInspList() // 이미지 조회 프로시저 
        {
            try
            {
                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();
                //Set Procedure Name
                dbhandle.ProcedureName = "MYSELF_R";
                //Create parameter lists.
                ArrayList param = new ArrayList();
                param.Add(new ParamList("IN_FUNC", "R", 10));
                //param.Add(new ParamList("IN_ENTP_CODE", "HM", 10));
                param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));
                param.Add(new ParamList("IN_NAME", UserInfo.User_Name, 20));
                param.Add(new ParamList("RET_CODE", "", -1));
                param.Add(new ParamList("RET_MSG", "", 250));

                //Create Procedure Parameters.
                dbhandle.CreateParam(CommandType.StoredProcedure, param);

                //Create parameter string for debugging
                string paramString = dbhandle.GetParamString();
                DataTable hmDT = dbhandle.SelectDataDT();
     
                if (hmDT != null)
                {
                    lblTitle.Text = hmDT.Rows[0]["TITLE"].ToString();
                    lblAge.Text = hmDT.Rows[0]["AGE"].ToString();
                    lblAdress.Text = hmDT.Rows[0]["ADRESS"].ToString();
                    lblMail.Text = hmDT.Rows[0]["MAIL"].ToString();
                    lblName.Text = hmDT.Rows[0]["NAME"].ToString();
                    lblPhone.Text = hmDT.Rows[0]["PHONE_NUMBER"].ToString();
                    comMBTI.Text = hmDT.Rows[0]["MBTI"].ToString();

                    txtEducationalHistory.Text = hmDT.Rows[0]["Educational_History"].ToString().Trim();                
                    txtWorkHistory.Text = hmDT.Rows[0]["Career"].ToString().Trim();
                    txtSalary.Text = hmDT.Rows[0]["Salary"].ToString().Trim();
                    txthopeState.Text = hmDT.Rows[0]["WorkState"].ToString().Trim();
                    txtportfolio.Text = hmDT.Rows[0]["Portfolio"].ToString().Trim();

                    SetlbltoTextBox();

                    string[] split_data = hmDT.Rows[0]["Ability"].ToString().Split(',');

                    fpsAbility.ActiveSheet.Rows.Clear();

                    for (int i = 0; i < split_data.Length-1; i++)
                    {
                        SpreadUtil.AddRow(fpsAbility, fpsAbility.ActiveSheet.Rows.Count);
                        SpreadUtil.SetText(fpsAbility, i, 0 , split_data[i].ToString());
                    }


                    byte[] imageData1 = new byte[0];
                    byte[] imageData2 = new byte[0];

                    if (hmDT.Rows[0]["SELF_IMAGE"].ToString().Length > 2 || hmDT.Rows[0]["HOBBY"].ToString().Length > 2)
                    {                      
                        imageData1 = (byte[])(hmDT.Rows[0]["SELF_IMAGE"]);
                        picSelf.Image =  EtcUtil.byteArrayToImage(imageData1);

                        imageData2 = (byte[])(hmDT.Rows[0]["HOBBY"]);
                        picHobby.Image = EtcUtil.byteArrayToImage(imageData2);
                    }
                    else
                    {
                        picSelf.Image = null;

                        picHobby.Image = null;
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
                UserInfo.User_Name = lblName.Text.Trim();
            }
           
        }

        private void comMBTI_TextChanged(object sender, EventArgs e)
        {
            selectionMbti = comMBTI.Text.Trim();

            string Image = GetPath(selectionMbti).Trim();

            picMBTI.Load(Image);

        }

        public override void P_New()
        {

            if(NEW == "Y")
            {
                textboxHide();
            }
            else
            {
                NullTextBox();
                textboxHide();
            }   
        }


        private bool Del_Data() // 이미지 저장
        {     
            if (MessageBox.Show("삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return false;
            }

            lblTitle.Text = string.Empty;
            lblAge.Text = string.Empty;
            lblAdress.Text = string.Empty;
            lblMail.Text = string.Empty;
            lblName.Text = string.Empty;
            lblPhone.Text = string.Empty;
            comMBTI.Text = string.Empty;

            txtEducationalHistory.Text = string.Empty;
            txtWorkHistory.Text = string.Empty;
            txtSalary.Text = string.Empty;
            txthopeState.Text = string.Empty;
            txtportfolio.Text = string.Empty;

            return true;
        }

        public override void P_Del()
        {
            Del_Data();
        }
    }
}
