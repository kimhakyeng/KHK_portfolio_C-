
namespace KHK_portfolio
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ConfigMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dB연결ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그아웃ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.bSearch = new System.Windows.Forms.ToolStripButton();
            this.bSave = new System.Windows.Forms.ToolStripButton();
            this.bDel = new System.Windows.Forms.ToolStripButton();
            this.bNew = new System.Windows.Forms.ToolStripButton();
            this.bRowDel = new System.Windows.Forms.ToolStripButton();
            this.bRowAdd = new System.Windows.Forms.ToolStripButton();
            this.pnlMenu = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.모두닫기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectClose = new System.Windows.Forms.ToolStripMenuItem();
            this.로그아웃ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(216)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConfigMenu,
            this.로그아웃ToolStripMenuItem,
            this.로그아웃ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1263, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ConfigMenu
            // 
            this.ConfigMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dB연결ToolStripMenuItem});
            this.ConfigMenu.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.ConfigMenu.ForeColor = System.Drawing.Color.White;
            this.ConfigMenu.Name = "ConfigMenu";
            this.ConfigMenu.Size = new System.Drawing.Size(72, 21);
            this.ConfigMenu.Text = "환경설정";
            // 
            // dB연결ToolStripMenuItem
            // 
            this.dB연결ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(216)))));
            this.dB연결ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.dB연결ToolStripMenuItem.Name = "dB연결ToolStripMenuItem";
            this.dB연결ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dB연결ToolStripMenuItem.Text = "DB연결";
            this.dB연결ToolStripMenuItem.Click += new System.EventHandler(this.dB연결ToolStripMenuItem_Click);
            // 
            // 로그아웃ToolStripMenuItem
            // 
            this.로그아웃ToolStripMenuItem.Name = "로그아웃ToolStripMenuItem";
            this.로그아웃ToolStripMenuItem.Size = new System.Drawing.Size(12, 21);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(60, 60);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bSearch,
            this.bSave,
            this.bDel,
            this.bNew,
            this.bRowDel,
            this.bRowAdd});
            this.toolStrip.Location = new System.Drawing.Point(0, 25);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1263, 53);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "ToolStrip";
            // 
            // bSearch
            // 
            this.bSearch.AutoSize = false;
            this.bSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bSearch.Image = global::KHK_portfolio.Properties.Resources.BTN_SEARCH2;
            this.bSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(50, 50);
            this.bSearch.Text = "조회";
            this.bSearch.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // bSave
            // 
            this.bSave.AutoSize = false;
            this.bSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bSave.Image = global::KHK_portfolio.Properties.Resources.BTN_SAVE2;
            this.bSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(50, 50);
            this.bSave.Text = "저장";
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bDel
            // 
            this.bDel.AutoSize = false;
            this.bDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bDel.Image = global::KHK_portfolio.Properties.Resources.BTN_DELETE2;
            this.bDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(50, 50);
            this.bDel.Text = "지우기";
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bNew
            // 
            this.bNew.AutoSize = false;
            this.bNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bNew.Image = global::KHK_portfolio.Properties.Resources.BTN_NEW2;
            this.bNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(50, 50);
            this.bNew.Text = "신규";
            this.bNew.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bRowDel
            // 
            this.bRowDel.AutoSize = false;
            this.bRowDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bRowDel.Image = global::KHK_portfolio.Properties.Resources.BTN_MINUS2;
            this.bRowDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRowDel.Name = "bRowDel";
            this.bRowDel.Size = new System.Drawing.Size(50, 50);
            this.bRowDel.Text = "지우기";
            this.bRowDel.Click += new System.EventHandler(this.bRowDel_Click);
            // 
            // bRowAdd
            // 
            this.bRowAdd.AutoSize = false;
            this.bRowAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bRowAdd.Image = global::KHK_portfolio.Properties.Resources.BTN_PLUS2;
            this.bRowAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRowAdd.Name = "bRowAdd";
            this.bRowAdd.Size = new System.Drawing.Size(50, 50);
            this.bRowAdd.Text = "추가하기";
            this.bRowAdd.Click += new System.EventHandler(this.bRowAdd_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.ActiveAutoHideContent = null;
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            this.pnlMenu.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlMenu.ForeColor = System.Drawing.Color.Black;
            this.pnlMenu.Location = new System.Drawing.Point(0, 78);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1263, 472);
            dockPanelGradient1.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            dockPanelGradient1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            tabGradient1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            tabGradient1.TextColor = System.Drawing.Color.Black;
            autoHideStripSkin1.TabGradient = tabGradient1;
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(58)))), ((int)(((byte)(180)))));
            tabGradient2.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(53)))), ((int)(((byte)(132)))));
            tabGradient2.TextColor = System.Drawing.Color.White;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            dockPanelGradient2.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            tabGradient3.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            tabGradient3.TextColor = System.Drawing.Color.Black;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            tabGradient4.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(81)))), ((int)(((byte)(216)))));
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(230)))));
            tabGradient4.TextColor = System.Drawing.Color.Red;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            tabGradient5.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            tabGradient5.TextColor = System.Drawing.Color.Black;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            dockPanelGradient3.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(81)))), ((int)(((byte)(216)))));
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(230)))));
            tabGradient6.TextColor = System.Drawing.Color.Red;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            tabGradient7.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            tabGradient7.TextColor = System.Drawing.Color.Black;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.pnlMenu.Skin = dockPanelSkin1;
            this.pnlMenu.TabIndex = 15;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(0, 78);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 472);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "메뉴";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseHover += new System.EventHandler(this.btnSearch_MouseHover);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(55)))), ((int)(((byte)(77)))));
            this.contextMenuStrip1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.모두닫기ToolStripMenuItem,
            this.SelectClose});
            this.contextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 48);
            // 
            // 모두닫기ToolStripMenuItem
            // 
            this.모두닫기ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.모두닫기ToolStripMenuItem.Name = "모두닫기ToolStripMenuItem";
            this.모두닫기ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.모두닫기ToolStripMenuItem.Text = "탭 모두 닫기";
            this.모두닫기ToolStripMenuItem.Click += new System.EventHandler(this.모두닫기ToolStripMenuItem_Click);
            // 
            // SelectClose
            // 
            this.SelectClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.SelectClose.ForeColor = System.Drawing.Color.White;
            this.SelectClose.Name = "SelectClose";
            this.SelectClose.Size = new System.Drawing.Size(182, 22);
            this.SelectClose.Text = "이 창 제외 전부닫기";
            this.SelectClose.Click += new System.EventHandler(this.SelectClose_Click);
            // 
            // 로그아웃ToolStripMenuItem1
            // 
            this.로그아웃ToolStripMenuItem1.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.로그아웃ToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.로그아웃ToolStripMenuItem1.Name = "로그아웃ToolStripMenuItem1";
            this.로그아웃ToolStripMenuItem1.Size = new System.Drawing.Size(72, 21);
            this.로그아웃ToolStripMenuItem1.Text = "로그아웃";
            this.로그아웃ToolStripMenuItem1.Click += new System.EventHandler(this.로그아웃ToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 550);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Portfolio";
            this.Load += new System.EventHandler(this.MainFrom_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private WeifenLuo.WinFormsUI.Docking.DockPanel pnlMenu;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripButton bSearch;
        private System.Windows.Forms.ToolStripButton bSave;
        private System.Windows.Forms.ToolStripButton bNew;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 모두닫기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectClose;
        private System.Windows.Forms.ToolStripButton bRowAdd;
        private System.Windows.Forms.ToolStripButton bRowDel;
        private System.Windows.Forms.ToolStripMenuItem 로그아웃ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConfigMenu;
        private System.Windows.Forms.ToolStripMenuItem dB연결ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton bDel;
        private System.Windows.Forms.ToolStripMenuItem 로그아웃ToolStripMenuItem1;
    }
}

