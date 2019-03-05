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
using FbTrade.Models;
using FbTrade.DAL;

namespace FB_TRADE
{
    public partial class frm_login : Form
    {
        private DBCommon db = new DBCommon();
        private string sqlStr = string.Empty;
       
        public frm_login()
        {
            InitializeComponent();
            this.cbxRole.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //输入检查
                if (!CheckInput())
                    return;

                bool bAdmin = (cbxRole.SelectedIndex == 1);
                string tb = (bAdmin ? "tb_admins" : "tb_users");
                Object obj = null;

                sqlStr = "select * from " + tb + " where name='" + txtLoginName.Text.Trim() + "' and pwd='" + txtLoginPwd.Text.Trim() + "'";
                if ((obj = db.GetObect(sqlStr, tb)) == null)
                {
                    sqlStr = "select count(*) from " + tb + " where name='" + txtLoginName.Text.Trim() + "'";
                    if (!db.CheckExist(sqlStr))
                    {
                        MessageBox.Show("账号不存在！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("账号与密码不匹配！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    FrmMain frm = new FrmMain();

                    frm.bAdmin = bAdmin;
                    if (bAdmin)
                        frm.adminInfo = (AdminInfo)obj;
                    else
                        frm.userInfo = (UserInfo)obj;
                    frm.MyInitFrm();

                    this.Hide();
                    frm.ShowDialog();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "数据库异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "程序异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.btnLogin_Click(sender, e);//触发button事件  
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckInput()
        {
            if (this.txtLoginName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入用户名", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtLoginName.Focus();
                return false;
            }
            else if (this.txtLoginPwd.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入密码", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtLoginPwd.Focus();
                return false;
            }
            else if (this.cbxRole.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请选择角色", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cbxRole.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
