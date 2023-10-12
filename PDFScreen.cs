using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHK_portfolio
{
    public partial class PDFScreen : Form
    {
        private  string PDFFileName = string.Empty;
        
        public PDFScreen()
        {
            InitializeComponent();          
        }
        DIARY diary;
        private void PDFScreen_Load(object sender, EventArgs e)
        {
            diary = new DIARY();
            PDFFileName = diary.PDF_PATH;
            try
            {
                axAcroPDF1.LoadFile(PDFFileName); // 여기에 다이어리 파일경로를 받아오면 된다.    
            }
            catch (Exception)
            {
                axAcroPDF1.Dispose();
            }
        }

       
    }
}
