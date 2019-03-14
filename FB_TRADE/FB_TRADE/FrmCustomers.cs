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
    public partial class FrmCustomers : Form
    {
        public bool bAdmin;
        public string curMarketFbId;
        public string curMarketFbAccount;

        private DBCommon db = new DBCommon();
        private StringBuilder sb = new StringBuilder();

        public FrmCustomers()
        {
            InitializeComponent();

            this.listViewCustomers.View = System.Windows.Forms.View.Details;
            this.listViewCustomers.FullRowSelect = true;
            listViewCustomers.CheckBoxes = true;

            this.listViewCustomers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewCustomers_MouseDoubleClick);
            this.listViewCustomers.ListViewItemSorter = new ListViewColumnSorter();
            this.listViewCustomers.ColumnClick += new ColumnClickEventHandler(ListViewHelper.ListView_ColumnClick);

            listViewCustomers.Clear();
            listViewCustomers.Columns.Add("facebook ID", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("昵称", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("国家", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("城市", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("简介", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("好友关系", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("账号关系", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("客户类型", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("订单数", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("意向产品", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("客户备注", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("跟踪日期", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("更新时间", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("互动次数", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("聊天摘要", 100, HorizontalAlignment.Left);
        }

        public void ListViewResize()
        {
            foreach (ColumnHeader item in listViewCustomers.Columns)
            {
                item.TextAlign = HorizontalAlignment.Left;
                switch (item.Text)
                {
                    case "facebook ID":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "昵称":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "国家":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "城市":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "简介":
                        item.Width = (this.listViewCustomers.Width / 100) * 8;
                        break;
                    case "好友关系":
                        item.Width = (this.listViewCustomers.Width / 100) * 10;
                        break;
                    case "账号关系":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "客户类型":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "订单数":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "意向产品":
                        item.Width = (this.listViewCustomers.Width / 100) * 10;
                        break;
                    case "客户备注":
                        item.Width = (this.listViewCustomers.Width / 100) * 10;
                        break;
                    case "跟踪日期":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "更新时间":
                        item.Width = (this.listViewCustomers.Width / 100) * 7;
                        break;
                    case "互动次数":
                        item.Width = (this.listViewCustomers.Width / 100) * 3;
                        break;
                    case "聊天摘要":
                        item.Width = (this.listViewCustomers.Width / 100) * 12;
                        break;
                    default:
                        item.Width = -2;
                        break;
                }
            }
        }

        //2. MyShow
        public void MyInitFrm()
        {
            if (!bAdmin)
                btnDelete.Visible = false;
            LoadListViewDB();
        }

        public void LoadListViewDB()
        {
            try
            {
                //if (curUserId == "0")
                //    sqlStr = "select * from tb_fbMarketAccounts where userId in (select id from tb_users where adminId=" + curAdminId + ")";
                //else
                //    sqlStr = "select * from tb_fbMarketAccounts where userId='" + curUserId + "'";

                //List<FbMarketAccountInfo> fbList = (List<FbMarketAccountInfo>)db.GetList(sqlStr, "tb_fbMarketAccounts");

                //listViewCustomers.Items.Clear();
                //foreach (var fb in fbList)
                //{
                //    ListViewItem it = new ListViewItem();
                //    UserInfo tmp = (UserInfo)db.GetObject("select * from tb_users where id='" + fb.userId + "'", "tb_users");

                //    it.Text = Convert.ToString(fb.fbId);
                //    it.SubItems.Add(fb.name);
                //    it.SubItems.Add(fb.fbAccount);
                //    it.SubItems.Add(fb.fbPwd);
                //    it.SubItems.Add(fb.fbUrl);
                //    it.SubItems.Add(fb.note);
                //    it.SubItems.Add(tmp.Name);
                //    it.SubItems.Add(fb.createTime);
                //    listViewCustomers.Items.Add(it);
                //}
                ListViewResize();
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

        //3. operations
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmCustomerAdd frm = new FrmCustomerAdd();
            frm.bAdd = true;
            frm.curMarketFbId = this.curMarketFbId;
            frm.curMarketFbAccount = curMarketFbAccount;

            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            frm.Text = "新增客户";
            frm.MyFrmInit();
            frm.ShowDialog();
        }

        private void listViewCustomers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //ListViewHitTestInfo info = this.listViewCustomers.HitTest(e.X, e.Y);
            //if (info.Item != null)
            //{
            //    FrmMarketFbAdd frm = new FrmMarketFbAdd();
            //    frm.bAdd = false;
            //    frm.bAdmin = this.bAdmin;
            //    frm.curMarketFbId = info.Item.Text;
            //    frm.curAdminId = this.curAdminId;
            //    frm.curUserId = this.curUserId;
            //    frm.pFrm = this;
            //    frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            //    frm.Text = "编辑营销号";
            //    frm.MyInitFrm();
            //    frm.ShowDialog();
            //}
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (listViewCustomers.CheckedItems.Count < 1)
            {
                MessageBox.Show("没有选中的条目！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult choice = MessageBox.Show("确定要删除吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (choice == DialogResult.No)
                return;

            for (int i = 0; i < listViewCustomers.CheckedItems.Count; i++)
            {
                try
                {
                    //sqlStr = "delete from tb_fbMarketAccounts where fbId='" + this.listViewCustomers.CheckedItems[i].SubItems[0].Text + "'";
                    //db.DeleteData(sqlStr);
                    //this.LoadListViewDB();
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
        }
    }
}
