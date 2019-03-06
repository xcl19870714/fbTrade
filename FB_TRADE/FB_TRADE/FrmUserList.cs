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
    public partial class FrmUserList : Form
    {
        public string adminId;
		
        private Button btnDel = new System.Windows.Forms.Button();
        private Button btnEdit = new System.Windows.Forms.Button();

        private DBCommon db = new DBCommon();
        private string sqlStr = string.Empty;

		//1. Shows
        public FrmUserList()
        {
            InitializeComponent();
        }

        public void MyInitFrm()
        {
            //编辑和删除按钮
            btnEdit.Visible = false;
            btnEdit.Text = "编辑";
            btnEdit.Click += this.btnEdit_Click;
            btnDel.Size = new Size(70, 20);
            this.listViewUser.Controls.Add(btnEdit);

            btnDel.Visible = false;
            btnDel.Text = "删除";
            btnDel.Click += this.btnDel_Click;
            btnDel.Size = new System.Drawing.Size(70, 20);
            this.listViewUser.Controls.Add(btnDel);

            LoadListViewDB();
        }

		public void LoadListViewDB()
        {
            try
            {
                sqlStr = "select * from tb_users where adminId='" + adminId + "'";
                List<UserInfo> userList = (List<UserInfo>)db.GetList(sqlStr, "tb_users");

                listViewUser.Clear();
                listViewUser.Columns.Add("ID", 100, HorizontalAlignment.Left);
                listViewUser.Columns.Add("账号", 100, HorizontalAlignment.Left);
                listViewUser.Columns.Add("密码", 100, HorizontalAlignment.Left);
                listViewUser.Columns.Add("所属管理员", 100, HorizontalAlignment.Left);
                listViewUser.Columns.Add("", 50, HorizontalAlignment.Left);
                listViewUser.Columns.Add("", 50, HorizontalAlignment.Left);

                listViewUser.Items.Clear();
                foreach (var user in userList)
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = Convert.ToString(user.Id);
                    it.SubItems.Add(user.Name);
                    it.SubItems.Add(user.Pwd);
                    it.SubItems.Add(user.AdminName);
                    it.SubItems.Add("");
                    it.SubItems.Add("");
                    listViewUser.Items.Add(it);
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
		private void btnAddUser_Click(object sender, EventArgs e)
        {
            FrmUserAdd frm = new FrmUserAdd();

            frm.adminId = this.adminId;
            frm.pFrm = this;
            frm.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult choice = MessageBox.Show("确定要删除吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (choice == DialogResult.Yes)
                {
                    sqlStr = "delete from tb_users where id=" + this.listViewUser.SelectedItems[0].SubItems[0].Text;
                    db.DeleteData(sqlStr);
                    this.LoadListViewDB();
                }
                else
                    return;
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmUserEdit frm = new FrmUserEdit();
            frm.curId = this.listViewUser.SelectedItems[0].SubItems[0].Text;
            frm.pFrm = this;
            frm.MyInitFrm();
            frm.ShowDialog();
        }

        private void listViewUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = this.listViewUser.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                FrmUserEdit frm = new FrmUserEdit();
                frm.curId = info.Item.Text;
                frm.pFrm = this;
                frm.MyInitFrm();
                frm.ShowDialog();
            }
        }
		
        private void listViewUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewUser.SelectedItems.Count > 0)
            {
                this.btnEdit.Location = new Point(this.listViewUser.SelectedItems[0].SubItems[4].Bounds.Left,
                    this.listViewUser.SelectedItems[0].SubItems[4].Bounds.Top);
                this.btnEdit.Size = new Size(this.listViewUser.SelectedItems[0].SubItems[4].Bounds.Width,
                    this.listViewUser.SelectedItems[0].SubItems[4].Bounds.Height);
                this.btnEdit.Visible = true;

                this.btnDel.Location = new Point(this.listViewUser.SelectedItems[0].SubItems[5].Bounds.Left,
                    this.listViewUser.SelectedItems[0].SubItems[5].Bounds.Top);
                this.btnDel.Size = new Size(this.listViewUser.SelectedItems[0].SubItems[5].Bounds.Width,
                    this.listViewUser.SelectedItems[0].SubItems[5].Bounds.Height);
                this.btnDel.Visible = true;
            }
        }
    }
}
