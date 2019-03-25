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
        public string curUserName;

        public FrmMarketFbList pFrm;

        public bool bAdd;
        public string curMarketFbId;

        private DBCommon db = new DBCommon();
        private string sqlStr;

        //1. 界面构造
        public FrmMarketFbAdd()
        {
            InitializeComponent();
        }

        //2. 数据加载
        public void MyFrmInit()
        {
            try
            { 
                // Init user id cbx
                if (bAdmin)
                {
                    List<UserInfo> userList = (List<UserInfo>)db.GetList("select * from tb_users where adminId=" + curAdminId, "tb_users");

                    this.cbxUserId.Items.Add(new ListItem("请选择", "0"));
                    foreach (var user in userList)
                    {
                        this.cbxUserId.Items.Add(new ListItem(user.Name, Convert.ToString(user.Id)));
                    }
                }
                else
                {
                    UserInfo user = (UserInfo)db.GetObject("select * from tb_users where id=" + curUserId, "tb_users");
                    this.cbxUserId.Items.Add(new ListItem(user.Name, Convert.ToString(user.Id)));
                }
                

                // Add or Edit
                if (!bAdd)
                {
                    sqlStr = "select * from tb_fbMarketAccounts where fbId='" + curMarketFbId + "'";
                    FbMarketAccountInfo fbMarket = (FbMarketAccountInfo)db.GetObject(sqlStr, "tb_fbMarketAccounts");

                    this.txtFbId.Text = fbMarket.fbId;
                    this.txtName.Text = fbMarket.name;
                    this.txtFbAccount.Text = fbMarket.fbAccount;
                    this.txtFbPwd.Text = fbMarket.fbPwd;
                    this.txtFbUrl.Text = fbMarket.fbUrl;
                    this.txtNote.Text = fbMarket.note;
                    this.cbxUserId.SelectedItem = ListItem.FindByValue(cbxUserId, Convert.ToString(fbMarket.userId));
                }
                else
                {
                    if (curUserId == "0")
                        this.cbxUserId.SelectedItem = ListItem.FindByText(cbxUserId, "请选择");
                    else
                        this.cbxUserId.SelectedItem = ListItem.FindByValue(cbxUserId, curUserId);
                }

                if (!bAdmin)
                    this.cbxUserId.Enabled = false;
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

        //2. 操作
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
                return;

            try
            {
                if (bAdd) //新增
                {
                    sqlStr = "select count(*) from tb_fbMarketAccounts where fbId='" + txtFbId.Text.Trim() + "'";
                    if (db.CheckExist(sqlStr))
                    {
                        MessageBox.Show("facebook ID已经存在，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtFbId.Focus();
                        return;
                    }

                    sqlStr = "select count(*) from tb_fbMarketAccounts where name='" + txtName.Text.Trim() + "'";
                    if (db.CheckExist(sqlStr))
                    {
                        MessageBox.Show("姓名已经存在，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtName.Focus();
                        return;
                    }

                    sqlStr = "select count(*) from tb_fbMarketAccounts where fbAccount='" + txtFbAccount.Text.Trim() + "'";
                    if (db.CheckExist(sqlStr))
                    {
                        MessageBox.Show("facebook登陆账号已经存在，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtFbAccount.Focus();
                        return;
                    }

                    ListItem coSelected = (ListItem)this.cbxUserId.SelectedItem;
                    sqlStr = "insert into tb_fbMarketAccounts values('" + txtFbId.Text.Trim() + "','" +
                    txtName.Text.Trim() + "','" + txtFbAccount.Text.Trim() + "','" +
                    txtFbPwd.Text.Trim() + "','" + txtFbUrl.Text.Trim() + "','" +
                    txtNote.Text.Trim() + "'," + coSelected.Value + ",'" + DateTime.Now.ToString()  +"')";
                    if (db.InsertData(sqlStr))
                    {
                        MessageBox.Show("营销号创建成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.pFrm.LoadListViewDB();
                        this.Close();
                    }
                    else
                        MessageBox.Show("营销号创建失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else //编辑
                {
                    ListItem coSelected = (ListItem)this.cbxUserId.SelectedItem;

                    sqlStr = "update tb_fbMarketAccounts set fbId='" + txtFbId.Text.Trim() + "',name='" +
                    txtName.Text.Trim() + "',fbAccount='" + txtFbAccount.Text.Trim() + "',fbPwd='" +
                    txtFbPwd.Text.Trim() + "',fbUrl='" + txtFbUrl.Text.Trim() + "',note='" +
                    txtNote.Text.Trim() + "',userId=" + coSelected.Value + " where fbId='" + curMarketFbId + "'";
                    if (db.UpdateData(sqlStr))
                    {
                        MessageBox.Show("营销号信息修改成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.pFrm.LoadListViewDB();
                        this.Close();
                    }
                    else
                        MessageBox.Show("营销号信息修改失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //3. Input Check
        private bool CheckInput()
        {
            if (txtFbId.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入facebook ID！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFbId.Focus();
                return false;
            }
            if (txtName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入姓名！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtName.Focus();
                return false;
            }
            if (txtFbAccount.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入facebook账号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFbAccount.Focus();
                return false;
            }
            if (txtFbPwd.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入facebook登陆密码！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFbPwd.Focus();
                return false;
            }

            ListItem coSelected = (ListItem)this.cbxUserId.SelectedItem;
            if (coSelected.Text.Equals("请选择"))
            {
                MessageBox.Show("请选择子账号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cbxUserId.Focus();
                return false;
            }
            
            return true;
        }
    }
}
