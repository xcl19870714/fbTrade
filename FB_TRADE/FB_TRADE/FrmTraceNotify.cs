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
    public partial class FrmTraceNotify : Form
    {
        public string curUserId;
        public FrmMain pFrmMain;

        private DBCommon db = new DBCommon();
        private StringBuilder sb = new StringBuilder();

        //1. 构造界面
        public FrmTraceNotify()
        {
            InitializeComponent();
            MyInitComponent();
        }

        private void MyInitComponent()
        {
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ShowItemToolTips = false;

            this.listViewTrace.View = System.Windows.Forms.View.Details;
            this.listViewTrace.FullRowSelect = true;
            listViewTrace.CheckBoxes = true;
            this.listViewTrace.GridLines = true;

            this.listViewTrace.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewTrace_MouseDoubleClick);
            this.listViewTrace.ListViewItemSorter = new ListViewColumnSorter();
            this.listViewTrace.ColumnClick += new ColumnClickEventHandler(ListViewHelper.ListView_ColumnClick);

            listViewTrace.Clear();
            listViewTrace.Columns.Add("营销号编号", 100, HorizontalAlignment.Left);
            listViewTrace.Columns.Add("营销号", 100, HorizontalAlignment.Left);
            listViewTrace.Columns.Add("客户编号", 100, HorizontalAlignment.Left);
            listViewTrace.Columns.Add("客户姓名", 100, HorizontalAlignment.Left);
            listViewTrace.Columns.Add("简介", 100, HorizontalAlignment.Left);
            listViewTrace.Columns.Add("意向产品", 100, HorizontalAlignment.Left);
            listViewTrace.Columns.Add("好友关系", 100, HorizontalAlignment.Left);
            listViewTrace.Columns.Add("客户备注", 100, HorizontalAlignment.Left);
            listViewTrace.Columns.Add("跟踪日期", 100, HorizontalAlignment.Left);
            listViewTrace.Columns.Add("更新时间", 100, HorizontalAlignment.Left);
            listViewTrace.Columns.Add("互动次数", 100, HorizontalAlignment.Left);
            listViewTrace.Columns.Add("聊天摘要", 100, HorizontalAlignment.Left);
        }

        public void ListViewResize()
        {
            foreach (ColumnHeader item in listViewTrace.Columns)
            {
                item.TextAlign = HorizontalAlignment.Left;
                switch (item.Text)
                {
                    case "营销号编号":
                        item.Width = (this.listViewTrace.Width / 100) * 6;
                        break;
                    case "营销号":
                        item.Width = (this.listViewTrace.Width / 100) * 10;
                        break;
                    case "客户编号":
                        item.Width = (this.listViewTrace.Width / 100) * 6;
                        break;
                    case "客户姓名":
                        item.Width = (this.listViewTrace.Width / 100) * 8;
                        break;
                    case "简介":
                        item.Width = (this.listViewTrace.Width / 100) * 8;
                        break;
                    case "意向产品":
                        item.Width = (this.listViewTrace.Width / 100) * 8;
                        break;
                    case "好友关系":
                        item.Width = (this.listViewTrace.Width / 100) * 8;
                        break;
                    case "客户备注":
                        item.Width = (this.listViewTrace.Width / 100) * 10;
                        break; 
                    case "追踪日期":
                        item.Width = (this.listViewTrace.Width / 100) * 6;
                        break;
                    case "更新时间":
                        item.Width = (this.listViewTrace.Width / 100) * 10;
                        break;
                    case "互动次数":
                        item.Width = (this.listViewTrace.Width / 100) * 8;
                        break;
                    case "聊天摘要":
                        item.Width = (this.listViewTrace.Width / 100) * 12;
                        break;
                    default:
                        item.Width = -2;
                        break;
                }
            }

            //this.labelNotifyInfo.Margin = new System.Windows.Forms.Padding(((toolStrip1.Width - labelNotifyInfo.Width) / 2 - btnUpdate.Width), 1, 1, 2);
        }

        //2. 数据加载
        public void MyFrmInit()
        {
            InitNotifyLabel();
            LoadListViewDB();
        }

        private void InitNotifyLabel()
        {
            try
            {
                sb.Clear();
                sb.AppendFormat("select count(*) from tb_fbCustomerShips where marketFbId in (select fbId from tb_fbMarketAccounts where userId={0}) and " +
                    "trace=1 and traceDate='{1}'", curUserId, DateTime.Today.ToString());
                labelTraceCount.Text = Convert.ToString(db.GetCount(sb.ToString()));
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

        public void LoadListViewDB()
        {
            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbCustomerShips where marketFbId in (select fbId from tb_fbMarketAccounts where userId={0}) and " +
                    "trace=1 and traceDate='{1}'", curUserId, DateTime.Today.ToString());
                List<FbCustomerShipInfo> shipList = (List<FbCustomerShipInfo>)db.GetList(sb.ToString(), "tb_fbCustomerShips");

                listViewTrace.Items.Clear();
                foreach (var ship in shipList)
                {
                    ListViewItem it = new ListViewItem();

                    //Get marketAccount
                    sb.Clear();
                    sb.AppendFormat("select * from tb_fbMarketAccounts where fbId='{0}'", ship.marketFbId);
                    FbMarketAccountInfo marketFb = (FbMarketAccountInfo)db.GetObject(sb.ToString(), "tb_fbMarketAccounts");
                    it.Text = marketFb.fbId;
                    it.SubItems.Add(marketFb.fbAccount);

                    //Get CustomerInfo
                    sb.Clear();
                    sb.AppendFormat("select * from tb_fbCustomers where fbId='{0}'", ship.customerFbId);
                    FbCustomerInfo customer = (FbCustomerInfo)db.GetObject(sb.ToString(), "tb_fbCustomers");
                    it.SubItems.Add(ship.customerFbId);
                    it.SubItems.Add(customer.name);
                    it.SubItems.Add(customer.introduction);
                    it.SubItems.Add(ship.interestedGoods);

                    //friendShips
                    sb.Clear();
                    sb.AppendFormat("select fbAccount from tb_fbMarketAccounts where fbId in " +
                        "(select marketFbId from tb_fbCustomerShips where customerFbId='{0}' and shipType in ('好友','屏蔽'))", ship.customerFbId);
                    List<string> strList = (List<string>)db.GetStringList(sb.ToString(), "fbAccount");
                    string friendShips = "";
                    foreach (var str in strList)
                    {
                        friendShips += str + ";";
                    }
                    it.SubItems.Add(friendShips);

                    it.SubItems.Add(ship.note);
                    it.SubItems.Add(ship.traceDate.Split(' ')[0]);
                    it.SubItems.Add(ship.lastEditTime);

                    //互动次数
                    sb.Clear();
                    sb.AppendFormat("select count(*) from tb_fbCustomerContacts where customerFbId='{0}' and marketFbId='{1}'",
                        ship.customerFbId, ship.marketFbId);
                    it.SubItems.Add(db.GetCount(sb.ToString()).ToString());

                    //Get last contact
                    sb.Clear();
                    sb.AppendFormat("select top 1 * from tb_fbCustomerContacts where customerFbId='{0}' and marketFbId='{1}' order by id DESC",
                        ship.customerFbId, ship.marketFbId);
                    FbCustomerContactInfo contact = (FbCustomerContactInfo)db.GetObject(sb.ToString(), "tb_fbCustomerContacts");
                    if (contact != null)
                        it.SubItems.Add(contact.content);

                    listViewTrace.Items.Add(it);
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

        //双击编辑
        private void listViewTrace_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = this.listViewTrace.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                FrmCustomerAdd frm = new FrmCustomerAdd();
                this.pFrmMain.AddPage(frm, "编辑客户");

                frm.bAdd = false;
                frm.curCustomerFbId = info.Item.SubItems[2].Text;
                frm.curMarketFbId = info.Item.SubItems[0].Text;
                frm.curMarketFbAccount = info.Item.SubItems[1].Text;

                frm.MyFrmInit();
                frm.Show();
            }
        }

        private void btnCopyUrl_Click(object sender, EventArgs e)
        {
            if (listViewTrace.CheckedItems.Count < 1)
            {
                MessageBox.Show("请选择要复制的条目！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listViewTrace.CheckedItems.Count > 1)
            {
                MessageBox.Show("只能选中一条条目！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbCustomers where fbId='{0}'", listViewTrace.CheckedItems[0].SubItems[2].Text);
                FbCustomerInfo customer = (FbCustomerInfo)db.GetObject(sb.ToString(), "tb_fbCustomers");
                if (customer != null)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(customer.fbUrl);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MyFrmInit();
        }
    }
}
