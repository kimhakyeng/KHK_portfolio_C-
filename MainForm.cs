using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;

using System.Data.Common;
using System.Threading;
using System.IO;
using WeifenLuo.WinFormsUI.Docking; //도킹
using System.Net;


namespace KHK_portfolio
{
    public partial class MainForm : Form
    {
        private string assemblyName = "KHK_portfolio"; // 전역변수
        private string MainMESName = "KHK_portfolio - ( ver " + Application.ProductVersion.ToString().Trim() + " )";
        private string ActiveFormCode = string.Empty;

        public delegate void MenuClickHandler(string progID, string progName );  //이건 아니다.

        public delegate void DiaryClickHandler(string sqe);

        public static event ToolBarButtonClickHandler ToolBarButtonClick;  // 화면 정보랑 이름을 이벤트로 받아서

        
        //좌측 메뉴관련
        public enum MenuFix
        {
            Fix,
            None
        }

        public static MenuFix menuFix = MenuFix.None;

        public MainForm()
        {
            InitializeComponent();

            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new ControlClass.MenuColorTable(Color.FromArgb(59, 62, 77), Color.DimGray));

            menuForm = new frmMenu();
            menuForm.Show(pnlMenu,DockState.DockLeftAutoHide);

            diaryForm = new DIARY();
            
        }
        frmMenu menuForm;
        DIARY diaryForm;



        private void MainFrom_Load(object sender, EventArgs e)
        {
            P_Login();

            this.WindowState = FormWindowState.Maximized;
     
            frmMenu.menuClickEvent += new MenuClickHandler(ButtonClickEvent);       
        }

