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
    public partial class FrmSelfInfoEdit : Form
    {
        public bool bAdmin;
        public AdminInfo adminInfo;
        public UserInfo userInfo;
        public FrmMain pFrm;

        private DBCommon db = new DBCommon();
        private string sqlStr = string.Empty;
        
        public FrmSelfInfoEdit()
        {
            InitializeComponent();
        }

        public void MyInitFrm()
        {
            this.txtName.Text = (bAdmin ? adminInfo.Name : userInfo.Name);
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
                return;

            try
            {
                string tbl = (bAdmin ? "tb_admins" : "tb_users");
                sqlStr = "update " + tbl + " set name='" + txtName.Text.Trim() + "', pwd='" + txtNewPwd.Text.Trim() + "' where name='" + (bAdmin ? adminInfo.Name : userInfo.Name) + "'";
                
                if (db.UpdateData(sqlStr))
                {
                    MessageBox.Show("密码修改成功，下次登陆生效！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (bAdmin)
                    {
                        pFrm.adminInfo.Name = txtName.Text.Trim();
                        pFrm.adminInfo.Pwd = txtNewPwd.Text.Trim();
                    }
                    else
                    {
                        pFrm.userInfo.Name = txtName.Text.Trim();
                        pFrm.userInfo.Pwd = txtNewPwd.Text.Trim();
                    }

                    pFrm.ShowWelLabel();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码修改失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckInput()
        {
            if (this.txtName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("账号不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtName.Focus();
                return false;
            }
            if (this.txtOldPwd.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("旧密码不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtOldPwd.Focus();
                return false;
            }
            if (this.txtNewPwd.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("新密码不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNewPwd.Focus();
                return false;
            }
            if (this.txtCfmPwd.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("确认密码不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCfmPwd.Focus();
                return false;
            }
            if (!txtNewPwd.Text.Trim().Equals(txtCfmPwd.Text.Trim()))
            {
                MessageBox.Show("两次输入的密码不一致！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNewPwd.Focus();
                return false;
            }
            if (!txtOldPwd.Text.Trim().Equals((bAdmin ? adminInfo.Pwd : userInfo.Pwd)))
            {
                MessageBox.Show("旧密码错误！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtOldPwd.Focus();
                return false;
            }
       
            return true;
        }
    }
}
