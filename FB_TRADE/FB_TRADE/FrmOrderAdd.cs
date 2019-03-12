using System;
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
    public partial class FrmOrderAdd : Form
    {
        public bool bAdd;
        public string curCustomerFbId = string.Empty;

        public string curOrderId = string.Empty;

        public string curMarketFbId = string.Empty;
        public string curMarketFbAccount = string.Empty;

        private DBCommon db = new DBCommon();
        private string sql = string.Empty;

        ImageList imglist = new ImageList();

        public FrmOrderAdd()
        {
            InitializeComponent();

            this.cbxOrderType.Items.Clear();
            this.cbxOrderType.Items.Add("订单");
            this.cbxOrderType.Items.Add("分期付款单");
            this.cbxOrderType.Items.Add("售后单");
            this.cbxOrderType.SelectedText = "订单";

            this.cbxShipType.Items.Clear();
            this.cbxShipType.Items.Add("EMS");
            this.cbxShipType.Items.Add("Other");
            this.cbxShipType.SelectedText = "EMS";

            this.cbxCurrency.Items.Clear();
            this.cbxCurrency.Items.Add("AUD");
            this.cbxCurrency.Items.Add("NZD");
            this.cbxCurrency.Items.Add("USD");
            this.cbxCurrency.Items.Add("CAD");
            this.cbxCurrency.Items.Add("EUR");
            this.cbxCurrency.Items.Add("GBP");
            this.cbxCurrency.Items.Add("台币");
            this.cbxCurrency.Items.Add("人民币");
            this.cbxCurrency.Items.Add("Other");
            this.cbxCurrency.SelectedText = "AUD";

            this.cbxPayType.Items.Clear();
            this.cbxPayType.Items.Add("Paypal");
            this.cbxPayType.Items.Add("Credit Card");
            this.cbxPayType.Items.Add("Western Union");
            this.cbxPayType.Items.Add("货到付款");
            this.cbxPayType.Items.Add("Other");
            this.cbxPayType.SelectedText = "Paypal";

            txtShipType.Visible = (cbxShipType.SelectedText != "Other");
            txtCurrency.Visible = (cbxCurrency.SelectedText != "Other");
            txtPayType.Visible = (txtPayType.SelectedText != "Other");
        }

        public void MyInitFrm()
        {
            labelCurMarketAccount.Text = curMarketFbAccount;

            if (bAdd)
                txtCustomerId.Text = curCustomerFbId;


        }

        public void InitListViewGoods()
        {
            listViewGoods.Clear();
            listViewGoods.Columns.Add("Photo", 100, HorizontalAlignment.Left);
            listViewGoods.Columns.Add("Color", 100, HorizontalAlignment.Left);
            listViewGoods.Columns.Add("Size", 100, HorizontalAlignment.Left);
            listViewGoods.Columns.Add("Price", 100, HorizontalAlignment.Left);
            listViewGoods.Columns.Add("Amount", 100, HorizontalAlignment.Left);
            listViewGoods.Columns.Add("Total Price", 100, HorizontalAlignment.Left);
            listViewGoods.Items.Clear();

            imglist.ImageSize = new Size(48, 48);
            imglist.ColorDepth = ColorDepth.Depth32Bit;
            listViewGoods.LargeImageList = imglist;
        }

        private void cbxShipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtShipType.Visible  = (cbxShipType.SelectedText != "Other");
        }

        private void cbxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCurrency.Visible = (cbxCurrency.SelectedText != "Other");
        }

        private void cbxPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPayType.Visible = (txtPayType.SelectedText != "Other");
        }

        private void btnInsertGoods_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage() == false)
            {
                MessageBox.Show("剪切板没有截图，请先截图！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Image img = Clipboard.GetImage();
            Clipboard.Clear();

            imglist.Images.Add(img);

            ListViewItem it = new ListViewItem();
            it.Text = "";
            it.ImageIndex = imglist.Images.Count - 1;
            it.SubItems.Add(fb.name);
            it.SubItems.Add(fb.fbAccount);
            it.SubItems.Add(fb.fbPwd);
            it.SubItems.Add(fb.fbUrl);
            it.SubItems.Add(fb.note);
            it.SubItems.Add(tmp.Name);
            this.listViewGoods.Items.Add(it);
        }

        //1. Grath Shows

        //2. Data Shows

        //3. Operations

        //4. Input Check

    }
}
