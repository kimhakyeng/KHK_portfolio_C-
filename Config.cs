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
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void btnConnetionDB_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("설정 하시겠습니까?", "설정", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            else
            {
                UserInfo.g_DBIP = txtIP.Text.Trim();
                MessageBox.Show("설정완료");
            }

           
        }

        private void Config_Load(object sender, EventArgs e)
        {
            txtIP.Text = "";
            txtURL.Text = "";
        }
    }
}
