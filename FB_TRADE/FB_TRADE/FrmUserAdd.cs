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
    public partial class FrmUserAdd : Form
    {
        public string adminId;
        public FrmUserList pFrm;

        private DBCommon db = new DBCommon();
        private string sqlStr = string.Empty;

		//1. Shows
        public FrmUserAdd()
        {
            InitializeComponent();
        }

		//2. Operations
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
                return;

            try
            {
                sqlStr = "select count(*) from tb_users where name='" + txtName.Text.Trim() + "'";
                if (db.CheckExist(sqlStr))
                {
                    MessageBox.Show("子账号已经存在，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sqlStr = "insert into tb_users(name,pwd,adminId) values('" + txtName.Text.Trim() + "','" + txtPwd.Text.Trim() + "'," + adminId + ")";
                if (db.InsertData(sqlStr))
                {
                    MessageBox.Show("子账号创建成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.pFrm.LoadListViewDB();
                    this.Close();
                }
                else
                    MessageBox.Show("子账号创建失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("请输入账号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtName.Focus();
                return false;
            }
            if (txtPwd.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入密码！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPwd.Focus();
                return false;
            }
            return true;
        }
    }
}
