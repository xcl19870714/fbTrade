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
    public partial class FrmCustomerAdd : Form
    {
        public bool bAdd = true;
		public string curCustomerFbId = string.Empty;
        public string curMarketFbId = string.Empty;
        public string curMarketFbAccount = string.Empty;
        public FrmMain pFrmMain;
        public bool bAdmin = false;

        private DBCommon db = new DBCommon();
        private StringBuilder sb = new StringBuilder();

        //1. 构造界面
        public FrmCustomerAdd()
        {
            InitializeComponent();
            MyComponentInit();
        }

        private void MyComponentInit()
        {
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ShowItemToolTips = false;

            this.cbxShipType.Items.Clear();
            this.cbxShipType.Items.Add("好友");
            this.cbxShipType.Items.Add("非好友");
            this.cbxShipType.Items.Add("屏蔽");
            this.cbxShipType.SelectedIndex = 0;

            this.cbxCustomerType.Items.Clear();
            this.cbxCustomerType.Items.Add("意向客户");
            this.cbxCustomerType.Items.Add("批发客户");
            this.cbxCustomerType.Items.Add("零售客户");
            this.cbxCustomerType.SelectedIndex = 0;

            this.listViewContacts.View = System.Windows.Forms.View.Details;
            this.listViewContacts.FullRowSelect = true;
            this.listViewContacts.GridLines = true;

            this.listViewContacts.ListViewItemSorter = new ListViewColumnSorter();
            this.listViewContacts.ColumnClick += new ColumnClickEventHandler(ListViewHelper.ListView_ColumnClick);

            listViewContacts.Clear();
            listViewContacts.Columns.Add("营销号", 100, HorizontalAlignment.Left);
            listViewContacts.Columns.Add("时间", 100, HorizontalAlignment.Left);
            listViewContacts.Columns.Add("聊天摘要", 100, HorizontalAlignment.Left);
        }

        public void ListViewResize()
        {
            foreach (ColumnHeader item in listViewContacts.Columns)
            {
                item.TextAlign = HorizontalAlignment.Left;
                switch (item.Text)
                {
                    case "营销号":
                        item.Width = (this.listViewContacts.Width / 100) * 40;
                        break;
                    case "时间":
                        item.Width = (this.listViewContacts.Width / 100) * 20;
                        break;
                    case "聊天摘要":
                        item.Width = (this.listViewContacts.Width / 100) * 40;
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
            labelCurMarketFb.Text = curMarketFbAccount;

            if (!bAdd)
            {
                InitCustomerFrm(curCustomerFbId, "");
                InitCustomerShipFrm();
                InitOrdersNumLabel();
                InitContactsListView();

                this.btnGet.Visible = false;
                this.txtFbUrl.ReadOnly = true;
            }
        }
        public bool InitCustomerFrm(string fbId, string fbUrl)
        {
            try
            {
                sb.Clear();
                if (fbId == "")
                    sb.AppendFormat("select * from tb_fbCustomers where fbUrl='{0}'", fbUrl);
                else
                    sb.AppendFormat("select * from tb_fbCustomers where fbId='{0}'", fbId);

                FbCustomerInfo fbCustomer = (FbCustomerInfo)db.GetObject(sb.ToString(), "tb_fbCustomers");
                if (fbCustomer != null)
                {
                    txtFbId.Text = fbCustomer.fbId;
                    txtName.Text = fbCustomer.name;
                    txtFbUrl.Text = fbCustomer.fbUrl;
                    InitFriendShipsText(fbCustomer.fbId);
                    txtEmail.Text = fbCustomer.email;
                    txtFriendsNum.Text = fbCustomer.friendsNum;
                    txtCountry.Text = fbCustomer.country;
                    txtState.Text = fbCustomer.state;
                    txtCity.Text = fbCustomer.city;
                    txtIntroduction.Text = fbCustomer.introduction;

                    return true;
                }
                else
                {
                    string fbIdStr = txtFbUrl.Text.Trim();
                    if (fbIdStr.Contains("id="))
                    {
                        txtFbId.Text = fbIdStr.Substring(fbIdStr.IndexOf("id=") + 3);
                    }
                    else
                    {
                        MessageBox.Show("输入的客户首页应该包含id=子串，请检查！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtFbUrl.Focus();
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

        public void InitFriendShipsText(string customerFbId)
        {
            sb.Clear();
            sb.AppendFormat("select fbAccount from tb_fbMarketAccounts where fbId in " +
                "(select marketFbId from tb_fbCustomerShips where customerFbId='{0}' and shipType in ('好友','屏蔽'))", customerFbId);
            List<string> strList = (List<string>)db.GetStringList(sb.ToString(), "fbAccount");
            string friendShips = "";
            foreach (var str in strList)
            {
                friendShips += str + ";";
            }

            txtFriendShips.Text = friendShips;
        }

        public void InitCustomerShipFrm()
        {
            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbCustomerShips where customerFbId = '{0}' and marketFbId='{1}'",
                    txtFbId.Text.Trim(), curMarketFbId);
                FbCustomerShipInfo ship = (FbCustomerShipInfo)db.GetObject(sb.ToString(), "tb_fbCustomerShips");
                if (ship != null)
                {
                    this.cbxShipType.SelectedIndex = cbxShipType.Items.IndexOf(ship.shipType);
                    this.cbxCustomerType.SelectedIndex = cbxCustomerType.Items.IndexOf(ship.customerType);
                    this.txtInGoods.Text = ship.interestedGoods;
                    this.txtNote.Text = ship.note;
                    ckbTraceDate.Checked = (ship.trace == 1);
                    dateTimePicker1.Value = Convert.ToDateTime(ship.traceDate);
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

        public void InitOrdersNumLabel()
        {
            try
            {
                sb.Clear();
                sb.AppendFormat("select count(*) from tb_fbOrders where customerFbId='{0}' and marketFbId='{1}'",
                    txtFbId.Text.Trim(), curMarketFbId);
                labelOrders.Text = db.GetCount(sb.ToString()).ToString();
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

        private void InitContactsListView()
        {
            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbCustomerContacts where marketFbId='{0}' and customerFbId='{1}'",
                    curMarketFbId, txtFbId.Text.Trim());
                List<FbCustomerContactInfo> contactList = (List<FbCustomerContactInfo>)db.GetList(sb.ToString(), "tb_fbCustomerContacts");

                listViewContacts.Items.Clear();
                foreach (var contact in contactList)
                {
                    ListViewItem it = new ListViewItem();

                    it.Text = contact.marketFbAccount;
                    it.SubItems.Add(contact.time);
                    it.SubItems.Add(contact.content);
                    listViewContacts.Items.Add(it);
                }
                //ListViewResize();
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
        private void btnGet_Click(object sender, EventArgs e)
        {
            if (txtFbUrl.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入客户首页！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtFbUrl.Focus();
                return;
            }

            if (InitCustomerFrm("", txtFbUrl.Text.Trim()) == true)
            {
                InitCustomerShipFrm();
                InitOrdersNumLabel();
                InitContactsListView();
            }
        }

        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!InputCheck())
                return;

            try
            {
                //1. fb_tbCustomers
                sb.Clear();
                sb.AppendFormat("select count(*) from tb_fbCustomers where fbUrl='{0}'", txtFbUrl.Text.Trim());
                if (db.CheckExist(sb.ToString())) //编辑
                {
                    sb.Clear();
                    sb.AppendFormat("update tb_fbCustomers set name='{0}',fbUrl='{1}',friendsNum='{2}',country='{3}',state='{4}'," +
                        "city='{5}',email='{6}',introduction='{7}' where fbId='{8}'",
                        txtName.Text.Trim(), txtFbUrl.Text.Trim(), txtFriendsNum.Text.Trim(), txtCountry.Text.Trim(), 
                        txtState.Text.Trim(), txtCity.Text.Trim(), txtEmail.Text.Trim(), txtIntroduction.Text.Trim(),
                        txtFbId.Text.Trim());
                    db.UpdateData(sb.ToString());
                }
                else //新增
                {
                    sb.Clear();
                    sb.AppendFormat("insert into tb_fbCustomers values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",
                         txtFbId.Text.Trim(), txtName.Text.Trim(), txtFbUrl.Text.Trim(), txtFriendsNum.Text.Trim(), txtCountry.Text.Trim(),
                         txtState.Text.Trim(), txtCity.Text.Trim(), txtEmail.Text.Trim(), txtIntroduction.Text.Trim(), 
                         "","","");
                    db.InsertData(sb.ToString());
                }

                //2. fb_tbCustomerShips
                sb.Clear();
                sb.AppendFormat("select count(*) from tb_fbCustomerShips where customerFbId='{0}' and marketFbId='{1}'",
                    txtFbId.Text.Trim(), this.curMarketFbId);
                if (db.CheckExist(sb.ToString())) //编辑
                {
                    sb.Clear();
                    sb.AppendFormat("update tb_fbCustomerShips set shipType='{0}',customerType='{1}',interestedGoods='{2}',note='{3}'," +
                        "trace={4}, traceDate='{5}',lastEditTime='{6}' where customerFbId='{7}' and marketFbId='{8}'",
                        cbxShipType.SelectedItem.ToString(), cbxCustomerType.SelectedItem.ToString(), txtInGoods.Text.Trim(),
                        txtNote.Text.Trim(), ckbTraceDate.Checked ? 1 : 0, dateTimePicker1.Value.ToString("yyyy-MM-dd"), DateTime.Now.ToString(), 
                        txtFbId.Text.Trim(), this.curMarketFbId);
                    db.UpdateData(sb.ToString());
                }
                else //新增
                {
                    sb.Clear();
                    sb.AppendFormat("insert into tb_fbCustomerShips values('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}')",
                        txtFbId.Text.Trim(), curMarketFbId, cbxShipType.SelectedItem.ToString(), cbxCustomerType.SelectedItem.ToString(), 
                        txtInGoods.Text.Trim(), txtNote.Text.Trim(), ckbTraceDate.Checked ? 1 : 0, 
                        dateTimePicker1.Value.ToString("yyyy-MM-dd"), DateTime.Now.ToString());
                    db.InsertData(sb.ToString());
                }

                //3. 聊天摘要
                if (txtNewContact.Text.Trim() != "")
                {
                    sb.Clear();
                    sb.AppendFormat("insert into tb_fbCustomerContacts values('{0}','{1}','{2}','{3}','{4}')",
                        curMarketFbId, curMarketFbAccount, txtFbId.Text.Trim(), DateTime.Now.ToString(), txtNewContact.Text.Trim());
                    db.InsertData(sb.ToString());
                }

                //保存成功
                MessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.bAdd = false;
                this.curCustomerFbId = this.txtFbId.Text.Trim();
                this.txtNewContact.Text = "";
                this.MyComponentInit();
                this.MyFrmInit();
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

        //4. Input check
        private bool InputCheck()
        {
            if (txtFbUrl.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入客户首页！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtFbUrl.Focus();
                return false;
            }

            if (txtFbId.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请点击\"获取\"读取客户编号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtFbId.Focus();
                return false;
            }

            if (txtName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入客户姓名！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtName.Focus();
                return false;
            }

            return true;
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            if (txtFbId.Text.Trim() == "" || this.bAdd)
            {
                MessageBox.Show("客户不存在，请先添加客户！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmOrderAdd frm = new FrmOrderAdd();
            this.pFrmMain.AddPage(frm, "新增订单");

            frm.bAdmin = this.bAdmin;
            frm.bAdd = true;
            frm.curMarketFbId = this.curMarketFbId;
            frm.curMarketFbAccount = curMarketFbAccount;
            frm.curCustomerFbId = txtFbId.Text.Trim();
            frm.pFrmMain = this.pFrmMain;

            frm.MyFrmInit();
            frm.Show();
        }

        private void btnLastOrder_Click(object sender, EventArgs e)
        {
            if (txtFbId.Text.Trim() == "" || this.bAdd)
            {
                MessageBox.Show("客户不存在，请先添加客户！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string lastOrderId = "";
            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbOrders where marketFbId='{0}' and customerFbId='{1}' and " +
                    "lastEditTime in (select max(lastEditTime) from tb_fbOrders where marketFbId='{2}' and customerFbId='{3}')",
                    curMarketFbId, txtFbId.Text.Trim(), curMarketFbId, txtFbId.Text.Trim());
                FbOrderInfo lastEditOrder = (FbOrderInfo)db.GetObject(sb.ToString(), "tb_fbOrders");
                if (lastEditOrder == null)
                {
                    MessageBox.Show("此客户没有订单！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lastOrderId = lastEditOrder.orderId;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "数据库异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "程序异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            FrmOrderAdd frm = new FrmOrderAdd();
            this.pFrmMain.AddPage(frm, "编辑订单");

            frm.bAdmin = this.bAdmin;
            frm.bAdd = false;
            frm.curOrderId = lastOrderId;
            frm.curMarketFbId = this.curMarketFbId;
            frm.curMarketFbAccount = curMarketFbAccount;

            frm.MyFrmInit();
            frm.Show();
        }
    }
}
