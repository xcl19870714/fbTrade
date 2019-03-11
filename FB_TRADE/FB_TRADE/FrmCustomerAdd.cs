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
        public bool bAdd;
        public string curMarketFbId;
        public string curMarketFbAccount;

        private DBCommon db = new DBCommon();
        private string sql;

        public FrmCustomerAdd()
        {
            InitializeComponent();

            this.cbxShipType.Items.Clear();
            this.cbxShipType.Items.Add(new ListItem("好友", "1"));
            this.cbxShipType.Items.Add(new ListItem("非好友", "2"));
            this.cbxShipType.Items.Add(new ListItem("屏蔽", "3"));
            this.cbxShipType.SelectedItem = ListItem.FindByText(cbxShipType, "好友");

            this.cbxCustomerType.Items.Clear();
            this.cbxCustomerType.Items.Add(new ListItem("意向客户", "1"));
            this.cbxCustomerType.Items.Add(new ListItem("批发客户", "2"));
            this.cbxCustomerType.Items.Add(new ListItem("零售客户", "3"));
            this.cbxCustomerType.SelectedItem = ListItem.FindByText(cbxCustomerType, "意向客户");
        }

        public void MyFrmInit()
        {

        }

        //1. Graph Shows


        //2. Data Shows
        private void InitListViewContacts()
        {
            try
            {
                listViewContacts.Clear();
                listViewContacts.Columns.Add("关系人", 100, HorizontalAlignment.Left);
                listViewContacts.Columns.Add("时间", 100, HorizontalAlignment.Left);
                listViewContacts.Columns.Add("聊天摘要", 100, HorizontalAlignment.Left);
                listViewContacts.Items.Clear();

                sql = "select * from tb_fbCustomerContacts where marketFbId='" + curMarketFbId +
                    "' and customerFbId='" + txtFbId.Text.Trim() + "'";
                List<FbCustomerContactInfo> contactList = (List<FbCustomerContactInfo>)db.GetList(sql, "tb_fbCustomerContacts");
                foreach (var contact in contactList)
                {
                    ListViewItem it = new ListViewItem();

                    it.Text = contact.marketFbAccount;
                    it.SubItems.Add(contact.time);
                    it.SubItems.Add(contact.content);
                    listViewContacts.Items.Add(it);
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

        //3. Operations
        private void btnGet_Click(object sender, EventArgs e)
        {
            if (txtFbUrl.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入客户首页！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtFbUrl.Focus();
                return;
            }

            try
            {
                FbCustomerInfo fbCustomer;
                sql = "select * from tb_fbCustomers where fbUrl='" + txtFbUrl.Text.Trim() + "'";

                fbCustomer = (FbCustomerInfo)db.GetObect(sql, "tb_fbCustomers");
                if (fbCustomer != null)
                {
                    txtFbId.Text = fbCustomer.fbId;
                    txtName.Text = fbCustomer.name;
                    txtEmail.Text = fbCustomer.email;
                    txtFriendShips.Text = fbCustomer.friendsNum.ToString();
                    txtCountry.Text = fbCustomer.country;
                    txtState.Text = fbCustomer.state;
                    txtCity.Text = fbCustomer.city;
                    txtIntroduction.Text = fbCustomer.introduction;
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
                        return;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!InputCheck())
                return;

            try
            {
                //1. fb_tbCustomers
                sql = "select count(*) from tb_fbCustomers where fbUrl='" + txtFbUrl.Text.Trim() + "'";
                if (db.CheckExist(sql)) //编辑
                {
                    sql = "update tb_fbCustomers set name='" + txtName.Text.Trim() +
                        "',fbUrl='" + txtFbUrl.Text.Trim() +
                        "',friendsNum=" + Convert.ToInt32(txtFriendsNum.Text.Trim()) +
                        ",country='" + txtCountry.Text.Trim() + "',state='" + txtState.Text.Trim() +
                        "',city='" + txtCity.Text.Trim() + "',email='" + txtEmail.Text.Trim() +
                        "',introduction='" + txtIntroduction.Text.Trim()
                        + "' where fbId='" + txtFbId.Text.Trim() + "'";

                    db.UpdateData(sql);
                }
                else //新增
                {
                    sql = "insert into tb_fbCustomers values('" + txtFbId.Text.Trim() + "','" + txtName.Text.Trim() +
                        "','" + txtFbUrl.Text.Trim() +
                        "'," + Convert.ToInt32(txtFriendsNum.Text.Trim()) +
                        ",'" + txtCountry.Text.Trim() + "','" + txtState.Text.Trim() +
                        "','" + txtCity.Text.Trim() + "','" + txtEmail.Text.Trim() +
                        "','" + txtIntroduction.Text.Trim() + "')";
                    db.InsertData(sql);
                }

                //2. fb_tbCustomerShips
                sql = "select count(*) from fb_tbCustomerShips where customerFbId='" + txtFbId.Text.Trim() +
                    "' and marketFbId='" + this.curMarketFbId + "'";
                if (db.CheckExist(sql)) //编辑
                {
                    sql = "update fb_tbCustomerShips set shipType='" + cbxShipType.SelectedText +
                        "',customerType='" + cbxCustomerType.SelectedText +
                        "',interestedGoods='" + txtInGoods.Text.Trim() +
                        "',note='" + txtNote.Text.Trim() +
                        (ckbTraceDate.Checked ? ("',traceDate='" + dateTimePicker1.Value.ToString()) : "") +
                        "' where customerFbId='" + txtFbId.Text.Trim() +
                        "' and marketFbId='" + this.curMarketFbId + "'";

                    db.UpdateData(sql);
                }
                else //新增
                {
                    System.DateTime currentTime = new System.DateTime();
                    sql = "insert into tb_fbCustomerShips values('" + txtFbId.Text.Trim() + "','" + curMarketFbId +
                        "','" + cbxShipType.SelectedText +
                        "',’" + cbxCustomerType.SelectedText +
                        "','" + txtInGoods.Text.Trim() + "','" + txtNote.Text.Trim() +
                        "','" + (ckbTraceDate.Checked ? dateTimePicker1.Value.ToString() : "") +
                        currentTime.ToString() + "')";
                    db.InsertData(sql);
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
                MessageBox.Show("请输入客户昵称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtName.Focus();
                return false;
            }

            return true;
        }

        private void btnNewContactSave_Click(object sender, EventArgs e)
        {
            if (txtNewContact.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入聊天摘要！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNewContact.Focus();
                return;
            }

            btnSave_Click(sender, e);

            try
            {
                System.DateTime currentTime = new System.DateTime();
                sql = "insert into tb_fbCustomerContacts values('" + curMarketFbAccount + "','" + txtFbId.Text.Trim() +
                    "','" + currentTime.ToString() +
                    "',’" + txtNewContact + "')";
                db.InsertData(sql);
                InitListViewContacts();
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
