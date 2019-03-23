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
    public partial class FrmCustomerSearchTool : Form
    {
        public string curMarketFbId;
        public string curMarketFbAccount;
        public FrmMain pFrmMain;
        public bool bAdmin = false;

        private DBCommon db = new DBCommon();
        private StringBuilder sb = new StringBuilder();

        public FrmCustomerSearchTool()
        {
            InitializeComponent();
            MyComponetInit();
        }

        private void MyComponetInit()
        {
            this.btnSearch.Visible = false;

            this.cbxSearchType.Items.Clear();
            this.cbxSearchType.Items.Add("昵称");
            this.cbxSearchType.Items.Add("Facebook ID");
            this.cbxSearchType.Items.Add("Facebook首页链接");
            this.cbxSearchType.Items.Add("意向产品");
            this.cbxSearchType.SelectedIndex = 0;

            this.listViewResult.View = System.Windows.Forms.View.Details;
            this.listViewResult.FullRowSelect = true;
            listViewResult.GridLines = true;

            this.listViewResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewResult_MouseDoubleClick);

            listViewResult.Clear();
            listViewResult.Columns.Add("搜索结果", 800, HorizontalAlignment.Left);
        }

        public void MyFrmInit()
        {
            labelCurMarketAccount.Text = curMarketFbAccount;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                //MessageBox.Show("请输入搜索内容！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                sb.Clear();
                sb.AppendFormat("select top 30 * from tb_fbCustomerShips where marketFbId='{0}'", curMarketFbId);
                if (cbxSearchType.Text == "昵称")
                    sb.AppendFormat(" and customerFbId in (select fbId from tb_fbCustomers where name like '%{0}%')", txtSearch.Text.Trim());
                else if (cbxSearchType.Text == "Facebook ID")
                    sb.AppendFormat(" and customerFbId like '%{0}%'", txtSearch.Text.Trim());
                else if (cbxSearchType.Text == "Facebook首页链接")
                    sb.AppendFormat(" and customerFbId in (select fbId from tb_fbCustomers where fbUrl like '%{0}%')", txtSearch.Text.Trim());
                else if (cbxSearchType.Text == "意向产品")
                    sb.AppendFormat(" and interestedGoods like '%{0}%'", txtSearch.Text.Trim());

                List<FbCustomerShipInfo> shipList = (List<FbCustomerShipInfo>)db.GetList(sb.ToString(), "tb_fbCustomerShips");

                listViewResult.Items.Clear();
                foreach (var ship in shipList)
                {
                    ListViewItem it = new ListViewItem();

                    sb.Clear();
                    sb.AppendFormat("select * from tb_fbCustomers where fbId='{0}'", ship.customerFbId);
                    FbCustomerInfo customer = (FbCustomerInfo)db.GetObject(sb.ToString(), "tb_fbCustomers");

                    string result = "[" + customer.fbId + "]" + customer.name + ": ";
                    if (cbxSearchType.Text == "昵称")
                        result += customer.name;
                    else if (cbxSearchType.Text == "Facebook ID")
                        result += customer.fbId;
                    else if (cbxSearchType.Text == "Facebook首页链接")
                        result += customer.fbUrl;
                    else if (cbxSearchType.Text == "意向产品")
                        result += ship.interestedGoods;

                    it.Text = result;
                    listViewResult.Items.Add(it);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "数据库异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "程序异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = this.listViewResult.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                FrmCustomerAdd frm = new FrmCustomerAdd();
                this.pFrmMain.AddPage(frm, "编辑客户");

                string customerFbId = info.Item.Text;
                customerFbId = customerFbId.Remove(0, 1);
                int endIndex = customerFbId.IndexOf("]");
                customerFbId = customerFbId.Substring(0, endIndex);

                frm.bAdd = false;
                frm.curCustomerFbId = customerFbId;
                frm.curMarketFbId = this.curMarketFbId;
                frm.curMarketFbAccount = curMarketFbAccount;
                frm.pFrmMain = this.pFrmMain;
                frm.bAdmin = this.bAdmin;

                frm.MyFrmInit();
                frm.Show();
            }
        }
    }
}
