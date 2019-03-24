using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FB_Trade_DAL;
using System.Data.SqlClient;
using FB_Trade_Models;

namespace FB_TRADE
{
    public partial class FrmGroupAdd : Form
    {
        public bool bAdd = true;
        public string curGroupFbId = string.Empty;
        public string curMarketFbId = string.Empty;
        public string curMarketFbAccount = string.Empty;

        private DBCommon db = new DBCommon();
        private StringBuilder sb = new StringBuilder();

        //1. 构造界面
        public FrmGroupAdd()
        {
            InitializeComponent();
            MyComponentInit();
        }

        private void MyComponentInit()
        {
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ShowItemToolTips = false;

            this.cbxVerifyType.Items.Clear();
            this.cbxVerifyType.Items.Add("需要");
            this.cbxVerifyType.Items.Add("不需要");
            this.cbxVerifyType.SelectedIndex = 0;

            this.listViewLogs.View = System.Windows.Forms.View.Details;
            this.listViewLogs.FullRowSelect = true;

            this.listViewLogs.ListViewItemSorter = new ListViewColumnSorter();
            this.listViewLogs.ColumnClick += new ColumnClickEventHandler(ListViewHelper.ListView_ColumnClick);

            listViewLogs.Clear();
            listViewLogs.Columns.Add("营销号", 100, HorizontalAlignment.Left);
            listViewLogs.Columns.Add("时间", 100, HorizontalAlignment.Left);
            listViewLogs.Columns.Add("聊天摘要与操作信息", 100, HorizontalAlignment.Left);
        }

