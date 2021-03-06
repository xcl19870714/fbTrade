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
    public partial class frm_login : Form
    {
        private DBCommon db = new DBCommon();
        private StringBuilder sb = new StringBuilder();

		//1. 界面构造
        public frm_login()
        {
            InitializeComponent();
            MyComponentInit();
        }

        private void MyComponentInit()
        {
            this.cbxRole.Items.Clear();
            this.cbxRole.Items.Add("普通用户");
            this.cbxRole.Items.Add("管理员");
            cbxRole.SelectedIndex = 0;
        }

		//2. 操作
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckInput())
                    return;

                bool bAdmin = (cbxRole.SelectedItem.ToString() == "管理员");
                string tb = (bAdmin ? "tb_admins" : "tb_users");
                Object obj = null;

                sb.Clear();
                sb.AppendFormat("select * from {0} where name='{1}' and pwd='{2}'", 
                    tb, txtLoginName.Text.Trim(), txtLoginPwd.Text.Trim());
                if ((obj = db.GetObject(sb.ToString(), tb)) == null)
                {
                    sb.Clear();
                    sb.AppendFormat("select count(*) from {0} where name='{1}'", tb, txtLoginName.Text.Trim());
                    if (!db.CheckExist(sb.ToString()))
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
                    frm.MyFrmInit();

                    this.Hide();
                    frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.btnLogin_Click(sender, e);//触发button事件  
            }
        }

		//3. 输入检查
        private bool CheckInput()
        {
            if (this.txtLoginName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入账号", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
