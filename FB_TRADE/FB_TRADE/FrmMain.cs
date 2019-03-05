using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FbTrade.Models;
using System.Data.SqlClient;
using FbTrade.DAL;

namespace FB_TRADE
{
    public partial class FrmMain : Form
    {
        public bool bAdmin = false;
        public AdminInfo adminInfo;
        public UserInfo userInfo;

        private DBCommon db = new DBCommon();
        private string sqlStr = string.Empty;

		//1. Shows
        public FrmMain()
        {
            InitializeComponent();
        }

        public void MyInitFrm()
        {
            ShowWelLabel();

            if (!bAdmin)
            {
                this.cbxUser.Visible = false;
                this.cbxFbAccount.Size = new System.Drawing.Size(160, 28);
                this.btnUserList.Visible = false;
            }
            else
            {
                //init子账号下拉框
                InitUserCbx();
            }
        }

        public void ShowWelLabel()
        {
            this.labelHello.Text = "Hi, " + (bAdmin ? adminInfo.Name : userInfo.Name) + ":";
        }

        public void InitUserCbx()
        {
            try
            {
                sqlStr = "select * from tb_users where adminId=" + Convert.ToString(adminInfo.Id);
                List<UserInfo> userList = (List<UserInfo>)db.GetList(sqlStr, "tb_users");

                this.cbxUser.Items.Add(new ItemObject("--ALL--", "0"));
                foreach (var user in userList)
                {
                    this.cbxUser.Items.Add(new ItemObject(user.Name, Convert.ToString(user.Id)));
                }

                //if (this.cbxUser.Text.Trim().Equals(string.Empty))
                //    this.cbxUser.SelectedIndex = 0;
                //this.cbxUser.SelectedIndex = this.cbxUser.Items.IndexOf("子账号");
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
        private void btnSelfInfoChg_Click(object sender, EventArgs e)
        {
            FrmSelfInfoEdit frm = new FrmSelfInfoEdit();

            frm.bAdmin = true;
            frm.adminInfo = this.adminInfo;
            frm.userInfo = this.userInfo;
            frm.pFrm = this;

            frm.MyInitFrm();
            frm.ShowDialog();
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            FrmUserList frmUserList = new FrmUserList();
            frmUserList.adminId = Convert.ToString(this.adminInfo.Id);
            frmUserList.MyInitFrm();

			//在哪里显示
            frmUserList.TopLevel = false; // 不是最顶层窗体
            panelContent.Controls.Add(frmUserList);

			frmUserList.Show();
        }
    }
}
