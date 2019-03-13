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
        public bool bAdd;
        public string curGroupFbId;
        public string curMarketFbId;
        public string curMarketFbAccount;

        private DBCommon db = new DBCommon();
        private string sql;
        private object ckbRejected;

        public FrmGroupAdd()
        {
            InitializeComponent();

            this.cbxVerifyType.Items.Clear();
            this.cbxVerifyType.Items.Add("需要");
            this.cbxVerifyType.Items.Add("不需要");
            this.cbxVerifyType.SelectedText = "需要";
        }

        public void MyFrmInit()
        {
            labelCurMarketFbAccount.Text = curMarketFbAccount;

            if (!bAdd)
            {
                InitGroupInfoFrm(curGroupFbId, "");
                InitCroupShipFrm();
                InitLogsListView();
            }
        }

        //1. Graph Shows


        //2. Data Shows
        public bool InitGroupInfoFrm(string fbId, string fbUrl)
        {
            try
            {
                FbGroupInfo fbGroup;
                sql = (fbId == "" ? ("select * from tb_fbGroups where fbUrl='" + fbUrl + "'") :
                    ("select * from tb_fbGroups where fbId='" + fbId + "'"));

                fbGroup = (FbGroupInfo)db.GetObject(sql, "tb_fbGroups");
                if (fbGroup != null)
                {
                    this.txtGroupFbId.Text = fbGroup.fbId;
                    this.cbxVerifyType.SelectedText = (fbGroup.needVerify == 1 ? "需要" : "不需要");
                    this.txtGroupName.Text = fbGroup.name;
                    this.txtGroupUrl.Text = fbGroup.fbUrl;
                    this.txtMems.Text = fbGroup.members.ToString();
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
                        MessageBox.Show("输入的群组首页应该包含group/子串，请检查！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("select * from tb_fbGroupShips where groupFbId='{0}' and marketFbId='{1}'", 
                    txtGroupFbId.Text.Trim(), curMarketFbId);
                FbGroupShipInfo ship = (FbGroupShipInfo)db.GetObject(sql, "tb_fbGroupShips");
                if (ship != null)
                {
                    ckbImportant.Checked = ship.mark.Contains("重要;");
                    ckbNormal.Checked = ship.mark.Contains("一般;");
                    ckbCheated.Checked = ship.mark.Contains("认为是骗子;");
                    ckbDisTrust.Checked = ship.mark.Contains("不信任;");
                    ckbLocalTrade.Checked = ship.mark.Contains("想当地交易;");
                    ckbAttacked.Checked = ship.mark.Contains("被攻击;");
                    ckbOnSale.Checked = ship.mark.Contains("做活动;");

                    ckbJoin.Checked = ship.status.Contains("申请加入;");
                    ckbAccept.Checked = ship.status.Contains("申请通过;");
                    ckbReject.Checked = ship.status.Contains("申请被拒;");
                    ckbTweeting.Checked = ship.status.Contains("发贴状态;");
                    ckbQuit.Checked = ship.status.Contains("退出群组;");
                    ckbAbandon.Checked = ship.status.Contains("不要;");

                    txtCustomerNum.Text = ship.customers.ToString();
                    txtContactCustomers.Text = ship.contactCustomers.ToString();
                    txtTradeCustomers.Text = ship.tradeCustomers.ToString();
                    txtOrdersNum.Text = ship.orders.ToString();

                    txtTweetsNum.Text = ship.tweets.ToString();
                    if (ship.tweetFeedback == 1)
                    {
                        radioActive.Checked = true;
                    }
                    else if (ship.tweetFeedback == 2)
                    {
                        radioNormal.Checked = true;
                    }
                    else
                    {
                        radioNotActive.Checked = true;
                    }
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
                listViewLogs.Clear();
                listViewLogs.Columns.Add("关系人", 100, HorizontalAlignment.Left);
                listViewLogs.Columns.Add("时间", 100, HorizontalAlignment.Left);
                listViewLogs.Columns.Add("聊天摘要与操作信息", 100, HorizontalAlignment.Left);
                listViewLogs.Items.Clear();

                sql = "select * from tb_fbGroupLogs where marketFbId='" + curMarketFbId +
                    "' and groupFbId='" + txtGroupFbId.Text.Trim() + "'";
                List<FbGroupLogInfo> logList = (List<FbGroupLogInfo>)db.GetList(sql, "tb_fbGroupLogs");
                foreach (var log in logList)
                {
                    ListViewItem it = new ListViewItem();

                    it.Text = log.marketFbAccount;
                    it.SubItems.Add(log.time);
                    it.SubItems.Add(log.logs);
                    listViewLogs.Items.Add(it);
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

        private string getNewStatus()
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

        private string getNewMark()
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

        private int getTweekFeedback()
        {
            if (radioActive.Checked)
                return 1;
            if (radioNormal.Checked)
                return 2;
            if (radioNotActive.Checked)
                return 3;

            return 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!InputCheck())
                return;

            try
            {
                //1. tb_fbGroups
                sql = "select count(*) from tb_fbGroups where fbUrl='" + txtGroupUrl.Text.Trim() + "'";
                if (db.CheckExist(sql)) //编辑
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("update tb_fbGroups set needVerify={0}, name='{1}', members={2}, introduction='{3}'",
                        (cbxVerifyType.SelectedText == "需要" ? 1 : 0), txtGroupName.Text.Trim(), 
                        Convert.ToUInt32(txtMems.Text.Trim()), txtIntroduction.Text.Trim());
                    db.UpdateData(sb.ToString());
                }
                else //新增
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("insert into tb_fbGroups(fbId, name, fbUrl, members, introduction, needVerify) values({0}, {1}, {2}, {3}, {4}, {5}) ",
                        txtGroupFbId.Text.Trim(), txtGroupName.Text.Trim(), txtGroupUrl.Text.Trim(), 
                        Convert.ToUInt32(txtMems.Text.Trim()), txtIntroduction.Text.Trim(), (cbxVerifyType.SelectedText == "需要" ? 1 : 0));
                    db.InsertData(sb.ToString());
                }

                //2. tb_fbGroupShips
                sql = "select count(*) from tb_fbGroupShips where groupFbId='" + txtGroupFbId.Text.Trim() +
                    "' and marketFbId='" + this.curMarketFbId + "'";
                if (db.CheckExist(sql)) //编辑
                {
                    

                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("update tb_fbGroupShips set status='{0}', customers={1}, contactCustomers={2}, tradeCustomers={3}, " +
                        "orders={4}, tweets={5}, tweetFeedback={6},mark='{7}'",
                        getNewStatus(), Convert.ToUInt32(txtCustomerNum.Text.Trim()), Convert.ToUInt32(this.txtContactCustomers.Text.Trim()), 
                        Convert.ToUInt32(txtTradeCustomers.Text.Trim()), Convert.ToUInt32(txtOrdersNum.Text.Trim()), 
                        Convert.ToUInt32(txtTweetsNum.Text.Trim()), getTweekFeedback(), getNewMark());
                    db.UpdateData(sb.ToString());
                }
                else //新增
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("insert into tb_fbGroupShips(groupFbId, marketFbId, status, customers, contactCustomers, tradeCustomers, " +
                        "orders, tweets, tweetFeedback, mark) values({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}) ",
                        txtGroupFbId.Text.Trim(), curMarketFbId, getNewStatus(), txtCustomerNum.Text.Trim(), txtContactCustomers.Text.Trim(), 
                        txtTradeCustomers.Text.Trim(), txtOrdersNum.Text.Trim(), txtTweetsNum.Text.Trim(), getTweekFeedback(), getNewMark());
                    db.InsertData(sb.ToString());
                }

                //tb_fbGroupLogs
                if (txtContact.Text.Trim() != "")
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("insert into tb_fbGroupLogs(groupFbId, marketFbId, marketFbAccount, time, logs) " +
                        "values('{0}','{1}','{2}','{3}','{4}'", 
                        txtGroupFbId, curMarketFbId, curMarketFbAccount, DateTime.Now.ToString(), txtContact.Text.Trim());
                    db.InsertData(sb.ToString());
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
