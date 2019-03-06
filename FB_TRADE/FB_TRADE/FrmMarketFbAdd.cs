using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FB_Trade_DAL;
using FB_Trade_Models;

namespace FB_TRADE
{
    public partial class FrmMarketFbAdd : Form
    {
        public bool bAdmin;
        public string curAdminId;
        public string curUserId;

        public FrmMarketFbAdd()
        {
            InitializeComponent();
        }
    }
}