        //메뉴 열리고 닫히고 하게 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (menuFix == MenuFix.None)
            {
                menuFix = MenuFix.Fix;
                //menuForm.Show(pnlMenu, DockState.DockLeftAutoHide);
            }
            else
            {
                menuFix = MenuFix.Fix;             
            }
            
        }

        //화면 찾는 함수
        public IDockContent FindDocument(string text)
        {
            IDockContent[] dc = pnlMenu.DocumentsToArray();

            for (int inx = 0; inx < dc.Length; inx++)
            {
                IDockContent dc2 = dc[inx];

                if (dc2.DockHandler.Form.Name == text)
                {
                    return dc2;
                }
            }

            return null;
        }

        //이벤트 만들고
        public void ButtonClickEvent(string progID, string progName ) //화면 열리게 만들어야하는 코드
        {
            try
            {
                IDockContent dc = FindDocument(progID);

                if(dc == null)
                {
                    System.Type type = System.Type.GetType(assemblyName + "." + progID);

                    if (type == null)
                    {
                        MessageBox.Show("해당 화면이 존재하지 않습니다.");
                        return;
                    }
                    else
                    {
                        DockContent dockContent = (DockContent)System.Activator.CreateInstance(type);

                        try
                        {
                            dockContent.Tag = dockContent.Name;
                            dockContent.TabText = progName;
                            dockContent.ShowHint = DockState.Document;
                            dockContent.TabPageContextMenuStrip = contextMenuStrip1;                        
                            dockContent.MdiParent = this;
                            dockContent.Show(pnlMenu);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            throw;
                        }
                    }
                }
                else
                {
                    dc.DockHandler.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e) // 조회 버튼을 누를때마다 show 로 보여주자 
        {
           
            ToolStripButton tsb = new ToolStripButton(); //툴바이벤트
            tsb = (ToolStripButton)sender;

            if (pnlMenu.DocumentsCount <= 0 && tsb.Name == Global.Buttonoverride.g_BtnClose)
            {
                Application.Exit();
            }
            else
            {
                IDockContent dc = pnlMenu.ActiveDocument;

                switch (tsb.Name)
                {
                    case Global.Buttonoverride.g_BtnClose:
                        //화면 종료
                        dc.DockHandler.Close();
                        dc.DockHandler.Dispose();

                        break;
                    default:
                        if (pnlMenu.DocumentsCount > 0)
                        {
                            if (ToolBarButtonClick != null)
                                ToolBarButtonClick(dc.DockHandler.Form.Name, tsb.Name, string.Empty);
                        }
                        else
                        {
                            MessageBox.Show("메뉴는 좌측에 있어요.");
                        }                     
                        break;
                }

            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = new ToolStripButton(); //툴바이벤트
            tsb = (ToolStripButton)sender;

            if (pnlMenu.DocumentsCount <= 0 && tsb.Name == Global.Buttonoverride.g_BtnClose)
            {
                Application.Exit();
            }
            else
            {
                IDockContent dc = pnlMenu.ActiveDocument;

                switch (tsb.Name)
                {
                    case Global.Buttonoverride.g_BtnClose:
                        //화면 종료
                        dc.DockHandler.Close();
                        dc.DockHandler.Dispose();

                        break;
                    default:
                        if (pnlMenu.DocumentsCount > 0)
                        {
                            if (ToolBarButtonClick != null)
                                ToolBarButtonClick(dc.DockHandler.Form.Name, tsb.Name, string.Empty);
                        }
                        else
                        {
                            MessageBox.Show("메뉴는 좌측에 있어요.");
                        }
                        break;
                }

            }

        }

        
        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            if (menuFix == MenuFix.None)
            {
                menuForm.Show(pnlMenu, DockState.DockLeftAutoHide);
                menuFix = MenuFix.None;
            }
            else
            {
                menuForm.Show(pnlMenu, DockState.DockLeftAutoHide);
                menuFix = MenuFix.None;
            }
        }

        private void 모두닫기ToolStripMenuItem_Click(object sender, EventArgs e) // 모두닫기 이벤트
        {
            CloseAllContent(string.Empty);
        }

        public void CloseAllContent(string exceptName)
        {
            IDockContent[] dc = pnlMenu.DocumentsToArray();

            for (int inx = 0; inx < dc.Length; inx++)
            {
                IDockContent dc2 = dc[inx];

                if (dc2.DockHandler.Form.Name != exceptName)
                {
                    dc2.DockHandler.Close();
                    dc2.DockHandler.Dispose();
                }
            }
        }

        private void SelectClose_Click(object sender, EventArgs e)
        {
            IDockContent dc = pnlMenu.ActiveDocument;

            if (dc != null)
            {
                CloseAllContent(dc.DockHandler.Form.Name);
            }
            else
            {
                CloseAllContent(string.Empty);
            }
        }

        private void bRowAdd_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = new ToolStripButton(); //툴바이벤트
            tsb = (ToolStripButton)sender;

            if (pnlMenu.DocumentsCount <= 0 && tsb.Name == Global.Buttonoverride.g_BtnClose)
            {
                Application.Exit();
            }
            else
            {
                IDockContent dc = pnlMenu.ActiveDocument;

                switch (tsb.Name)
                {
                    case Global.Buttonoverride.g_BtnClose:
                        //화면 종료
                        dc.DockHandler.Close();
                        dc.DockHandler.Dispose();

                        break;
                    default:
                        if (pnlMenu.DocumentsCount > 0)
                        {
                            if (ToolBarButtonClick != null)
                                ToolBarButtonClick(dc.DockHandler.Form.Name, tsb.Name, string.Empty);
                        }
                        else
                        {
                            MessageBox.Show("메뉴는 좌측에 있어요.");
                        }
                        break;
                }

            }

        }

        private void bRowDel_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = new ToolStripButton(); //툴바이벤트
            tsb = (ToolStripButton)sender;

            if (pnlMenu.DocumentsCount <= 0 && tsb.Name == Global.Buttonoverride.g_BtnClose)
            {
                Application.Exit();
            }
            else
            {
                IDockContent dc = pnlMenu.ActiveDocument;

                switch (tsb.Name)
                {
                    case Global.Buttonoverride.g_BtnClose:
                        //화면 종료
                        dc.DockHandler.Close();
                        dc.DockHandler.Dispose();

                        break;
                    default:
                        if (pnlMenu.DocumentsCount > 0)
                        {
                            if (ToolBarButtonClick != null)
                                ToolBarButtonClick(dc.DockHandler.Form.Name, tsb.Name, string.Empty);
                        }
                        else
                        {
                            MessageBox.Show("메뉴는 좌측에 있어요.");
                        }
                        break;
                }

            }
        }

        private void dB연결ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config Conflg = new Config();
            Conflg.ShowDialog();
            Conflg.Dispose();
        }

        private void bSave_Click(object sender, EventArgs e)
        {

            ToolStripButton tsb = new ToolStripButton(); //툴바이벤트
            tsb = (ToolStripButton)sender;

            if (pnlMenu.DocumentsCount <= 0 && tsb.Name == Global.Buttonoverride.g_BtnClose)
            {
                Application.Exit();
            }
            else
            {
                IDockContent dc = pnlMenu.ActiveDocument;

                switch (tsb.Name)
                {
                    case Global.Buttonoverride.g_BtnClose:
                        //화면 종료
                        dc.DockHandler.Close();
                        dc.DockHandler.Dispose();

                        break;
                    default:
                        if (pnlMenu.DocumentsCount > 0)
                        {
                            if (ToolBarButtonClick != null)
                                ToolBarButtonClick(dc.DockHandler.Form.Name, tsb.Name, string.Empty);
                        }
                        else
                        {
                            MessageBox.Show("메뉴는 좌측에 있어요.");
                        }
                        break;
                }

            }
        }


        private void P_Login()
        {
            LoginForm Lgn = new LoginForm();
            Lgn.StartPosition = FormStartPosition.CenterScreen;
            Lgn.ShowDialog();
            
            if (Lgn.LoginYN == "Y")
            {
                this.Show();
            }

            Lgn.Close();
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = new ToolStripButton(); //툴바이벤트
            tsb = (ToolStripButton)sender;

            if (pnlMenu.DocumentsCount <= 0 && tsb.Name == Global.Buttonoverride.g_BtnClose)
            {
                Application.Exit();
            }
            else
            {
                IDockContent dc = pnlMenu.ActiveDocument;

                switch (tsb.Name)
                {
                    case Global.Buttonoverride.g_BtnClose:
                        //화면 종료
                        dc.DockHandler.Close();
                        dc.DockHandler.Dispose();

                        break;
                    default:
                        if (pnlMenu.DocumentsCount > 0)
                        {
                            if (ToolBarButtonClick != null)
                                ToolBarButtonClick(dc.DockHandler.Form.Name, tsb.Name, string.Empty);
                        }
                        else
                        {
                            MessageBox.Show("메뉴는 좌측에 있어요.");
                        }
                        break;
                }

            }
        }

        private void 로그아웃ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로그아웃 하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo) != DialogResult.Yes) { return; }

            //다시 접속
            P_Login();
        }
    }
}
