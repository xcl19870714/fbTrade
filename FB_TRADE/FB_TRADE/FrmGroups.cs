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
    public partial class FrmGroups : Form
    {
        public bool bAdmin;
        public string curMarketFbId;
        public string curMarketFbAccount;
        public FrmMain pFrmMain;

        private DBCommon db = new DBCommon();
        private StringBuilder sb = new StringBuilder();
        
        //1. 构造界面
        public FrmGroups()
        {
            InitializeComponent();

            this.listViewGroups.View = System.Windows.Forms.View.Details;
            this.listViewGroups.FullRowSelect = true;
            listViewGroups.CheckBoxes = true;
            this.listViewGroups.GridLines = true;

            this.listViewGroups.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewGroups_MouseDoubleClick);
            this.listViewGroups.ListViewItemSorter = new ListViewColumnSorter();
            this.listViewGroups.ColumnClick += new ColumnClickEventHandler(ListViewHelper.ListView_ColumnClick);

            listViewGroups.Clear();
            listViewGroups.Columns.Add("群组ID", 100, HorizontalAlignment.Left);
            listViewGroups.Columns.Add("名称", 100, HorizontalAlignment.Left);
            listViewGroups.Columns.Add("来源", 100, HorizontalAlignment.Left);
            listViewGroups.Columns.Add("成员数", 100, HorizontalAlignment.Left);
            listViewGroups.Columns.Add("简介", 100, HorizontalAlignment.Left);
            listViewGroups.Columns.Add("关系和状态", 100, HorizontalAlignment.Left);
            listViewGroups.Columns.Add("客户数", 100, HorizontalAlignment.Left);
            listViewGroups.Columns.Add("订单数", 100, HorizontalAlignment.Left);
            listViewGroups.Columns.Add("出单人数", 100, HorizontalAlignment.Left);
            listViewGroups.Columns.Add("互动人数", 100, HorizontalAlignment.Left);
            listViewGroups.Columns.Add("发推总数", 100, HorizontalAlignment.Left);
            listViewGroups.Columns.Add("帖子反馈", 100, HorizontalAlignment.Left);
            listViewGroups.Columns.Add("备注", 100, HorizontalAlignment.Left);
            listViewGroups.Columns.Add("最后发推", 100, HorizontalAlignment.Left);
            listViewGroups.Columns.Add("更新时间", 100, HorizontalAlignment.Left);
        }

        public void ListViewResize()
        {
            foreach (ColumnHeader item in listViewGroups.Columns)
            {
                item.TextAlign = HorizontalAlignment.Left;
                switch (item.Text)
                {
                    case "群组ID":
                        item.Width = (this.listViewGroups.Width / 100) * 7;
                        break;
                    case "名称":
                        item.Width = (this.listViewGroups.Width / 100) * 7;
                        break;
                    case "来源":
                        item.Width = (this.listViewGroups.Width / 100) * 7;
                        break;
                    case "成员数":
                        item.Width = (this.listViewGroups.Width / 100) * 5;
                        break;
                    case "简介":
                        item.Width = (this.listViewGroups.Width / 100) * 10;
                        break;
                    case "关系和状态":
                        item.Width = (this.listViewGroups.Width / 100) * 7;
                        break;
                    case "客户数":
                        item.Width = (this.listViewGroups.Width / 100) * 5;
                        break;
                    case "订单数":
                        item.Width = (this.listViewGroups.Width / 100) * 5;
                        break;
                    case "出单人数":
                        item.Width = (this.listViewGroups.Width / 100) * 5;
                        break;
                    case "互动人数":
                        item.Width = (this.listViewGroups.Width / 100) * 5;
                        break;
                    case "发推总数":
                        item.Width = (this.listViewGroups.Width / 100) * 5;
                        break;
                    case "帖子反馈":
                        item.Width = (this.listViewGroups.Width / 100) * 7;
                        break;
                    case "备注":
                        item.Width = (this.listViewGroups.Width / 100) * 11;
                        break;
                    case "最后发推":
                        item.Width = (this.listViewGroups.Width / 100) * 7;
                        break;
                    case "更新时间":
                        item.Width = (this.listViewGroups.Width / 100) * 7;
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

            labelCurMarketFbInfo.Text = "当前营销号：" + curMarketFbAccount;

            LoadListViewDB();
        }

        public void LoadListViewDB()
        {
            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbGroupShips where marketFbId='{0}'", curMarketFbId);

                if (ckbJoin.Checked)
                    sb.AppendFormat(" and status like '%申请加入;%'");
                if (ckbAccept.Checked)
                    sb.AppendFormat(" and status like '%申请通过;%'");
                if (ckbReject.Checked)
                    sb.AppendFormat(" and status like '%申请被拒;%'");
                if (cbxTweeting.Checked)
                    sb.AppendFormat(" and status like '%发贴状态;%'");
                if (cbxQuit.Checked)
                    sb.AppendFormat(" and status like '%退出群组;%'");
                if (ckbAbbandon.Checked)
                    sb.AppendFormat(" and status like '%不要;%'");

                if (cbxIm.Checked)
                    sb.AppendFormat(" and mark like '%重要;%'");
                if (cbxNormal.Checked)
                    sb.AppendFormat(" and mark like '%一般;%'");
                if (cbxCheated.Checked)
                    sb.AppendFormat(" and mark like '%认为是骗子;%'");
                if (cbxUnTrust.Checked)
                    sb.AppendFormat(" and mark like '%不信任;%'");
                if (cbxLocalTrade.Checked)
                    sb.AppendFormat(" and mark like '%想当地交易;%'");
                if (ckbAttacked.Checked)
                    sb.AppendFormat(" and mark like '%被攻击;%'");
                if (cbxOnSale.Checked)
                    sb.AppendFormat(" and mark like '%做活动;%'");

                List<FbGroupShipInfo> shipList = (List<FbGroupShipInfo>)db.GetList(sb.ToString(), "tb_fbGroupShips");

                listViewGroups.Items.Clear();
                foreach (var ship in shipList)
                {
                    ListViewItem it = new ListViewItem();

                    //shipInfo
                    it.Text = ship.groupFbId;

                    //Get GroupInfo
                    sb.Clear();
                    sb.AppendFormat("select * from tb_fbGroups where fbId='{0}'", ship.groupFbId);
                    FbGroupInfo group = (FbGroupInfo)db.GetObject(sb.ToString(), "tb_fbGroups");
                    it.SubItems.Add(group.name);
                    it.SubItems.Add(group.gpSource);
                    it.SubItems.Add(group.membersNum);
                    it.SubItems.Add(group.introduction);

                    it.SubItems.Add(ship.status);
                    it.SubItems.Add(ship.customersNum);
                    it.SubItems.Add(ship.ordersNum);
                    it.SubItems.Add(ship.contactCustomersNum);
                    it.SubItems.Add(ship.tweetsNum);
                    it.SubItems.Add(ship.tweetFeedback);
                    it.SubItems.Add(ship.note);

                    //Get last log
                    sb.Clear();
                    sb.AppendFormat("select top 1 * from tb_fbGroupLogs where groupFbId='{0}' and marketFbId='{1}' order by id DESC",
                        ship.groupFbId, curMarketFbId);
                    FbGroupLogInfo log = (FbGroupLogInfo)db.GetObject(sb.ToString(), "tb_fbGroupLogs");
                    if (log != null)
                        it.SubItems.Add(log.logs);

                    it.SubItems.Add(ship.lastEditTime);

                    listViewGroups.Items.Add(it);
                }
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

        //3. 操作
        //新增客户
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmGroupAdd frm = new FrmGroupAdd();
            this.pFrmMain.AddPage(frm, "新增/编辑群组");

            frm.bAdd = true;
            frm.curMarketFbId = this.curMarketFbId;
            frm.curMarketFbAccount = curMarketFbAccount;

            frm.MyFrmInit();
            frm.Show();
        }

        //双击编辑
        private void listViewGroups_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = this.listViewGroups.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                FrmGroupAdd frm = new FrmGroupAdd();
                this.pFrmMain.AddPage(frm, "编辑群组");

                frm.bAdd = false;
                frm.curGroupFbId = info.Item.Text;
                frm.curMarketFbId = this.curMarketFbId;
                frm.curMarketFbAccount = curMarketFbAccount;

                frm.MyFrmInit();
                frm.Show();
            }
        }

        //删除客户
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewGroups.CheckedItems.Count < 1)
            {
                MessageBox.Show("没有选中的条目！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult choice = MessageBox.Show("确定要删除吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (choice == DialogResult.No)
                return;

            for (int i = 0; i < listViewGroups.CheckedItems.Count; i++)
            {
                try
                {
                    //先删除logs
                    sb.Clear();
                    sb.AppendFormat("delete from tb_fbGroupLogs where groupFbId='{0}' and marketFbId='{1}'",
                        listViewGroups.CheckedItems[i].SubItems[0].Text, curMarketFbId);
                    db.DeleteData(sb.ToString());

                    //再删除群组关系表
                    sb.Clear();
                    sb.AppendFormat("delete from tb_fbGroupships where groupFbId='{0}' and marketFbId='{1}'",
                        listViewGroups.CheckedItems[i].SubItems[0].Text, curMarketFbId);
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

        private void btnCopyUrl_Click(object sender, EventArgs e)
        {
            if (listViewGroups.CheckedItems.Count < 1)
            {
                MessageBox.Show("请选择要复制的群组！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listViewGroups.CheckedItems.Count > 1)
            {
                MessageBox.Show("只能选中一个群组！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbGroups where fbId='{0}'", listViewGroups.CheckedItems[0].SubItems[0].Text);
                FbGroupInfo group = (FbGroupInfo)db.GetObject(sb.ToString(), "tb_fbGroups");
                if (group != null)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(group.fbUrl);
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

        private void button1_Click(object sender, EventArgs e)
        {
            LoadListViewDB();
        }
    }
}
