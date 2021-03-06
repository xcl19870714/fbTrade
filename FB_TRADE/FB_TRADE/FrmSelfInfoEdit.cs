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
    public partial class FrmSelfInfoEdit : Form
    {
        public bool bAdmin;
        public AdminInfo adminInfo;
        public UserInfo userInfo;
        public FrmMain pFrmMain;

        private DBCommon db = new DBCommon();
        private string sqlStr = string.Empty;

		//1. Shows
        public FrmSelfInfoEdit()
        {
            InitializeComponent();
        }
		
        public void MyFrmInit()
        {
            this.txtName.Text = (bAdmin ? adminInfo.Name : userInfo.Name);
        }

		//2. Operations
        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
                return;

            try
            {
                string tbl = (bAdmin ? "tb_admins" : "tb_users");
                sqlStr = "update " + tbl + " set name='" + txtName.Text.Trim() + "', pwd='" + txtNewPwd.Text.Trim() + "' where id=" + (bAdmin ? adminInfo.Id : userInfo.Id);
                
                if (db.UpdateData(sqlStr))
                {
                    MessageBox.Show("信息修改成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (bAdmin)
                    {
                        pFrmMain.adminInfo.Name = txtName.Text.Trim();
                        pFrmMain.adminInfo.Pwd = txtNewPwd.Text.Trim();
                    }
                    else
                    {
                        pFrmMain.userInfo.Name = txtName.Text.Trim();
                        pFrmMain.userInfo.Pwd = txtNewPwd.Text.Trim();
                    }

                    pFrmMain.ShowWelLabel();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("信息修改失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

		//3. Input Check
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
                MessageBox.Show("原密码不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