        public void ListViewResize()
        {
            foreach (ColumnHeader item in listViewLogs.Columns)
            {
                item.TextAlign = HorizontalAlignment.Left;
                switch (item.Text)
                {
                    case "营销号":
                        item.Width = (this.listViewLogs.Width / 100) * 30;
                        break;
                    case "时间":
                        item.Width = (this.listViewLogs.Width / 100) * 25;
                        break;
                    case "聊天摘要与操作信息":
                        item.Width = (this.listViewLogs.Width / 100) * 45;
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
            LabelCurMarketFbInfo.Text = curMarketFbAccount;

            if (!bAdd)
            {
                InitGroupInfoFrm(curGroupFbId, "");
                InitCroupShipFrm();
                InitLogsListView();
                this.btnGroupGet.Visible = false;
            }
        }

        public bool InitGroupInfoFrm(string fbId, string fbUrl)
        {
            try
            {
                sb.Clear();
                if (fbId == "")
                    sb.AppendFormat("select * from tb_fbGroups where fbUrl='{0}'", fbUrl);
                else
                    sb.AppendFormat("select * from tb_fbGroups where fbId='{0}'", fbId);

                FbGroupInfo fbGroup = (FbGroupInfo)db.GetObject(sb.ToString(), "tb_fbGroups");
                if (fbGroup != null)
                {
                    this.txtGroupFbId.Text = fbGroup.fbId;
                    this.cbxVerifyType.SelectedIndex = cbxVerifyType.Items.IndexOf(fbGroup.needVerify);
                    this.txtGroupName.Text = fbGroup.name;
                    this.txtGroupUrl.Text = fbGroup.fbUrl;
                    this.txtMems.Text = fbGroup.membersNum.ToString();
                    this.txtIntroduction.Text = fbGroup.introduction;
                    return true;
                }
                else
                {
                    string fbIdStr = txtGroupUrl.Text.Trim();
                    if (fbIdStr.Contains("groups/"))
                    {
                        txtGroupFbId.Text = fbIdStr.Substring(fbIdStr.IndexOf("groups/") + 7);
                    }
                    else
                    {
                        MessageBox.Show("输入的群组首页应该包含groups/子串，请检查！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtGroupUrl.Focus();
                    }

                    return false;
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

            return false;
        }
        public void InitCroupShipFrm()
        {
            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbGroupShips where groupFbId='{0}' and marketFbId='{1}'", 
                    txtGroupFbId.Text.Trim(), curMarketFbId);
                FbGroupShipInfo ship = (FbGroupShipInfo)db.GetObject(sb.ToString(), "tb_fbGroupShips");
                if (ship != null)
                {
                    ckbImportant.Checked = (ship.mark.Contains("重要;"));
                    ckbNormal.Checked = ship.mark.Contains("一般;");
                    ckbCheated.Checked = ship.mark.Contains("认为是骗子;");
                    ckbDisTrust.Checked = ship.mark.Contains("不信任;");
                    ckbLocalTrade.Checked = ship.mark.Contains("想当地交易;");
                    ckbAttacked.Checked = ship.mark.Contains("被攻击;");
                    ckbOnSale.Checked = ship.mark.Contains("做活动;");

                    ckbJoin.Checked = (ship.status.Contains("申请加入;"));
                    ckbAccept.Checked = ship.status.Contains("申请通过;");
                    ckbReject.Checked = ship.status.Contains("申请被拒;");
                    ckbTweeting.Checked = ship.status.Contains("发贴状态;");
                    ckbQuit.Checked = ship.status.Contains("退出群组;");
                    ckbAbandon.Checked = ship.status.Contains("不要;");

                    txtCustomerNum.Text = ship.customersNum;
                    txtContactCustomers.Text = ship.contactCustomersNum;
                    txtTradeCustomers.Text = ship.tradeCustomersNum;
                    txtOrdersNum.Text = ship.ordersNum;

                    txtTweetsNum.Text = ship.tweetsNum;
                    if (ship.tweetFeedback == "活跃")
                    {
                        radioActive.Checked = true;
                    }
                    else if (ship.tweetFeedback == "一般")
                    {
                        radioNormal.Checked = true;
                    }
                    else
                    {
                        radioNotActive.Checked = true;
                    }
                    txtNote.Text = ship.note;
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

        private void InitLogsListView()
        {
            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbGroupLogs where marketFbId='{0}' and groupFbId='{1}'",
                    curMarketFbId, txtGroupFbId.Text.Trim());
                List<FbGroupLogInfo> logList = (List<FbGroupLogInfo>)db.GetList(sb.ToString(), "tb_fbGroupLogs");

                listViewLogs.Items.Clear();
                foreach (var log in logList)
                {
                    ListViewItem it = new ListViewItem();

                    it.Text = log.marketFbAccount;
                    it.SubItems.Add(log.time);
                    it.SubItems.Add(log.logs);
                    listViewLogs.Items.Add(it);
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
        //获取按钮
        private void btnGroupGet_Click(object sender, EventArgs e)
        {
            if (txtGroupUrl.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入群组首页！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtGroupUrl.Focus();
                return;
            }

            if (InitGroupInfoFrm("", txtGroupUrl.Text.Trim()) == true)
            {
                InitCroupShipFrm();
                InitLogsListView();
            }
        }

        private string getNewMark()
        {
            string newMark = "";

            if (ckbImportant.Checked)
                newMark += "重要;";
            if (ckbNormal.Checked)
                newMark += "一般;";
            if (ckbCheated.Checked)
                newMark += "认为是骗子;";
            if (ckbDisTrust.Checked)
                newMark += "不信任;";
            if (ckbLocalTrade.Checked)
                newMark += "想当地交易;";
            if (ckbAttacked.Checked)
                newMark += "被攻击;";
            if (ckbOnSale.Checked)
                newMark += "做活动;";

            return newMark;
        }

        private string getNewStatus()
        {
            string newStatus = "";

            if (ckbJoin.Checked)
                newStatus += "申请加入;";
            if (ckbAccept.Checked)
                newStatus += "申请通过;";
            if (ckbReject.Checked)
                newStatus += "申请被拒;";
            if (ckbTweeting.Checked)
                newStatus += "发贴状态;";
            if (ckbQuit.Checked)
                newStatus += "退出群组;";
            if (ckbAbandon.Checked)
                newStatus += "不要;";

            return newStatus;
        }

        private string getTweekFeedback()
        {
            if (radioActive.Checked)
                return "活跃";
            else if (radioNormal.Checked)
                return "一般";
            else
                return "不活跃";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!InputCheck())
                return;

            try
            {
                //1. fb_tbGroups
                sb.Clear();
                sb.AppendFormat("select count(*) from tb_fbGroups where fbUrl='{0}'", txtGroupUrl.Text.Trim());
                if (db.CheckExist(sb.ToString())) //编辑
                {
                    sb.Clear();
                    sb.AppendFormat("update tb_fbGroups set needVerify='{0}', name='{1}', fbUrl='{2}',membersNum={3}, introduction='{4}' where fbId='{5}'",
                         cbxVerifyType.SelectedItem.ToString(), txtGroupName.Text.Trim(), txtGroupUrl.Text.Trim(),
                         txtMems.Text.Trim(), txtIntroduction.Text.Trim(), txtGroupFbId.Text.Trim());
                    db.UpdateData(sb.ToString());
                }
                else //新增
                {
                    sb.Clear();
                    sb.AppendFormat("insert into tb_fbGroups(fbId, name, fbUrl, membersNum, introduction, needVerify) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}') ",
                        txtGroupFbId.Text.Trim(), txtGroupName.Text.Trim(), txtGroupUrl.Text.Trim(),
                        txtMems.Text.Trim(), txtIntroduction.Text.Trim(), cbxVerifyType.SelectedItem.ToString());
                    db.InsertData(sb.ToString());
                }

                //2. fb_tbGroupShips
                sb.Clear();
                sb.AppendFormat("select count(*) from tb_fbGroupShips where groupFbId='{0}' and marketFbId='{1}'",
                    txtGroupFbId.Text.Trim(), this.curMarketFbId);
                if (db.CheckExist(sb.ToString())) //编辑
                {
                    sb.Clear();
                    sb.AppendFormat("update tb_fbGroupShips set status='{0}', customersNum='{1}', contactCustomersNum='{2}', tradeCustomersNum='{3}', " +
                        "ordersNum='{4}', tweetsNum='{5}', tweetFeedback='{6}',mark='{7}',note='{8}',lastEditTime='{9}' where groupFbId='{10}' and marketFbId='{11}'",
                        getNewStatus(), txtCustomerNum.Text.Trim(), txtContactCustomers.Text.Trim(),
                        txtTradeCustomers.Text.Trim(), txtOrdersNum.Text.Trim(),
                        txtTweetsNum.Text.Trim(), getTweekFeedback(), getNewMark(), txtNote.Text.Trim(), DateTime.Now.ToString(), 
                        txtGroupFbId.Text.Trim(), curMarketFbId);
                    db.UpdateData(sb.ToString());
                }
                else //新增
                {
                    sb.Clear();
                    sb.AppendFormat("insert into tb_fbGroupShips(groupFbId, marketFbId, status, customersNum, contactCustomersNum, tradeCustomersNum, " +
                        "ordersNum, tweetsNum, tweetFeedback, mark, note, lastEditTime) " +
                        "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}') ",
                        txtGroupFbId.Text.Trim(), curMarketFbId, getNewStatus(), txtCustomerNum.Text.Trim(), txtContactCustomers.Text.Trim(),
                        txtTradeCustomers.Text.Trim(), txtOrdersNum.Text.Trim(), txtTweetsNum.Text.Trim(), getTweekFeedback(), getNewMark(), 
                        txtNote.Text.Trim(), DateTime.Now.ToString());
                    db.InsertData(sb.ToString());
                }

                //3. 聊天摘要
                if (txtContact.Text.Trim() != "")
                {
                    sb.Clear();
                    sb.AppendFormat("insert into tb_fbGroupLogs(groupFbId, marketFbId, marketFbAccount, time, logs) " +
                        "values('{0}','{1}','{2}','{3}','{4}')",
                        txtGroupFbId.Text.Trim(), curMarketFbId, curMarketFbAccount, DateTime.Now.ToString(), txtContact.Text.Trim());
                    db.InsertData(sb.ToString());
                }

                //保存成功
                MessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContact.Text = "";
                this.bAdd = false;
                this.curGroupFbId = txtGroupFbId.Text.Trim();
                MyComponentInit();
                MyFrmInit();
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

        private bool InputCheck()
        {
            if (txtGroupUrl.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入群组首页！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtGroupUrl.Focus();
                return false;
            }

            if (txtGroupFbId.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请点击\"获取\"读取群组编号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtGroupFbId.Focus();
                return false;
            }

            if (txtGroupName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入群组名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtGroupName.Focus();
                return false;
            }

            return true;
        }
    }
}
