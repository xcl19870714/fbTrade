﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FB_Trade_DAL;
using System.Data.SqlClient;
using FB_Trade_Models;

namespace FB_TRADE
{
    public partial class FrmMain : Form
    {
        public bool bAdmin = false;
        public AdminInfo adminInfo;
        public UserInfo userInfo;

        private DBCommon db = new DBCommon();
        private StringBuilder sb = new StringBuilder();

        private const int CLOSE_SIZE = 12;
        private int tabindex_show = 0;
        private int tabindex_close = 0;

        //1. Graph Shows
        public FrmMain()
        {
            InitializeComponent();
            SetBtnListCenter();
            InitTabControl();
            tabControlMain.Controls.Clear();
        }
        private void SetBtnListCenter()
        {
            SetBtnLocationCenter(this.splitContainer1.Panel1, btnFbAccountList);
            SetBtnLocationCenter(this.splitContainer1.Panel1, btnCustomerNotify);
            SetBtnLocationCenter(this.splitContainer1.Panel1, btnCustomerControl);
            SetBtnLocationCenter(this.splitContainer1.Panel1, btnGroupControl);
            SetBtnLocationCenter(this.splitContainer1.Panel1, btnOrderList);
            SetBtnLocationCenter(this.splitContainer1.Panel1, btnOldCustomers);
        }
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            SetBtnListCenter();
        }

        private void SetBtnLocationCenter(Panel panel, Button btn)
        {
            int x = (int)(0.5 * (panel.Width - btn.Width));
            int y = btn.Location.Y;
            btn.Location = new System.Drawing.Point(x, y);
        }

