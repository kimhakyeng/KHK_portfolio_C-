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
    public partial class SearchMap : Form
    {
        MYSELF mySelf = new MYSELF();
        public SearchMap()
        {
            InitializeComponent();
        }

        private void SearchMap_Load(object sender, EventArgs e)
        {
            StringBuilder add = new StringBuilder("https://map.naver.com/v5/search/");
            add.Append(mySelf.MyAdress.Trim());

            webBrowser1.Navigate(add.ToString());
        }
    }
}
