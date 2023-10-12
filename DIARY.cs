using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Reflection; // 어샘블리 
using System.Collections;

namespace KHK_portfolio
{
    public partial class DIARY : MenuChildForm
    {
        public static event PictureBoxClickEvetnHandler PictuerboxHandler;

        private string LastPath = string.Empty;

        private static string imagePath = string.Empty; //이미지 경로

        private static string title = string.Empty; //text

        private static Image selectimage = null;

        public static string[] FILE_NAMES = new string[10];


        public static string[] FILE_TYPES = new string[10];


        public static string[] FILE_TITLES = new string[10];


        public static int SEQ = 0;

        public Image SELECT_IMAGE
        {
            get { return selectimage; }
            set { selectimage = value; }
        }


        public string IMAGE_PATH
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        private static string PDFPath = string.Empty; //PDF 파일경로
        public string PDF_PATH
        {
            get { return PDFPath; }
            set { PDFPath = value; }
        }

        private static string txtNameTitle = ""; // 제목
        public string NAMETITLE
        {
            get { return txtNameTitle; }
            set { txtNameTitle = value; }
        }

        public DIARY()
        {
            InitializeComponent();
            arr = new GroupBox[10];
            pictures = new PictureBox[10];
            images = new Image[10];
        }
        OpenFileDialog dialog; // 전역으로 선언
        GroupBox[] arr;
        PictureBox pic;
        PictureBox[] pictures;
        Image[] images;
        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            string file_name = string.Empty;
            string pdf_file = string.Empty;

            dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file_name = dialog.FileName;
                if (chexkFile(file_name) || chexkPDFFile(file_name))
                {

                    //OpenFileDialog _open = new OpenFileDialog();// 파일열기 대화상자 
                    try
                    {
                        FILE_NAMES[1] = file_name;  //그림을 저장해보자 

                        dialog.Title = "OpenPicture"; // 제목

                        //_open.Filter = "(JPEG FILE)|*.jpg|(Bitmap FILE)|*.bmp|(ALL FILE)|*.*"; // 필터
                        dialog.Filter = "(ALL FILE)|*.*"; // 필터

                        dialog.FilterIndex = 1;// 인덱스 

                        dialog.RestoreDirectory = true; // 최근 열었던 폴더 저장

                        FileStream imgs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);// 그림을 열어줄 FileStream 생성

                        Image img = Image.FromStream(imgs);// 열어준 그림을 담을 Image개체 생성

                        pictureBox1.Image = img;// 저장할 그림을 보여줄 PictureBox에 그림 넣고

                        images[1] = img;

                    }
                    catch (Exception)
                    {
                        pdf_file = dialog.FileName.Substring(dialog.FileName.Length - 3);
                        FILE_TYPES[1] = pdf_file;
                    }
                }
                else
                {
                    MessageBox.Show("지원형식의 파일이 아닙니다.");
                }
            }
            else
            {
                return;
            }

            if (pdf_file == "pdf")
            {
                pictureBox1.Image = Properties.Resources.pdfImage;
            }

            this.pictureBox1.Click += this.pictureBox2_Click;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            string file_name = string.Empty;
            string pdf_file = string.Empty;

            dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {      
                file_name = dialog.FileName;
                if (chexkFile(file_name) || chexkPDFFile(file_name))
                {

                    //OpenFileDialog _open = new OpenFileDialog();// 파일열기 대화상자 
                    try
                    {
                        FILE_NAMES[0] = file_name;  //그림을 저장해보자 

                        dialog.Title = "OpenPicture"; // 제목

                        //_open.Filter = "(JPEG FILE)|*.jpg|(Bitmap FILE)|*.bmp|(ALL FILE)|*.*"; // 필터
                        dialog.Filter = "(ALL FILE)|*.*"; // 필터

                        dialog.FilterIndex = 1;// 인덱스 

                        dialog.RestoreDirectory = true; // 최근 열었던 폴더 저장

                        FileStream imgs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);// 그림을 열어줄 FileStream 생성

                        Image img = Image.FromStream(imgs);// 열어준 그림을 담을 Image개체 생성

                        pictureBox0.Image = img;// 저장할 그림을 보여줄 PictureBox에 그림 넣고

                        images[0] = img;
                      

                    }
                    catch (Exception)
                    {
                        pdf_file = dialog.FileName.Substring(dialog.FileName.Length - 3);
                        FILE_TYPES[0] = pdf_file;
                    }
                }
                else
                {
                    MessageBox.Show("지원형식의 파일이 아닙니다.");
                }
            }
            else
            {             
                return;
            }        

            if(pdf_file == "pdf")
            {
                pictureBox0.Image = Properties.Resources.pdfImage;
            }
         
            this.pictureBox0.Click += this.pictureBox1_Click;
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            string file_name = string.Empty;
            string pdf_file = string.Empty;

            dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file_name = dialog.FileName;
                if (chexkFile(file_name) || chexkPDFFile(file_name))
                {

                    //OpenFileDialog _open = new OpenFileDialog();// 파일열기 대화상자 
                    try
                    {
                        FILE_NAMES[2] = file_name;  //그림을 저장해보자 

                        dialog.Title = "OpenPicture"; // 제목

                        //_open.Filter = "(JPEG FILE)|*.jpg|(Bitmap FILE)|*.bmp|(ALL FILE)|*.*"; // 필터
                        dialog.Filter = "(ALL FILE)|*.*"; // 필터

                        dialog.FilterIndex = 1;// 인덱스 

                        dialog.RestoreDirectory = true; // 최근 열었던 폴더 저장

                        FileStream imgs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);// 그림을 열어줄 FileStream 생성

                        Image img = Image.FromStream(imgs);// 열어준 그림을 담을 Image개체 생성

                        pictureBox2.Image = img;// 저장할 그림을 보여줄 PictureBox에 그림 넣고

                        images[2] = img;

                    }
                    catch (Exception)
                    {
                        pdf_file = dialog.FileName.Substring(dialog.FileName.Length - 3);
                        FILE_TYPES[2] = pdf_file;
                    }
                }
                else
                {
                    MessageBox.Show("지원형식의 파일이 아닙니다.");
                }
            }
            else
            {
                return;
            }

            if (pdf_file == "pdf")
            {
                pictureBox0.Image = Properties.Resources.pdfImage;
            }

            this.pictureBox2.Click += this.pictureBox3_Click;
        }

        private void pictureBox4_DoubleClick(object sender, EventArgs e)
        {
            string file_name = string.Empty;
            string pdf_file = string.Empty;

            dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file_name = dialog.FileName;
                if (chexkFile(file_name) || chexkPDFFile(file_name))
                {

                    //OpenFileDialog _open = new OpenFileDialog();// 파일열기 대화상자 
                    try
                    {
                        FILE_NAMES[3] = file_name;  //그림을 저장해보자 

                        dialog.Title = "OpenPicture"; // 제목

                        //_open.Filter = "(JPEG FILE)|*.jpg|(Bitmap FILE)|*.bmp|(ALL FILE)|*.*"; // 필터
                        dialog.Filter = "(ALL FILE)|*.*"; // 필터

                        dialog.FilterIndex = 1;// 인덱스 

                        dialog.RestoreDirectory = true; // 최근 열었던 폴더 저장

                        FileStream imgs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);// 그림을 열어줄 FileStream 생성

                        Image img = Image.FromStream(imgs);// 열어준 그림을 담을 Image개체 생성

                        pictureBox3.Image = img;// 저장할 그림을 보여줄 PictureBox에 그림 넣고

                        images[3] = img;

                    }
                    catch (Exception)
                    {
                        pdf_file = dialog.FileName.Substring(dialog.FileName.Length - 3);
                        FILE_TYPES[3] = pdf_file;
                    }
                }
                else
                {
                    MessageBox.Show("지원형식의 파일이 아닙니다.");
                }
            }
            else
            {
                return;
            }

            if (pdf_file == "pdf")
            {
                pictureBox3.Image = Properties.Resources.pdfImage;
            }

            this.pictureBox3.Click += this.pictureBox4_Click;
        }

        private void pictureBox5_DoubleClick(object sender, EventArgs e)
        {
            string file_name = string.Empty;
            string pdf_file = string.Empty;

            dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file_name = dialog.FileName;
                if (chexkFile(file_name) || chexkPDFFile(file_name))
                {

                    //OpenFileDialog _open = new OpenFileDialog();// 파일열기 대화상자 
                    try
                    {
                        FILE_NAMES[4] = file_name;  //그림을 저장해보자 

                        dialog.Title = "OpenPicture"; // 제목

                        //_open.Filter = "(JPEG FILE)|*.jpg|(Bitmap FILE)|*.bmp|(ALL FILE)|*.*"; // 필터
                        dialog.Filter = "(ALL FILE)|*.*"; // 필터

                        dialog.FilterIndex = 1;// 인덱스 

                        dialog.RestoreDirectory = true; // 최근 열었던 폴더 저장

                        FileStream imgs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);// 그림을 열어줄 FileStream 생성

                        Image img = Image.FromStream(imgs);// 열어준 그림을 담을 Image개체 생성

                        pictureBox4.Image = img;// 저장할 그림을 보여줄 PictureBox에 그림 넣고

                        images[4] = img;

                    }
                    catch (Exception)
                    {
                        pdf_file = dialog.FileName.Substring(dialog.FileName.Length - 3);
                        FILE_TYPES[4] = pdf_file;
                    }
                }
                else
                {
                    MessageBox.Show("지원형식의 파일이 아닙니다.");
                }
            }
            else
            {
                return;
            }

            if (pdf_file == "pdf")
            {
                pictureBox4.Image = Properties.Resources.pdfImage;
            }

            this.pictureBox4.Click += this.pictureBox5_Click;
        }

        private void pictureBox6_DoubleClick(object sender, EventArgs e)
        {
            string file_name = string.Empty;
            string pdf_file = string.Empty;

            dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file_name = dialog.FileName;
                if (chexkFile(file_name) || chexkPDFFile(file_name))
                {

                    //OpenFileDialog _open = new OpenFileDialog();// 파일열기 대화상자 
                    try
                    {
                        FILE_NAMES[5] = file_name;  //그림을 저장해보자 

                        dialog.Title = "OpenPicture"; // 제목

                        //_open.Filter = "(JPEG FILE)|*.jpg|(Bitmap FILE)|*.bmp|(ALL FILE)|*.*"; // 필터
                        dialog.Filter = "(ALL FILE)|*.*"; // 필터

                        dialog.FilterIndex = 1;// 인덱스 

                        dialog.RestoreDirectory = true; // 최근 열었던 폴더 저장

                        FileStream imgs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);// 그림을 열어줄 FileStream 생성

                        Image img = Image.FromStream(imgs);// 열어준 그림을 담을 Image개체 생성

                        pictureBox5.Image = img;// 저장할 그림을 보여줄 PictureBox에 그림 넣고

                        images[5] = img;

                    }
                    catch (Exception)
                    {
                        pdf_file = dialog.FileName.Substring(dialog.FileName.Length - 3);
                        FILE_TYPES[5] = pdf_file;
                    }
                }
                else
                {
                    MessageBox.Show("지원형식의 파일이 아닙니다.");
                }
            }
            else
            {
                return;
            }

            if (pdf_file == "pdf")
            {
                pictureBox5.Image = Properties.Resources.pdfImage;
            }

            this.pictureBox5.Click += this.pictureBox6_Click;
        }

        private void pictureBox7_DoubleClick(object sender, EventArgs e)
        {
            string file_name = string.Empty;
            string pdf_file = string.Empty;

            dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file_name = dialog.FileName;
                if (chexkFile(file_name) || chexkPDFFile(file_name))
                {

                    //OpenFileDialog _open = new OpenFileDialog();// 파일열기 대화상자 
                    try
                    {
                        FILE_NAMES[6] = file_name;  //그림을 저장해보자 

                        dialog.Title = "OpenPicture"; // 제목

                        //_open.Filter = "(JPEG FILE)|*.jpg|(Bitmap FILE)|*.bmp|(ALL FILE)|*.*"; // 필터
                        dialog.Filter = "(ALL FILE)|*.*"; // 필터

                        dialog.FilterIndex = 1;// 인덱스 

                        dialog.RestoreDirectory = true; // 최근 열었던 폴더 저장

                        FileStream imgs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);// 그림을 열어줄 FileStream 생성

                        Image img = Image.FromStream(imgs);// 열어준 그림을 담을 Image개체 생성

                        pictureBox6.Image = img;// 저장할 그림을 보여줄 PictureBox에 그림 넣고

                        images[6] = img;

                    }
                    catch (Exception)
                    {
                        pdf_file = dialog.FileName.Substring(dialog.FileName.Length - 3);
                        FILE_TYPES[6] = pdf_file;
                    }
                }
                else
                {
                    MessageBox.Show("지원형식의 파일이 아닙니다.");
                }
            }
            else
            {
                return;
            }

            if (pdf_file == "pdf")
            {
                pictureBox6.Image = Properties.Resources.pdfImage;
            }

            this.pictureBox6.Click += this.pictureBox7_Click;
        }

        private void pictureBox8_DoubleClick(object sender, EventArgs e)
        {
            string file_name = string.Empty;
            string pdf_file = string.Empty;

            dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file_name = dialog.FileName;
                if (chexkFile(file_name) || chexkPDFFile(file_name))
                {

                    //OpenFileDialog _open = new OpenFileDialog();// 파일열기 대화상자 
                    try
                    {
                        FILE_NAMES[7] = file_name;  //그림을 저장해보자 

                        dialog.Title = "OpenPicture"; // 제목

                        //_open.Filter = "(JPEG FILE)|*.jpg|(Bitmap FILE)|*.bmp|(ALL FILE)|*.*"; // 필터
                        dialog.Filter = "(ALL FILE)|*.*"; // 필터

                        dialog.FilterIndex = 1;// 인덱스 

                        dialog.RestoreDirectory = true; // 최근 열었던 폴더 저장

                        FileStream imgs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);// 그림을 열어줄 FileStream 생성

                        Image img = Image.FromStream(imgs);// 열어준 그림을 담을 Image개체 생성

                        pictureBox7.Image = img;// 저장할 그림을 보여줄 PictureBox에 그림 넣고

                        images[7] = img;

                    }
                    catch (Exception)
                    {
                        pdf_file = dialog.FileName.Substring(dialog.FileName.Length - 3);
                        FILE_TYPES[7] = pdf_file;
                    }
                }
                else
                {
                    MessageBox.Show("지원형식의 파일이 아닙니다.");
                }
            }
            else
            {
                return;
            }

            if (pdf_file == "pdf")
            {
                pictureBox7.Image = Properties.Resources.pdfImage;
            }

            this.pictureBox7.Click += this.pictureBox8_Click;
        }

        private void pictureBox9_DoubleClick(object sender, EventArgs e)
        {
            string file_name = string.Empty;
            string pdf_file = string.Empty;

            dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file_name = dialog.FileName;
                if (chexkFile(file_name) || chexkPDFFile(file_name))
                {

                    //OpenFileDialog _open = new OpenFileDialog();// 파일열기 대화상자 
                    try
                    {
                        FILE_NAMES[8] = file_name;  //그림을 저장해보자 

                        dialog.Title = "OpenPicture"; // 제목

                        //_open.Filter = "(JPEG FILE)|*.jpg|(Bitmap FILE)|*.bmp|(ALL FILE)|*.*"; // 필터
                        dialog.Filter = "(ALL FILE)|*.*"; // 필터

                        dialog.FilterIndex = 1;// 인덱스 

                        dialog.RestoreDirectory = true; // 최근 열었던 폴더 저장

                        FileStream imgs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);// 그림을 열어줄 FileStream 생성

                        Image img = Image.FromStream(imgs);// 열어준 그림을 담을 Image개체 생성

                        pictureBox8.Image = img;// 저장할 그림을 보여줄 PictureBox에 그림 넣고

                        images[8] = img;

                    }
                    catch (Exception)
                    {
                        pdf_file = dialog.FileName.Substring(dialog.FileName.Length - 3);
                        FILE_TYPES[8] = pdf_file;
                    }
                }
                else
                {
                    MessageBox.Show("지원형식의 파일이 아닙니다.");
                }
            }
            else
            {
                return;
            }

            if (pdf_file == "pdf")
            {
                pictureBox8.Image = Properties.Resources.pdfImage;
            }

            this.pictureBox8.Click += this.pictureBox9_Click;
        }

        private void pictureBox10_DoubleClick(object sender, EventArgs e)
        {
            string file_name = string.Empty;
            string pdf_file = string.Empty;

            dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file_name = dialog.FileName;
                if (chexkFile(file_name) || chexkPDFFile(file_name))
                {

                    //OpenFileDialog _open = new OpenFileDialog();// 파일열기 대화상자 
                    try
                    {
                        FILE_NAMES[9] = file_name;  //그림을 저장해보자 

                        dialog.Title = "OpenPicture"; // 제목

                        //_open.Filter = "(JPEG FILE)|*.jpg|(Bitmap FILE)|*.bmp|(ALL FILE)|*.*"; // 필터
                        dialog.Filter = "(ALL FILE)|*.*"; // 필터

                        dialog.FilterIndex = 1;// 인덱스 

                        dialog.RestoreDirectory = true; // 최근 열었던 폴더 저장

                        FileStream imgs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);// 그림을 열어줄 FileStream 생성

                        Image img = Image.FromStream(imgs);// 열어준 그림을 담을 Image개체 생성

                        pictureBox9.Image = img;// 저장할 그림을 보여줄 PictureBox에 그림 넣고

                        images[9] = img;

                    }
                    catch (Exception)
                    {
                        pdf_file = dialog.FileName.Substring(dialog.FileName.Length - 3);
                        FILE_TYPES[9] = pdf_file;
                    }
                }
                else
                {
                    MessageBox.Show("지원형식의 파일이 아닙니다.");
                }
            }
            else
            {
                return;
            }

            if (pdf_file == "pdf")
            {
                pictureBox9.Image = Properties.Resources.pdfImage;
            }

            this.pictureBox9.Click += this.pictureBox10_Click;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           SEQ = Convert.ToInt32(this.pictureBox0.Tag);
            txtNameTitle = findTitle(this.pictureBox0.Name);
            AllgroupBoxColor();
            PictuerboxHandler(this.groupBox0.Name, this.groupBox0.BackColor, this.pictureBox0);
            pic = pictureBox0;
            title = txtNameTitle;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SEQ = Convert.ToInt32(this.pictureBox1.Tag);
            txtNameTitle = findTitle(this.pictureBox1.Name);
            AllgroupBoxColor();
            PictuerboxHandler(this.groupBox1.Name ,this.groupBox1.BackColor  ,this.pictureBox1);
            pic = pictureBox1;
            title = txtNameTitle;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SEQ = Convert.ToInt32(this.pictureBox2.Tag);
            txtNameTitle = findTitle(this.pictureBox2.Name);
            AllgroupBoxColor();
            PictuerboxHandler(this.groupBox2.Name, this.groupBox0.BackColor, this.pictureBox2);
            pic = pictureBox2;
            title = txtNameTitle;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SEQ = Convert.ToInt32(this.pictureBox3.Tag);
            txtNameTitle = findTitle(this.pictureBox3.Name);
            AllgroupBoxColor();
            PictuerboxHandler(this.groupBox3.Name, this.groupBox0.BackColor, this.pictureBox3);
            pic = pictureBox3;
            title = txtNameTitle;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SEQ = Convert.ToInt32(this.pictureBox4.Tag);
            txtNameTitle = findTitle(this.pictureBox4.Name);
            AllgroupBoxColor();
            PictuerboxHandler(this.groupBox4.Name, this.groupBox0.BackColor, this.pictureBox4);
            pic = pictureBox4;
            title = txtNameTitle;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            SEQ = Convert.ToInt32(this.pictureBox5.Tag);
            txtNameTitle = findTitle(this.pictureBox5.Name);
            AllgroupBoxColor();
            PictuerboxHandler(this.groupBox5.Name, this.groupBox0.BackColor, this.pictureBox5);
            pic = pictureBox5;
            title = txtNameTitle;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SEQ = Convert.ToInt32(this.pictureBox6.Tag);
            txtNameTitle = findTitle(this.pictureBox6.Name);
            AllgroupBoxColor();
            PictuerboxHandler(this.groupBox6.Name, this.groupBox0.BackColor, this.pictureBox6);
            pic = pictureBox6;
            title = txtNameTitle;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            SEQ = Convert.ToInt32(this.pictureBox7.Tag);
            txtNameTitle = findTitle(this.pictureBox7.Name);
            AllgroupBoxColor();
            PictuerboxHandler(this.groupBox7.Name, this.groupBox0.BackColor, this.pictureBox7);
            pic = pictureBox7;
            title = txtNameTitle;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
           SEQ = Convert.ToInt32(this.pictureBox8.Tag);
            txtNameTitle = findTitle(this.pictureBox8.Name);
            AllgroupBoxColor();
            PictuerboxHandler(this.groupBox8.Name, this.groupBox0.BackColor, this.pictureBox8);
            pic = pictureBox8;
            title = txtNameTitle;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            SEQ = Convert.ToInt32(this.pictureBox9.Tag);
            txtNameTitle = findTitle(this.pictureBox9.Name);
            AllgroupBoxColor();
            PictuerboxHandler(this.groupBox9.Name, this.groupBox0.BackColor, this.pictureBox9);
            pic = pictureBox9;
            title = txtNameTitle;
        }

        private bool chexkFile(string path)
        {
            pic = new PictureBox();

            string pdfName= path.Substring(path.Length - 3);

            try
            {
                pic.Load(path);             
                    return true;
                                 
            }
            catch (ArgumentException ex)
            {              
                return false;
            }
        }

        private bool chexkPDFFile(string path)
        {
            string pdfName = path.Substring(path.Length - 3);

            try
            {
                if(pdfName == "pdf")
                {
                    return true;
                }
                else
                {
                    return false;
                }              
            }
            catch (ArgumentException ex)
            {              
                return false;
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.toolTipDiary.IsBalloon = true;
            this.toolTipDiary.SetToolTip(this.pictureBox0, "나를 더블클릭 해줘!");         
        }

        private void DIARY_Load(object sender, EventArgs e)
        {
            arr[0] = groupBox0;
            arr[1] = groupBox1;
            arr[2] = groupBox2;
            arr[3] = groupBox3;
            arr[4] = groupBox4;
            arr[5] = groupBox5;
            arr[6] = groupBox6;
            arr[7] = groupBox7;
            arr[8] = groupBox8;
            arr[9] = groupBox9;

            pictures[0] = pictureBox0;
            pictures[1] = pictureBox1;
            pictures[2] = pictureBox2;
            pictures[3] = pictureBox3;
            pictures[4] = pictureBox4;
            pictures[5] = pictureBox5;
            pictures[6] = pictureBox6;
            pictures[7] = pictureBox7;
            pictures[8] = pictureBox8;
            pictures[9] = pictureBox9;

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            this.toolTipDiary.IsBalloon = true;
            this.toolTipDiary.SetToolTip(this.pictureBox1, "나를 더블클릭 해줘!");
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            this.toolTipDiary.IsBalloon = true;
            this.toolTipDiary.SetToolTip(this.pictureBox2, "나를 더블클릭 해줘!");
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            this.toolTipDiary.IsBalloon = true;
            this.toolTipDiary.SetToolTip(this.pictureBox3, "나를 더블클릭 해줘!");
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            this.toolTipDiary.IsBalloon = true;
            this.toolTipDiary.SetToolTip(this.pictureBox4, "나를 더블클릭 해줘!");
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            this.toolTipDiary.IsBalloon = true;
            this.toolTipDiary.SetToolTip(this.pictureBox5, "나를 더블클릭 해줘!");
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            this.toolTipDiary.IsBalloon = true;
            this.toolTipDiary.SetToolTip(this.pictureBox6, "나를 더블클릭 해줘!");
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            this.toolTipDiary.IsBalloon = true;
            this.toolTipDiary.SetToolTip(this.pictureBox7, "나를 더블클릭 해줘!");
        }

        private void pictureBox9_MouseHover(object sender, EventArgs e)
        {
            this.toolTipDiary.IsBalloon = true;
            this.toolTipDiary.SetToolTip(this.pictureBox8, "나를 더블클릭 해줘!");
        }

        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            this.toolTipDiary.IsBalloon = true;
            this.toolTipDiary.SetToolTip(this.pictureBox9, "나를 더블클릭 해줘!");
        }

    
        private void SearchPic()
        {
            try
            {
                int sqe = 0;
                sqe = Convert.ToInt32(SEQ);
      
                
                if (MessageBox.Show("선택하신 정보를 확대 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (FILE_TYPES[SEQ]==null && images[SEQ] != null)
                    {                      
                        ImageScreen imageScreen = new ImageScreen();

                        //imagePath = FILE_NAMES[SEQ].ToString();

                        selectimage = images[SEQ];

                        imageScreen.ShowDialog();
                    }
                    else if (FILE_TYPES[SEQ].ToString() == "pdf" || FILE_NAMES[SEQ].ToString().Substring(FILE_NAMES[SEQ].ToString().Length - 3) == "pdf")
                    {
                        PDFScreen pdfScreen = new PDFScreen();

                        PDFPath = FILE_NAMES[SEQ].ToString();

                        pdfScreen.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("파일이 없습니다.");                      
                    }              
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("다시 확인해주세요.");             
            }
        }

        public string findTitle(string groupName)
        {
            string num = this.Controls.Find(groupName, true)[0].Name.ToString();
            string lastnum = num.Substring(num.Length - 1);

            string title = string.Empty;

            title = this.Controls.Find(("txtName" + lastnum).Trim(), true)[0].Text.ToString();

            return title;
        }

   
        private void AllgroupBoxColor()
        {
            groupBox0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            groupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            groupBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            groupBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            groupBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
        }

        public override void P_RowAdd()
        {
            AddGroupBox();
        }

        public override void P_RowDel()
        {
            DelGroupBox();
        }


        private void AddGroupBox()
        {        
            string selectGroupBox = AddCheck(groupBox0, groupBox1, groupBox2, groupBox3, groupBox4
                , groupBox5, groupBox6, groupBox7, groupBox8, groupBox9);

            ShowGroupBox(selectGroupBox);
        }

        private void DelGroupBox()
        {
            string selectGroupBox = DelCheck(groupBox0, groupBox1, groupBox2, groupBox3, groupBox4
                , groupBox5, groupBox6, groupBox7, groupBox8, groupBox9);

            HideGroupBox(selectGroupBox);
        }



        private string AddCheck(GroupBox gru0, GroupBox gru1, GroupBox gru2, GroupBox gru3, GroupBox gru4
                                , GroupBox gru5, GroupBox gru6, GroupBox gru7, GroupBox gru8, GroupBox gru9) //비지블 아닌 그룹박스 이름을 리턴하고 
        {        
           

            string Name = string.Empty;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Visible == false)
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
                this.Controls.Find(groupBoxName, true)[0].Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("더 이상 생성할 수 없습니다.");
            }
        }

        private void HideGroupBox(string groupBoxName)
        {
            byte[] imageData = new Byte[0];
            try
            {
                string num = groupBoxName.Substring(groupBoxName.Length - 1);
                int sqe = Convert.ToInt32(groupBoxName.Substring(groupBoxName.Length - 1));
                string lblName = "txtName" + num.Trim();
                string picture = "pictureBox" + num.Trim();

                switch (sqe)
                {
                    case 0:
                        pictureBox0.Image = null; 
                        break;

                    case 1:
                        pictureBox1.Image = null;
                        break;

                    case 2:
                        pictureBox2.Image = null;
                        break;

                    case 3:
                        pictureBox3.Image = null;
                        break;

                    case 4:
                        pictureBox4.Image = null;
                        break;

                    case 5:
                        pictureBox5.Image = null;
                        break;

                    case 6:
                        pictureBox6.Image = null;
                        break;

                    case 7:
                        pictureBox7.Image = null;
                        break;

                    case 8:
                        pictureBox8.Image = null;
                        break;                   

                    case 9:
                        pictureBox9.Image = null;
                        break;

                    default:
                        break;
                }

                try
                {
                    this.Controls.Find(groupBoxName, true)[0].Visible = false;
                    FILE_NAMES[sqe] = string.Empty;
                    this.Controls.Find(lblName, true)[0].Text = "";
                    FILE_TYPES[sqe] = string.Empty;                   

                }
                catch (Exception)
                {
                    pictureBox0.Load("");
                    txtName0.Text = "";
                    FILE_NAMES[0] = string.Empty;                  
                }
            }
            catch (Exception)
            {
                MessageBox.Show("더 이상 삭제할 수 없습니다.");
            }

        }

        private string DelCheck(GroupBox gru0, GroupBox gru1, GroupBox gru2, GroupBox gru3, GroupBox gru4
                                , GroupBox gru5, GroupBox gru6, GroupBox gru7, GroupBox gru8, GroupBox gru9) //비지블 아닌 그룹박스 이름을 리턴하고 
        {
            

            string Name = string.Empty;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i].Visible == true)
                {
                    Name = arr[i].Name.ToString();
                    break;
                }
            }
            return Name;
        }



        private bool SaveData()   
        {
            byte[] imageData = new Byte[0];
            if (MessageBox.Show("저장 하시겠습니까?", "저장", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return false;
            }
            try
            {    
                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();
                //Set Procedure Name
                dbhandle.ProcedureName = "DIARY_C";
                //Create parameter lists.
                ArrayList param = new ArrayList();
                param.Add(new ParamList("IN_FUNC", "C", 10));          
                param.Add(new ParamList("IN_USER_ID", UserInfo.User_ID, 20));

                param.Add(new ParamList("IN_SELECT_IMAGE", imageData, -1));
                param.Add(new ParamList("IN_TEXT", string.Empty, 20));

                //파라미터 추가
                param.Add(new ParamList("IN_TITLE0", txtName0.Text.Trim(), 30));
                param.Add(new ParamList("IN_TITLE1", txtName1.Text.Trim(), 30));
                param.Add(new ParamList("IN_TITLE2", txtName2.Text.Trim(), 30));
                param.Add(new ParamList("IN_TITLE3", txtName3.Text.Trim(), 30));
                param.Add(new ParamList("IN_TITLE4", txtName4.Text.Trim(), 30));
                param.Add(new ParamList("IN_TITLE5", txtName5.Text.Trim(), 30));
                param.Add(new ParamList("IN_TITLE6", txtName6.Text.Trim(), 30));
                param.Add(new ParamList("IN_TITLE7", txtName7.Text.Trim(), 30));
                param.Add(new ParamList("IN_TITLE8", txtName8.Text.Trim(), 30));
                param.Add(new ParamList("IN_TITLE9", txtName9.Text.Trim(), 30));

                if (pictureBox0.Image != null)
                {
                    param.Add(new ParamList("IN_IMAGE0", EtcUtil.imageToByteArray(pictureBox0.Image), -1));
                }
                else
                {
                    param.Add(new ParamList("IN_IMAGE0", imageData, -1));                   
                }

                if (pictureBox1.Image != null)
                {
                    param.Add(new ParamList("IN_IMAGE1", EtcUtil.imageToByteArray(pictureBox1.Image), -1));
                }
                else
                {
                    param.Add(new ParamList("IN_IMAGE1", imageData, -1));
                }

                if (pictureBox2.Image != null)
                {
                    param.Add(new ParamList("IN_IMAGE2", EtcUtil.imageToByteArray(pictureBox2.Image), -1));
                }
                else
                {
                    param.Add(new ParamList("IN_IMAGE2", imageData, -1));
                }

                if (pictureBox3.Image != null)
                {
                    param.Add(new ParamList("IN_IMAGE3", EtcUtil.imageToByteArray(pictureBox3.Image), -1));
                }
                else
                {
                    param.Add(new ParamList("IN_IMAGE3", imageData, -1));
                }


                if (pictureBox4.Image != null)
                {
                    param.Add(new ParamList("IN_IMAGE4", EtcUtil.imageToByteArray(pictureBox4.Image), -1));
                }
                else
                {
                    param.Add(new ParamList("IN_IMAGE4", imageData, -1));
                }

                if (pictureBox5.Image != null)
                {
                    param.Add(new ParamList("IN_IMAGE5", EtcUtil.imageToByteArray(pictureBox5.Image), -1));
                }
                else
                {
                    param.Add(new ParamList("IN_IMAGE5", imageData, -1));
                }


                if (pictureBox6.Image != null)
                {
                    param.Add(new ParamList("IN_IMAGE6", EtcUtil.imageToByteArray(pictureBox6.Image), -1));
                }
                else
                {
                    param.Add(new ParamList("IN_IMAGE6", imageData, -1));
                }


                if (pictureBox7.Image != null)
                {
                    param.Add(new ParamList("IN_IMAGE7", EtcUtil.imageToByteArray(pictureBox7.Image), -1));
                }
                else
                {
                    param.Add(new ParamList("IN_IMAGE7", imageData, -1));
                }

                if (pictureBox8.Image != null)
                {
                    param.Add(new ParamList("IN_IMAGE8", EtcUtil.imageToByteArray(pictureBox8.Image), -1));
                }
                else
                {
                    param.Add(new ParamList("IN_IMAGE8", imageData, -1));
                }

                if (pictureBox9.Image != null)
                {
                    param.Add(new ParamList("IN_IMAGE9", EtcUtil.imageToByteArray(pictureBox9.Image), -1));
                }
                else
                {
                    param.Add(new ParamList("IN_IMAGE9", imageData, -1));                 
                }


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


        private bool SearchInspList() // 이미지 조회 프로시저 
        {
            byte[] imageData0 = new byte[0];
            byte[] imageData1 = new byte[0];
            byte[] imageData2 = new byte[0];
            byte[] imageData3 = new byte[0];
            byte[] imageData4 = new byte[0];
            byte[] imageData5 = new byte[0];
            byte[] imageData6 = new byte[0];
            byte[] imageData7 = new byte[0];
            byte[] imageData8 = new byte[0];
            byte[] imageData9 = new byte[0];
            try
            {
                //Create DB handle object.
                DBHandler dbhandle = new DBHandler();
                //Set Procedure Name
                dbhandle.ProcedureName = "DIARY_R";
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
                    txtName0.Text = hmDT.Rows[0]["TITLE0"].ToString().Trim();
                    txtName1.Text = hmDT.Rows[0]["TITLE1"].ToString().Trim();
                    txtName2.Text = hmDT.Rows[0]["TITLE2"].ToString().Trim();
                    txtName3.Text = hmDT.Rows[0]["TITLE3"].ToString().Trim();
                    txtName4.Text = hmDT.Rows[0]["TITLE4"].ToString().Trim();
                    txtName5.Text = hmDT.Rows[0]["TITLE5"].ToString().Trim();
                    txtName6.Text = hmDT.Rows[0]["TITLE6"].ToString().Trim();
                    txtName7.Text = hmDT.Rows[0]["TITLE7"].ToString().Trim();
                    txtName8.Text = hmDT.Rows[0]["TITLE8"].ToString().Trim();
                    txtName9.Text = hmDT.Rows[0]["TITLE9"].ToString().Trim();
                                   

                    if (hmDT.Rows[0]["IMAGE0"].ToString().Length > 2)
                    {
                        try
                        {
                            imageData0 = (byte[])(hmDT.Rows[0]["IMAGE0"]);
                            pictureBox0.Image = EtcUtil.byteArrayToImage(imageData0);
                            images[0] = EtcUtil.byteArrayToImage(imageData0);
                        }
                        catch (Exception)
                        {            
                        }
                                            
                    }
                    else
                    {
                        pictureBox0.Image = null;
                    }

                    if (hmDT.Rows[0]["IMAGE1"].ToString().Length >2)
                    {
                        try
                        {
                            imageData1 = (byte[])(hmDT.Rows[0]["IMAGE1"]);
                            pictureBox1.Image = EtcUtil.byteArrayToImage(imageData1);
                            images[1] = EtcUtil.byteArrayToImage(imageData1);
                        }
                        catch (Exception)
                        {                      
                        }
                        
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }

                    if (hmDT.Rows[0]["IMAGE2"].ToString().Length > 2)
                    {
                        try
                        {
                            imageData2 = (byte[])(hmDT.Rows[0]["IMAGE2"]);
                            pictureBox2.Image = EtcUtil.byteArrayToImage(imageData2);
                            images[2] = EtcUtil.byteArrayToImage(imageData2);
                        }
                        catch (Exception)
                        {                     
                        }                      
                    }
                    else
                    {
                        pictureBox2.Image = null;
                    }



                    if (hmDT.Rows[0]["IMAGE3"].ToString().Length > 2)
                    {
                        try
                        {
                            imageData3 = (byte[])(hmDT.Rows[0]["IMAGE3"]);
                            pictureBox3.Image = EtcUtil.byteArrayToImage(imageData3);
                            images[3] = EtcUtil.byteArrayToImage(imageData3);
                        }
                        catch (Exception)
                        {                 
                        }                      
                    }
                    else
                    {
                        pictureBox3.Image = null;
                    }

                    if (hmDT.Rows[0]["IMAGE4"].ToString().Length > 2)
                    {
                        try
                        {
                            imageData4 = (byte[])(hmDT.Rows[0]["IMAGE4"]);
                            pictureBox4.Image = EtcUtil.byteArrayToImage(imageData4);
                            images[4] = EtcUtil.byteArrayToImage(imageData4);

                        }
                        catch (Exception)
                        {               
                        }
                        
                    }
                    else
                    {
                        pictureBox4.Image = null;
                    }

                    if (hmDT.Rows[0]["IMAGE5"].ToString().Length > 2)
                    {
                        try
                        {
                            imageData5 = (byte[])(hmDT.Rows[0]["IMAGE5"]);
                            pictureBox5.Image = EtcUtil.byteArrayToImage(imageData5);
                            images[5] = EtcUtil.byteArrayToImage(imageData5);
                        }
                        catch (Exception)
                        {                   
                        }
                       
                    }
                    else
                    {
                        pictureBox5.Image = null;
                    }

                    if (hmDT.Rows[0]["IMAGE6"].ToString().Length > 2)
                    {
                        try
                        {
                            imageData6 = (byte[])(hmDT.Rows[0]["IMAGE6"]);
                            pictureBox6.Image = EtcUtil.byteArrayToImage(imageData6);
                            images[6] = EtcUtil.byteArrayToImage(imageData6);
                        }
                        catch (Exception)
                        {
                        }                    
                    }
                    else
                    {
                        pictureBox6.Image = null;
                    }

                    if (hmDT.Rows[0]["IMAGE7"].ToString().Length > 2)
                    {
                        try
                        {
                            imageData7 = (byte[])(hmDT.Rows[0]["IMAGE7"]);
                            pictureBox7.Image = EtcUtil.byteArrayToImage(imageData7);
                            images[7] = EtcUtil.byteArrayToImage(imageData7);
                        }
                        catch (Exception)
                        {
                        }                       
                    }
                    else
                    {
                        pictureBox7.Image = null;
                    }

                    if (hmDT.Rows[0]["IMAGE8"].ToString().Length > 2)
                    {
                        try
                        {
                            imageData8 = (byte[])(hmDT.Rows[0]["IMAGE8"]);
                            pictureBox8.Image = EtcUtil.byteArrayToImage(imageData8);
                            images[8] = EtcUtil.byteArrayToImage(imageData8);
                        }
                        catch (Exception)
                        {
                        }
                        
                    }
                    else
                    {
                        pictureBox8.Image = null;
                    }

                    if (hmDT.Rows[0]["IMAGE9"].ToString().Length > 5)
                    {
                        try
                        {
                            imageData9 = (byte[])(hmDT.Rows[0]["IMAGE9"]);
                            pictureBox9.Image = EtcUtil.byteArrayToImage(imageData9);
                            images[9] = EtcUtil.byteArrayToImage(imageData9);
                        }
                        catch (Exception)
                        {                         
                        }                       
                    }
                    else
                    {
                        pictureBox9.Image = null;
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



        public override void P_Save()
        {
            MakeArrNull();
            if (SaveData())
            {                
                SearchInspList();             
            }
        }


        public override void P_ReadDBInfo()
        {        
            SearchInspList();
        }

        public override void P_New()
        {
            SearchPic();
        }

        public override void P_Del()
        {
            DELETE_IMAGE(pic , SEQ);
        }


        private void DELETE_IMAGE(PictureBox pic, int seq) // 스캔 데이터 저장 프로시저
        {
            string SEQ = seq.ToString();
            string txtName = "txtName" + SEQ.Trim();
            if (MessageBox.Show("삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            else
            {
                Controls.Find(txtName, true)[0].Text = string.Empty;
                pic.Image = null;
                SaveData();
            }
        }


        private void MakeArrNull()
        {
            for (int i = 0; i < FILE_TYPES.Length; i++)
            {
                FILE_TYPES[i] = null;

                if(FILE_NAMES[i] != null)
                {
                    images[i] = null;
                    break;
                }
            }
        }



    }
}