        private void InitTabControl() //在选项卡上添加关闭按钮
        {

            this.tabControlMain.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControlMain.Padding = new System.Drawing.Point(CLOSE_SIZE, CLOSE_SIZE);
            this.tabControlMain.DrawItem += new DrawItemEventHandler(this.TabControlMain_DrawItem1);
            this.tabControlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabControlMain_MouseDown1);
        }

        private void TabControlMain_DrawItem1(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            try
            {
                Rectangle myTabRect = this.tabControlMain.GetTabRect(e.Index);

                //先添加TabPage属性   
                e.Graphics.DrawString(this.tabControlMain.TabPages[e.Index].Text, this.Font, SystemBrushes.ControlText, myTabRect.X + 2, myTabRect.Y + 2);

                //再画一个矩形框
                using (Pen p = new Pen(Color.Black))
                {
                    myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                    myTabRect.Width = CLOSE_SIZE;
                    myTabRect.Height = CLOSE_SIZE;
                    e.Graphics.DrawRectangle(p, myTabRect);
                }

                //填充矩形框
                Color recColor = e.State == DrawItemState.Selected ? Color.IndianRed : Color.DarkGray;
                using (Brush b = new SolidBrush(recColor))
                {
                    e.Graphics.FillRectangle(b, myTabRect);
                }

                //画关闭符号
                using (Pen p = new Pen(Color.White))
                {
                    //画"/"线
                    Point p1 = new Point(myTabRect.X + 3, myTabRect.Y + 3);
                    Point p2 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + myTabRect.Height - 3);
                    e.Graphics.DrawLine(p, p1, p2);

                    //画"/"线
                    Point p3 = new Point(myTabRect.X + 3, myTabRect.Y + myTabRect.Height - 3);
                    Point p4 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + 3);
                    e.Graphics.DrawLine(p, p3, p4);
                }

                e.Graphics.Dispose();
            }
            catch (Exception ex)
            {

            }
        }

        private void TabControlMain_MouseDown1(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X, y = e.Y;

                //计算关闭区域   
                Rectangle myTabRect = this.tabControlMain.GetTabRect(this.tabControlMain.SelectedIndex);

                myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                myTabRect.Width = CLOSE_SIZE;
                myTabRect.Height = CLOSE_SIZE;

                //如果鼠标在区域内就关闭选项卡   
                bool isClose = x > myTabRect.X && x < myTabRect.Right && y > myTabRect.Y && y < myTabRect.Bottom;
                if (isClose == true)
                {
                    //比较关闭的页面索引与正在显示的页面的索引
                    tabindex_close = this.tabControlMain.SelectedIndex >= tabindex_show ? this.tabControlMain.SelectedIndex : tabindex_close - 1;
                    this.tabControlMain.TabPages.Remove(this.tabControlMain.SelectedTab);
                }
                else
                {
                    tabindex_close = this.tabControlMain.SelectedIndex;
                    tabindex_show = this.tabControlMain.SelectedIndex;
                }
                if (tabindex_close < tabindex_show)
                {
                    tabindex_show = tabindex_show - 1;

                }

                //显示页面
                try { this.tabControlMain.SelectedTab = this.tabControlMain.TabPages[tabindex_show]; }
                catch (Exception ex) { }
            }
        }

        //2. Data Shows
        public void MyInitFrm()
        {
            InitUserCbx();
            InitMarketFbCbx();
            ShowWelLabel();

            if (!bAdmin)
            {
                this.cbxUser.Visible = false;
                this.cbxFbAccount.Size = new System.Drawing.Size(160, 28);
                this.btnUserList.Visible = false;
            }
        }

        public void ShowWelLabel()
        {
            this.labelHello.Text = "Hi, " + (bAdmin ? adminInfo.Name : userInfo.Name) + ":";
        }

        public void InitUserCbx()
        {
            if (!bAdmin)
            {
                this.cbxUser.Items.Clear();
                this.cbxUser.Items.Add(new ListItem(this.userInfo.Name, this.userInfo.Id.ToString()));
                this.cbxUser.SelectedItem = ListItem.FindByText1(cbxUser, this.userInfo.Name);
            }
            else
            {
                this.cbxUser.Items.Clear();
                this.cbxUser.Items.Add(new ListItem("子账号", "0"));
                this.cbxUser.SelectedItem = ListItem.FindByText1(cbxUser, "子账号");

                try
                {
                    sb.Clear();
                    sb.AppendFormat("select * from tb_users where adminId={0}", Convert.ToString(adminInfo.Id));
                    List<UserInfo> userList = (List<UserInfo>)db.GetList(sb.ToString(), "tb_users");
                    foreach (var user in userList)
                    {
                        this.cbxUser.Items.Add(new ListItem(user.Name, Convert.ToString(user.Id)));
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
        }

        public void InitMarketFbCbx()
        {
            this.cbxFbAccount.Items.Clear();
            this.cbxFbAccount.Items.Add(new ListItem("营销号", "0"));
            this.cbxFbAccount.SelectedItem = ListItem.FindByText1(cbxFbAccount, "营销号");

            ListItem selItem = (ListItem)this.cbxUser.SelectedItem;
            if (selItem.Text == "子账号")
                return;

            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbMarketAccounts where userId={0}", selItem.Value);
                List<FbMarketAccountInfo> marketFbList = (List<FbMarketAccountInfo>)db.GetList(sb.ToString(), "tb_fbMarketAccounts");

                foreach (var fb in marketFbList)
                {
                    this.cbxFbAccount.Items.Add(new ListItem(fb.name, fb.fbId));
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

        private void cbxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitMarketFbCbx();
        }

        //2. Operations
        //=================================================================================================//
        private void btnSelfInfoChg_Click(object sender, EventArgs e)
        {
            FrmSelfInfoEdit frm = new FrmSelfInfoEdit();

            frm.bAdmin = this.bAdmin;
            frm.adminInfo = this.adminInfo;
            frm.userInfo = this.userInfo;
            frm.pFrm = this;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            frm.MyInitFrm();
            frm.ShowDialog();
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            FrmUserList frmUserList = new FrmUserList();
           
			frmUserList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frmUserList.TopLevel = false;
            frmUserList.Dock = DockStyle.Fill;
            frmUserList.WindowState = FormWindowState.Maximized;//如果windowState设置为最大化，添加到tabPage中时，winform不会显示出来

            TabPage tabPage = new System.Windows.Forms.TabPage();
            tabPage.Text = "子账号列表";
            this.tabControlMain.Controls.Add(tabPage);
            //tabPage.Controls.Clear();
            tabPage.Controls.Add(frmUserList);
            this.tabControlMain.SelectedTab = tabPage;

            frmUserList.adminId = Convert.ToString(this.adminInfo.Id);
            frmUserList.MyInitFrm();
            frmUserList.Show();
            frmUserList.ListViewResize();
            tabindex_show = this.tabControlMain.SelectedIndex;
        }

        private void btnFbAccountList_Click(object sender, EventArgs e)
        {
            FrmMarketFbList frm = new FrmMarketFbList();

            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.WindowState = FormWindowState.Maximized;//如果windowState设置为最大化，添加到tabPage中时，winform不会显示出来

            TabPage tabPage = new System.Windows.Forms.TabPage();
            tabPage.Text = "营销号列表";
            this.tabControlMain.Controls.Add(tabPage);
            tabPage.Controls.Add(frm);
            this.tabControlMain.SelectedTab = tabPage;

            frm.bAdmin = this.bAdmin;
            if (bAdmin)
                frm.curAdminId = Convert.ToString(this.adminInfo.Id);
            ListItem coSelected = (ListItem)this.cbxUser.SelectedItem;
            frm.curUserId = coSelected.Value;
            frm.MyInitFrm();
            frm.Show();
            frm.ListViewResize();

            tabindex_show = this.tabControlMain.SelectedIndex;
        }

        private void btnCustomerControl_Click(object sender, EventArgs e)
        {
            if (this.cbxUser.SelectedItem.ToString() == "子账号" || this.cbxFbAccount.SelectedItem.ToString() == "营销号")
            {
                MessageBox.Show("请先选择营销号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbxFbAccount.Focus();
                return;
            }

            FrmCustomers frm = new FrmCustomers();
            ListItem item = (ListItem)this.cbxFbAccount.SelectedItem;
            frm.bAdmin = this.bAdmin;
            frm.curMarketFbId = item.Value;
            frm.curMarketFbAccount = item.Text;

            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.WindowState = FormWindowState.Maximized;//如果windowState设置为最大化，添加到tabPage中时，winform不会显示出来

            TabPage tabPage = new System.Windows.Forms.TabPage();
            tabPage.Text = "客户列表";
            this.tabControlMain.Controls.Add(tabPage);
            tabPage.Controls.Add(frm);
            this.tabControlMain.SelectedTab = tabPage;

            frm.MyInitFrm();
            frm.Show();
            frm.ListViewResize();

            tabindex_show = this.tabControlMain.SelectedIndex;
        }

        private void btnGroupControl_Click(object sender, EventArgs e)
        {

        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomerNotify_Click(object sender, EventArgs e)
        {

        }
    }
}
