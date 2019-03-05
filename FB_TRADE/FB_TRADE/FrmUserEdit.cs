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
    public partial class FrmUserEdit : Form
    {
        public string curId;
        public FrmUserList pFrm;

        private DBCommon db = new DBCommon();
        private string sqlStr = string.Empty;

		//1. Shows
        public FrmUserEdit()
        {
            InitializeComponent();
        }

        public void MyInitFrm()
        {
            try
            {
                sqlStr = "select * from tb_users where id='" + Convert.ToString(curId) + "'";
                UserInfo user = (UserInfo)db.GetObect(sqlStr, "tb_users");

                if (user != null)
                {
                    this.txtName.Text = user.Name;
                    this.txtPwd.Text = user.Pwd;
                }
                else
                {
                    MessageBox.Show("账号不存在，请刷新账号列表！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
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


		//2. Operations
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
                return;

            try
            {
                sqlStr = "update tb_users set name='" + txtName.Text.Trim() + "',pwd='" + txtPwd.Text.Trim() + "' where id='" + Convert.ToString(curId) + "'";

                if (db.UpdateData(sqlStr))
                {
                    MessageBox.Show("信息修改成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.pFrm.LoadListViewDB();
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

		private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		
		//3. Input Check
        private bool CheckInput()
        {
            if (txtName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("账号不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtName.Focus();
                return false;
            }
            if (txtPwd.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("密码不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPwd.Focus();
                return false;
            }
            return true;
        }
    }
}
