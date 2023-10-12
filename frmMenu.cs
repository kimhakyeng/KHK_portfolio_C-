using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking; //도킹
using System.Collections;


namespace KHK_portfolio
{
    public partial class frmMenu : DockContent
    {
        private string buttonName = "";

        public static event KHK_portfolio.MainForm.MenuClickHandler menuClickEvent;

        public string ButtonName
        {
            get { return buttonName; }
            set { buttonName = value; }
        }

        public frmMenu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void btnMyself_Click_1(object sender, EventArgs e)
        {
            menuClickEvent(btnMyself.Tag.ToString(), btnMyself.Text.ToString());
        }

        private void btnDiary_Click(object sender, EventArgs e)
        {
            menuClickEvent(btnDiary.Tag.ToString(), btnDiary.Text.ToString());
        }

        private void btnAbility_Click(object sender, EventArgs e)
        {
            menuClickEvent(btnAbility.Tag.ToString(), btnAbility.Text.ToString());
        }

        private void btnMyhope_Click(object sender, EventArgs e)
        {
            menuClickEvent(btnMyhope.Tag.ToString(), btnMyhope.Text.ToString());
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            NEW_MEMBER frm = new NEW_MEMBER();

           
            frm.StartPosition = FormStartPosition.CenterScreen;
         



            frm.ShowDialog();
            frm.Dispose();
        }
    }
}
