using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace KHK_portfolio
{
    class ControlClass
    {
        //메뉴 클릭이벤트
        public static event MainForm.MenuClickHandler menuClickEvent;
        //public static event MainForm.MainClickHandler mainClickEvent;

        #region 메뉴버튼 클래스 
        public class MenuButton : Button
        {
            Panel pnl;
            Panel b;

            public MenuButton(string _frmID, string _frmName, LinePanel _pnl)
            {
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
                this.Dock = System.Windows.Forms.DockStyle.Top;
                this.FlatAppearance.BorderSize = 0;
                this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
                this.ForeColor = System.Drawing.Color.Gainsboro;
                this.Name = "btn" + _frmID;
                this.Tag = _frmID;
                this.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
                this.Size = new System.Drawing.Size(300, 45);
                this.Text = _frmName;
                this.TabStop = false;
                this.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.UseVisualStyleBackColor = false;
                this.Click += new System.EventHandler(btnClick);

                this.Location = new Point(0, _pnl.Location.Y + _pnl.Height);
            }

            public MenuButton(string _frmID, string _frmName, SubMenuPanel _pnl)
            {
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
                this.Dock = System.Windows.Forms.DockStyle.Top;
                this.FlatAppearance.BorderSize = 0;
                this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
                this.ForeColor = System.Drawing.Color.Gainsboro;
                this.Name = "btn" + _frmID;
                this.Tag = _frmID;
                this.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
                this.Size = new System.Drawing.Size(300, 45);
                this.Text = _frmName;
                this.TabStop = false;
                this.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.UseVisualStyleBackColor = false;
                this.Click += new System.EventHandler(btnClick);
                this.MouseLeave += new System.EventHandler(btnMouseLeave);

                this.Location = new Point(0, _pnl.Location.Y + _pnl.Height);
                //이미지
                this.Image = global::KHK_portfolio.Properties.Resources.BTN_CLOSE3;
                this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            }

            public void SetPnl(ref SubMenuPanel _pnl, ref LinePanel _b)
            {
                b = _b;
                b.Visible = false;
                pnl = _pnl;
                pnl.Visible = false;
            }

            public void SetPnl(ref SubMenuPanel _pnl)
            {
                pnl = _pnl;
                pnl.Visible = false;
            }

            public void btnClick(object sendor, EventArgs e)
            {
                if (b != null)
                {
                    if (pnl.Visible == true)
                    {
                        b.Visible = false;
                        pnl.Visible = false;
                    }
                    else
                    {
                        b.Visible = true;
                        pnl.Visible = true;
                    }
                }
                else
                {
                    if (pnl.Visible == true)
                    {
                        pnl.Visible = false;
                    }
                    else
                    {
                        //mainClickEvent();
                        pnl.Visible = true;
                    }
                }
            }

            public void btnMouseLeave(object sendor, EventArgs e)
            {
                //mouseLeave();
            }
        }

        public class SubMenuButton : Button
        {
            Panel MainPanel;

            public SubMenuButton(string _frmID, string _frmName)
            {
                //59, 62, 77
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
                this.Dock = System.Windows.Forms.DockStyle.Top;
                this.FlatAppearance.BorderSize = 0;
                this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
                this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
                this.ForeColor = System.Drawing.Color.Gainsboro;
                //this.Location = new System.Drawing.Point(0, 0);
                this.Name = "btn" + _frmID;
                this.Tag = _frmID;
                this.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
                this.Size = new System.Drawing.Size(250, 40);
                this.TabStop = false;
                this.Text = _frmName;
                this.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.UseVisualStyleBackColor = false;
                this.Click += new System.EventHandler(btnClick);
            }

            public SubMenuButton(string _frmID, string _frmName, ref Panel _pnl)
            {
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
                this.Dock = System.Windows.Forms.DockStyle.Top;
                this.FlatAppearance.BorderSize = 0;
                this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
                this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
                this.ForeColor = System.Drawing.Color.Gainsboro;
                //this.Location = new System.Drawing.Point(0, 0);
                this.Name = "btn" + _frmID;
                this.Tag = _frmID;
                this.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
                this.Size = new System.Drawing.Size(250, 40);
                this.TabStop = false;
                this.Text = _frmName;
                this.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.UseVisualStyleBackColor = false;

                //이미지
                this.Image = global::KHK_portfolio.Properties.Resources.INFP;
                this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;

                this.Click += new System.EventHandler(btnClick);

                MainPanel = _pnl;
            }
            public void btnClick(object sendor, EventArgs e)
            {
                menuClickEvent(this.Tag.ToString(), this.Text);

                if (MainPanel != null && MainForm.menuFix == MainForm.MenuFix.None)
                {
                    MainPanel.Visible = false;
                }
            }
        }

        #endregion 

        #region Panel 클래스
        public class SubMenuPanel : Panel
        {
            public SubMenuPanel(string _pnlName, int _Width, int _Height)
            {
                this.TabStop = false;
                this.Dock = System.Windows.Forms.DockStyle.Top;
                this.Name = "pnl" + _pnlName;
                this.Tag = _pnlName;
                this.Size = new System.Drawing.Size(_Width, _Height);
            }

            public SubMenuPanel(string _pnlName, int _Width, int _Height, MenuButton _btn)
            {
                this.TabStop = false;
                this.Dock = System.Windows.Forms.DockStyle.Top;
                this.Name = "pnl" + _pnlName;
                this.Tag = _pnlName;
                this.Size = new System.Drawing.Size(_Width, _Height);

                this.Location = new Point(0, _btn.Location.Y + _btn.Height);
            }
        }

        public class LinePanel : Panel
        {
            public LinePanel(string _pnlName, int _Width, int _Height)
            {
                this.TabStop = false;
                this.Dock = System.Windows.Forms.DockStyle.Top;
                this.Name = "pnlLine" + _pnlName;
                this.Tag = _pnlName;
                this.Size = new System.Drawing.Size(_Width, _Height);
                this.BackColor = System.Drawing.Color.Gray;
            }

            public LinePanel(string _pnlName, int _Width, int _Height, MenuButton _btn)
            {
                this.TabStop = false;
                this.Dock = System.Windows.Forms.DockStyle.Top;
                this.Name = "pnlLine" + _pnlName;
                this.Tag = _pnlName;
                this.Size = new System.Drawing.Size(_Width, _Height);
                this.BackColor = System.Drawing.Color.Gray;

                this.Location = new Point(0, _btn.Location.Y + _btn.Height);
            }
        }

        #endregion 

        #region Menustrip 색상조정
        public class MenuColorTable : ProfessionalColorTable
        {
            Color backcolor;
            Color selected;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="_Backcolor">BackColor</param>
            /// <param name="_Selection">Mouse Over Color</param>
            public MenuColorTable(Color _Backcolor, Color _Selection)
            {
                backcolor = _Backcolor;
                selected = _Selection;
            }
            public override Color ToolStripDropDownBackground
            {
                get
                {
                    return backcolor;
                }
            }

            public override Color ImageMarginGradientBegin
            {
                get
                {
                    return backcolor;
                }
            }

            public override Color ImageMarginGradientMiddle
            {
                get
                {
                    return backcolor;
                }
            }

            public override Color ImageMarginGradientEnd
            {
                get
                {
                    return backcolor;
                }
            }

            public override Color MenuBorder
            {
                get
                {
                    return backcolor;
                }
            }

            public override Color MenuItemBorder
            {
                get
                {
                    return backcolor;
                }
            }

            public override Color MenuItemSelected
            {
                get
                {
                    return selected;
                }
            }

            public override Color MenuStripGradientBegin
            {
                get
                {
                    return backcolor;
                }
            }

            public override Color MenuStripGradientEnd
            {
                get
                {
                    return backcolor;
                }
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get
                {
                    return selected;
                }
            }

            public override Color MenuItemSelectedGradientEnd
            {
                get
                {
                    return selected;
                }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get
                {
                    return backcolor;
                }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get
                {
                    return backcolor;
                }
            }
        }
        #endregion 
    }
}
