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
    public partial class FrmMarketFbList : Form
    {
        public bool bAdmin;
        public string curAdminId;
        public string curUserId;

        private Button btnDel = new System.Windows.Forms.Button();
        private Button btnEdit = new System.Windows.Forms.Button();

        private DBCommon db = new DBCommon();
        private string sqlStr = string.Empty;

        //1. Show
        public FrmMarketFbList()
        {
            InitializeComponent();

            this.listViewMarketFbs.ListViewItemSorter = new ListViewColumnSorter();
            this.listViewMarketFbs.ColumnClick += new ColumnClickEventHandler(ListViewHelper.ListView_ColumnClick);
        }

        //2. MyShow
        public void MyInitFrm()
        {
            //编辑和删除按钮
            btnEdit.Visible = false;
            btnEdit.Text = "编辑";
            btnEdit.Click += this.btnEdit_Click;
            btnDel.Size = new Size(70, 20);
            this.listViewMarketFbs.Controls.Add(btnEdit);

            btnDel.Visible = false;
            btnDel.Text = "删除";
            btnDel.Click += this.btnDel_Click;
            btnDel.Size = new System.Drawing.Size(70, 20);
            this.listViewMarketFbs.Controls.Add(btnDel);

            LoadListViewDB();
        }

        public void LoadListViewDB()
        {
            try
            {
                if (curUserId == "0")
                    sqlStr = "select * from tb_fbMarketAccounts where userId in (select id from tb_users where adminId=" + curAdminId + ")";
                else
                    sqlStr = "select * from tb_fbMarketAccounts where userId='" + curUserId + "'";

                List<FbMarketAccountInfo> fbList = (List<FbMarketAccountInfo>)db.GetList(sqlStr, "tb_fbMarketAccounts");

                this.listViewMarketFbs.FullRowSelect = true;
                this.listViewMarketFbs.View = System.Windows.Forms.View.Details;
                this.listViewMarketFbs.SelectedIndexChanged += new System.EventHandler(this.listViewMarketFbs_SelectedIndexChanged);
                this.listViewMarketFbs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewMarketFbs_MouseDoubleClick);

                listViewMarketFbs.Clear();
                listViewMarketFbs.Columns.Add("facebook ID", 100, HorizontalAlignment.Left);
                listViewMarketFbs.Columns.Add("姓名", 100, HorizontalAlignment.Left);
                listViewMarketFbs.Columns.Add("facebook账号", 100, HorizontalAlignment.Left);
                listViewMarketFbs.Columns.Add("facebook密码", 100, HorizontalAlignment.Left);
                listViewMarketFbs.Columns.Add("facebook首页链接", 100, HorizontalAlignment.Left);
                listViewMarketFbs.Columns.Add("备注", 100, HorizontalAlignment.Left);
                listViewMarketFbs.Columns.Add("所属子账号", 100, HorizontalAlignment.Left);
                listViewMarketFbs.Columns.Add("", 50, HorizontalAlignment.Left);
                listViewMarketFbs.Columns.Add("", 50, HorizontalAlignment.Left);

                listViewMarketFbs.Items.Clear();
                foreach (var fb in fbList)
                {
                    ListViewItem it = new ListViewItem();
                    UserInfo tmp = (UserInfo)db.GetObect("select * from tb_users where id='" + fb.userId + "'", "tb_users");

                    it.Text = Convert.ToString(fb.fbId);
                    it.SubItems.Add(fb.name);
                    it.SubItems.Add(fb.fbAccount);
                    it.SubItems.Add(fb.fbPwd);
                    it.SubItems.Add(fb.fbUrl);
                    it.SubItems.Add(fb.note);
                    it.SubItems.Add(tmp.Name);
                    it.SubItems.Add("");
                    it.SubItems.Add("");
                    listViewMarketFbs.Items.Add(it);
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

        //3. operations
        private void btnMarketFbAdd_Click(object sender, EventArgs e)
        {
            FrmMarketFbAdd frm = new FrmMarketFbAdd();

            frm.bAdd = true;
            frm.curAdminId = this.curAdminId;
            frm.curUserId = this.curUserId;
            frm.pFrm = this;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            frm.Text = "新增营销号";
            frm.MyInitFrm();
            frm.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult choice = MessageBox.Show("确定要删除吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (choice == DialogResult.Yes)
                {
                    sqlStr = "delete from tb_fbMarketAccounts where fbId='" + this.listViewMarketFbs.SelectedItems[0].SubItems[0].Text + "'";
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
            FrmMarketFbAdd frm = new FrmMarketFbAdd();
            frm.bAdd = false;
            frm.curMarketFbId = this.listViewMarketFbs.SelectedItems[0].SubItems[0].Text;
            frm.curAdminId = this.curAdminId;
            frm.curUserId = this.curUserId;
            frm.pFrm = this;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            frm.Text = "编辑营销号";
            frm.MyInitFrm();
            frm.ShowDialog();
        }

        private void listViewMarketFbs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = this.listViewMarketFbs.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                FrmMarketFbAdd frm = new FrmMarketFbAdd();
                frm.bAdd = false;
                frm.curMarketFbId = info.Item.Text;
                frm.curAdminId = this.curAdminId;
                frm.curUserId = this.curUserId;
                frm.pFrm = this;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                frm.Text = "编辑营销号";
                frm.MyInitFrm();
                frm.ShowDialog();
            }
        }

        private void listViewMarketFbs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewMarketFbs.SelectedItems.Count > 0)
            {
                this.btnEdit.Location = new Point(this.listViewMarketFbs.SelectedItems[0].SubItems[7].Bounds.Left,
                    this.listViewMarketFbs.SelectedItems[0].SubItems[7].Bounds.Top);
                this.btnEdit.Size = new Size(this.listViewMarketFbs.SelectedItems[0].SubItems[7].Bounds.Width,
                    this.listViewMarketFbs.SelectedItems[0].SubItems[7].Bounds.Height);
                this.btnEdit.Visible = true;

                this.btnDel.Location = new Point(this.listViewMarketFbs.SelectedItems[0].SubItems[8].Bounds.Left,
                    this.listViewMarketFbs.SelectedItems[0].SubItems[8].Bounds.Top);
                this.btnDel.Size = new Size(this.listViewMarketFbs.SelectedItems[0].SubItems[8].Bounds.Width,
                    this.listViewMarketFbs.SelectedItems[0].SubItems[8].Bounds.Height);
                this.btnDel.Visible = true;
            }
        }
    }
}
