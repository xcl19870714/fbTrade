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
        public string curAdminId;
		
        private DBCommon db = new DBCommon();
        private string sqlStr = string.Empty;

		//1. Shows
        public FrmUserList()
        {
            InitializeComponent();
            MyComponentInit();
        }

        private void MyComponentInit()
        {
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ShowItemToolTips = false;

            this.listViewUser.View = System.Windows.Forms.View.Details;
            this.listViewUser.FullRowSelect = true;
            listViewUser.CheckBoxes = true;
            this.listViewUser.GridLines = true;

            this.listViewUser.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewUser_MouseDoubleClick);
            this.listViewUser.ListViewItemSorter = new ListViewColumnSorter();
            this.listViewUser.ColumnClick += new ColumnClickEventHandler(ListViewHelper.ListView_ColumnClick);

            listViewUser.Clear();
            listViewUser.Columns.Add("ID", listViewUser.Width / 100 * 20, HorizontalAlignment.Left);
            listViewUser.Columns.Add("账号", listViewUser.Width / 100 * 20, HorizontalAlignment.Left);
            listViewUser.Columns.Add("密码", listViewUser.Width / 100 * 20, HorizontalAlignment.Left);
            listViewUser.Columns.Add("备注", listViewUser.Width / 100 * 20, HorizontalAlignment.Left);
            listViewUser.Columns.Add("创建时间", listViewUser.Width / 100 * 20, HorizontalAlignment.Left);
        }

        public void ListViewResize()
        {
            foreach (ColumnHeader item in listViewUser.Columns)
            {
                item.TextAlign = HorizontalAlignment.Left;
                switch (item.Text)
                {
                    case "ID":
                        item.Width = (this.listViewUser.Width / 100) * 20;
                        break;
                    case "账号":
                        item.Width = (this.listViewUser.Width / 100) * 20;
                        break;
                    case "密码":
                        item.Width = (this.listViewUser.Width / 100) * 20;
                        break;
                    case "备注":
                        item.Width = (this.listViewUser.Width / 100) * 20;
                        break;
                    case "创建时间":
                        item.Width = (this.listViewUser.Width / 100) * 20;
                        break;
                    default:
                        item.Width = -2;
                        break;
                }
            }
        }

        public void MyFrmInit()
        {
            LoadListViewDB();
        }

		public void LoadListViewDB()
        {
            try
            { 
                listViewUser.Items.Clear();

                sqlStr = "select * from tb_users where adminId='" + curAdminId + "'";
                List<UserInfo> userList = (List<UserInfo>)db.GetList(sqlStr, "tb_users");
                foreach (var user in userList)
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = Convert.ToString(user.Id);
                    it.SubItems.Add(user.Name);
                    it.SubItems.Add(user.Pwd);
                    it.SubItems.Add(user.Note);
                    it.SubItems.Add(user.CreateTime);
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

            frm.adminId = this.curAdminId;
            frm.pFrm = this;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                frm.MyFrmInit();
                frm.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewUser.CheckedItems.Count < 1)
            {
                MessageBox.Show("没有选中的条目！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult choice = MessageBox.Show("确定要删除吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (choice == DialogResult.No)
                return;

            for (int i = 0; i < listViewUser.CheckedItems.Count; i++)
            {
                try
                {
                    sqlStr = "delete from tb_users where id=" + this.listViewUser.CheckedItems[i].SubItems[0].Text;
                    db.DeleteData(sqlStr);
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

            this.LoadListViewDB();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadListViewDB();
        }
    }
}
