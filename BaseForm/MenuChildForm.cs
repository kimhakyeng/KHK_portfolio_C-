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
using WeifenLuo.WinFormsUI.Docking;

namespace KHK_portfolio
{
    public delegate void PictureBoxClickEvetnHandler(string groupBoxName, Color groupColor, PictureBox picture);
    public partial class MenuChildForm : DockContent
    {
        PictureBox pic;

        public MenuChildForm()
        {
            InitializeComponent();
            pic = new PictureBox();
        }

        private string diary_string = string.Empty;

        public string DIARY_string
        {
            get { return diary_string; }
            set { diary_string = value; }
        }

        private string picturebox = string.Empty;

        public string  PICTUERBOX_NAME
        {
            get { return picturebox; }
            set { picturebox = value; }
        }

        public virtual void P_ReadDBInfo()
        {
            MessageBox.Show(this.Name + " 조회 기능이 없습니다.");
        }

        public virtual void P_New()
        {
            MessageBox.Show(this.Name + " 신규 기능이 없습니다.");
        }

        public virtual void P_Save()
        {
            MessageBox.Show(this.Name + " 저장 기능이 없습니다.");
        }

        public virtual void P_Del()
        {
            MessageBox.Show(this.Name + " 삭제 기능이 없습니다.");
        }

        public virtual void P_RowAdd()
        {
            MessageBox.Show(this.Name + " 행추가 기능이 없습니다.");
        }

        public virtual void P_RowDel()
        {
            MessageBox.Show(this.Name + " 행삭제 기능이 없습니다.");
        }


        protected void PB_COMMON(string ActiveFormName, string FunctionName, string scanData) // 여기로 받아오는거지 툴바 이벤트를 
        {
            if (ActiveFormName != this.Name) { return; }

            switch (FunctionName)
            {
                case Global.Buttonoverride.g_BtnSearch:
                    P_ReadDBInfo();
                    break;
                case Global.Buttonoverride.g_BtnNew:
                    P_New();
                    break;
                case Global.Buttonoverride.g_BtnSave:
                    P_Save();
                    break;
                case Global.Buttonoverride.g_BtnDel:
                    P_Del();
                    break;
                case Global.Buttonoverride.g_BtnRowAdd:
                    P_RowAdd();
                    break;
                case Global.Buttonoverride.g_BtnRowDel:
                    P_RowDel();
                    break;
                
            }
        }

        private void ButtonFnc(FormEventString ToolbarFlag)
        {
            switch (ToolbarFlag)
            {
                case FormEventString.LOAD:
                    MainForm.ToolBarButtonClick += new ToolBarButtonClickHandler(this.PB_COMMON);//메인의 툴바 버튼을 클릭하면 
                    break;

                case FormEventString.CLOSING:
                    MainForm.ToolBarButtonClick -= new ToolBarButtonClickHandler(this.PB_COMMON);
                    break;

                default:
                    break;
            }
        }

        private void MenuChildForm_Load(object sender, EventArgs e)
        {
            ButtonFnc(FormEventString.LOAD);
            SetColor();
        }
        private void SetColor()
        {
            DIARY.PictuerboxHandler += new PictureBoxClickEvetnHandler(GetColor);
        }
          

        private void GetColor(string groupBoxName, Color group, PictureBox picture)
        {
            try
            {            
                Controls.Find(groupBoxName, true)[0].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                pic = picture;
            }
            catch (Exception)
            {
            }    
        }

       

    }
}
