﻿using System;
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
    public partial class FrmMarketFbList : Form
    {
        public bool bAdmin;
        public string curAdminId;
        public string curUserId;
        public string curAdminName;
        public string curUserName;

        private DBCommon db = new DBCommon();
        private StringBuilder sb = new StringBuilder();

        //1. 界面构造
        public FrmMarketFbList()
        {
            InitializeComponent();
            MyComponentInit();
        }

        private void MyComponentInit()
        {
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ShowItemToolTips = false;

            this.listViewMarketFbs.View = System.Windows.Forms.View.Details;
            this.listViewMarketFbs.FullRowSelect = true;
            listViewMarketFbs.CheckBoxes = true;
            this.listViewMarketFbs.GridLines = true;

            this.listViewMarketFbs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewMarketFbs_MouseDoubleClick);
            this.listViewMarketFbs.ListViewItemSorter = new ListViewColumnSorter();
            this.listViewMarketFbs.ColumnClick += new ColumnClickEventHandler(ListViewHelper.ListView_ColumnClick);

            listViewMarketFbs.Clear();
            listViewMarketFbs.Columns.Add("facebook ID", 100, HorizontalAlignment.Left);
            listViewMarketFbs.Columns.Add("姓名", 100, HorizontalAlignment.Left);
            listViewMarketFbs.Columns.Add("facebook账号", 100, HorizontalAlignment.Left);
            listViewMarketFbs.Columns.Add("facebook密码", 100, HorizontalAlignment.Left);
            listViewMarketFbs.Columns.Add("facebook首页", 100, HorizontalAlignment.Left);
            listViewMarketFbs.Columns.Add("备注", 100, HorizontalAlignment.Left);
            listViewMarketFbs.Columns.Add("所属子账号", 100, HorizontalAlignment.Left);
            listViewMarketFbs.Columns.Add("创建时间", 100, HorizontalAlignment.Left);
        }

        public void ListViewResize()
        {
            foreach (ColumnHeader item in listViewMarketFbs.Columns)
            {
                item.TextAlign = HorizontalAlignment.Left;
                switch (item.Text)
                {
                    case "facebook ID":
                        item.Width = (this.listViewMarketFbs.Width / 100) * 9;
                        break;
                    case "姓名":
                        item.Width = (this.listViewMarketFbs.Width / 100) * 9;
                        break;
                    case "facebook账号":
                        item.Width = (this.listViewMarketFbs.Width / 100) * 18;
                        break;
                    case "facebook密码":
                        item.Width = (this.listViewMarketFbs.Width / 100) * 9;
                        break;
                    case "facebook首页":
                        item.Width = (this.listViewMarketFbs.Width / 100) * 19;
                        break;
                    case "备注":
                        item.Width = (this.listViewMarketFbs.Width / 100) * 18;
                        break;
                    case "所属子账号":
                        item.Width = (this.listViewMarketFbs.Width / 100) * 9;
                        break;
                    case "创建时间":
                        item.Width = (this.listViewMarketFbs.Width / 100) * 9;
                        break;
                    default:
                        item.Width = -2;
                        break;
                }
            }
        }

        //2. 数据加载
        public void MyFrmInit()
        {
            if (!bAdmin)
                btnDelete.Visible = false;

            ShowCurrUserLabel();
            LoadListViewDB();
        }

        private void ShowCurrUserLabel()
        {
            if (curUserId == "0")
                labelCurUser.Text =  curAdminName + "(管理员)";
            else
                labelCurUser.Text = curUserName;
        }

        public void LoadListViewDB()
        {
            try
            {
                sb.Clear();
                if (curUserId == "0")
                    sb.AppendFormat("select * from tb_fbMarketAccounts where userId in (select id from tb_users where adminId={0})", curAdminId);
                else
                    sb.AppendFormat("select * from tb_fbMarketAccounts where userId={0}", curUserId);

                List<FbMarketAccountInfo> fbList = (List<FbMarketAccountInfo>)db.GetList(sb.ToString(), "tb_fbMarketAccounts");

                listViewMarketFbs.Items.Clear();
                foreach (var fb in fbList)
                {
                    ListViewItem it = new ListViewItem();
                    UserInfo user = (UserInfo)db.GetObject("select * from tb_users where id=" + fb.userId, "tb_users");

                    it.Text = Convert.ToString(fb.fbId);
                    it.SubItems.Add(fb.name);
                    it.SubItems.Add(fb.fbAccount);
                    it.SubItems.Add(fb.fbPwd);
                    it.SubItems.Add(fb.fbUrl);
                    it.SubItems.Add(fb.note);
                    it.SubItems.Add(user.Name);
                    it.SubItems.Add(fb.createTime);
                    listViewMarketFbs.Items.Add(it);
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

        //3. 操作
        private void btnMarketFbAdd_Click(object sender, EventArgs e)
        {
            FrmMarketFbAdd frm = new FrmMarketFbAdd();

            frm.bAdd = true;
            frm.bAdmin = this.bAdmin;
            frm.curAdminId = this.curAdminId;
            frm.curUserId = this.curUserId;
            frm.pFrm = this;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            frm.Text = "新增营销号";
            frm.MyFrmInit();
            frm.ShowDialog();
        }

        private void listViewMarketFbs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = this.listViewMarketFbs.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                FrmMarketFbAdd frm = new FrmMarketFbAdd();
                frm.bAdd = false;
                frm.bAdmin = this.bAdmin;
                frm.curMarketFbId = info.Item.Text;
                frm.curAdminId = this.curAdminId;
                frm.curUserId = this.curUserId;
                frm.pFrm = this;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                frm.Text = "编辑营销号";
                frm.MyFrmInit();
                frm.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewMarketFbs.CheckedItems.Count < 1)
            {
                MessageBox.Show("没有选中的条目！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult choice = MessageBox.Show("确定要删除吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (choice == DialogResult.No)
                return;

            for (int i = 0; i < listViewMarketFbs.CheckedItems.Count; i++)
            {
                try
                {
                    sb.Clear();
                    sb.AppendFormat("delete from tb_fbMarketAccounts where fbId = '{0}'", this.listViewMarketFbs.CheckedItems[i].SubItems[0].Text);
                    db.DeleteData(sb.ToString());
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
            this.LoadListViewDB();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadListViewDB();
        }
    }
}
