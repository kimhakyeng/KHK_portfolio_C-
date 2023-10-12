
namespace KHK_portfolio
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnsettings = new System.Windows.Forms.Button();
            this.btnMyhope = new System.Windows.Forms.Button();
            this.btnDiary = new System.Windows.Forms.Button();
            this.btnAbility = new System.Windows.Forms.Button();
            this.btnMyself = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(243)))));
            this.panel2.Controls.Add(this.pnlNav);
            this.panel2.Controls.Add(this.btnsettings);
            this.panel2.Controls.Add(this.btnMyhope);
            this.panel2.Controls.Add(this.btnDiary);
            this.panel2.Controls.Add(this.btnAbility);
            this.panel2.Controls.Add(this.btnMyself);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 532);
            this.panel2.TabIndex = 8;
            this.panel2.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(81)))), ((int)(((byte)(216)))));
            this.pnlNav.Location = new System.Drawing.Point(0, 178);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(3, 92);
            this.pnlNav.TabIndex = 2;
            // 
            // btnsettings
            // 
            this.btnsettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnsettings.FlatAppearance.BorderSize = 0;
            this.btnsettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsettings.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(175)))), ((int)(((byte)(69)))));
            this.btnsettings.Location = new System.Drawing.Point(0, 493);
            this.btnsettings.Name = "btnsettings";
            this.btnsettings.Size = new System.Drawing.Size(189, 39);
            this.btnsettings.TabIndex = 1;
            this.btnsettings.Text = "회원가입";
            this.btnsettings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnsettings.UseVisualStyleBackColor = true;
            this.btnsettings.Click += new System.EventHandler(this.btnsettings_Click);
            // 
            // btnMyhope
            // 
            this.btnMyhope.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMyhope.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMyhope.FlatAppearance.BorderSize = 0;
            this.btnMyhope.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyhope.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMyhope.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.btnMyhope.Location = new System.Drawing.Point(0, 117);
            this.btnMyhope.Name = "btnMyhope";
            this.btnMyhope.Size = new System.Drawing.Size(189, 39);
            this.btnMyhope.TabIndex = 1;
            this.btnMyhope.Tag = "MYHOPE";
            this.btnMyhope.Text = "비전 및 포부";
            this.btnMyhope.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMyhope.UseVisualStyleBackColor = false;
            this.btnMyhope.Click += new System.EventHandler(this.btnMyhope_Click);
            // 
            // btnDiary
            // 
            this.btnDiary.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDiary.FlatAppearance.BorderSize = 0;
            this.btnDiary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiary.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(36)))), ((int)(((byte)(76)))));
            this.btnDiary.Location = new System.Drawing.Point(0, 78);
            this.btnDiary.Name = "btnDiary";
            this.btnDiary.Size = new System.Drawing.Size(189, 39);
            this.btnDiary.TabIndex = 1;
            this.btnDiary.Tag = "DIARY";
            this.btnDiary.Text = "다이어리";
            this.btnDiary.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDiary.UseVisualStyleBackColor = true;
            this.btnDiary.Click += new System.EventHandler(this.btnDiary_Click);
            // 
            // btnAbility
            // 
            this.btnAbility.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAbility.FlatAppearance.BorderSize = 0;
            this.btnAbility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbility.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbility.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(48)))), ((int)(((byte)(108)))));
            this.btnAbility.Location = new System.Drawing.Point(0, 39);
            this.btnAbility.Name = "btnAbility";
            this.btnAbility.Size = new System.Drawing.Size(189, 39);
            this.btnAbility.TabIndex = 1;
            this.btnAbility.Tag = "AbilityForm";
            this.btnAbility.Text = "자격 및 역량";
            this.btnAbility.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAbility.UseVisualStyleBackColor = true;
            this.btnAbility.Click += new System.EventHandler(this.btnAbility_Click);
            // 
            // btnMyself
            // 
            this.btnMyself.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMyself.FlatAppearance.BorderSize = 0;
            this.btnMyself.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyself.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyself.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(53)))), ((int)(((byte)(132)))));
            this.btnMyself.Location = new System.Drawing.Point(0, 0);
            this.btnMyself.Name = "btnMyself";
            this.btnMyself.Size = new System.Drawing.Size(189, 39);
            this.btnMyself.TabIndex = 1;
            this.btnMyself.Tag = "MYSELF";
            this.btnMyself.Text = "자기소개";
            this.btnMyself.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMyself.UseVisualStyleBackColor = true;
            this.btnMyself.Click += new System.EventHandler(this.btnMyself_Click_1);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(189, 532);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HideOnClose = true;
            this.Name = "frmMenu";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide;
            this.ShowIcon = false;
            this.TabText = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Button btnsettings;
        private System.Windows.Forms.Button btnMyhope;
        private System.Windows.Forms.Button btnDiary;
        private System.Windows.Forms.Button btnAbility;
        private System.Windows.Forms.Button btnMyself;
    }
}