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
    public partial class ImageScreen : Form
    {
       
        public ImageScreen()
        {
            InitializeComponent();
            diary = new DIARY();         
        }
        DIARY diary;
      
        private void ImageScreen_Load(object sender, EventArgs e)
        {
            try
            {
                //pictureBox1.Load(diary.IMAGE_PATH.ToString());
                pictureBox1.Image = diary.SELECT_IMAGE;
            }
            catch (Exception)
            {
            }
                   
            textSave();
            imageTitle.Text = diary.NAMETITLE; 
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void textSave()
        {
            DIARY.PictuerboxHandler += new PictureBoxClickEvetnHandler(stringsSet);
        }


        private void stringsSet(string groupBoxName, Color groupBoxColor, PictureBox title)
        {
            string a = groupBoxName;          
        }
    }
}
