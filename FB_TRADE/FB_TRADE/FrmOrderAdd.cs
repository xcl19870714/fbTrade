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
using System.IO;

namespace FB_TRADE
{
    public partial class FrmOrderAdd : Form
    {
        public string curMarketFbId = string.Empty;
        public string curMarketFbAccount = string.Empty;

        //Add
        public bool bAdd;
        public string curCustomerFbId = string.Empty;

        //Edit
        public string curOrderId = string.Empty;

        private DBCommon db = new DBCommon();
        private string sql = string.Empty;

        private ImageList imglist = new ImageList();

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

            InitOrderInfo();
            InitCustomerNameAndDefaultAddressChckbox();

        }

        private void InitOrderInfo()
        {
            if (bAdd)
            {
                txtCustomerId.Text = curCustomerFbId;
                return;
            }

            try
            {
                sql = "select * from tb_orders where orderid='" + curOrderId + "'";
                FbOrderInfo order = (FbOrderInfo)db.GetObject(sql, "tb_orders");

                if (order == null)
                {
                    MessageBox.Show("读取订单失败，此订单可能已被删除！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                curCustomerFbId = order.customerFbId;
                txtCustomerId.Text = curCustomerFbId;

                txtOrderId.Text = order.orderId;
                cbxOrderType.SelectedText = order.orderType;
                txtOriOrderId.Text = order.oriOrderId;

                cbxShipType.SelectedText = order.shippingType;
                if (cbxShipType.SelectedIndex < 0)
                {
                    cbxShipType.SelectedText = "Other";
                    txtShipType.Visible = true;
                    txtShipType.Text = order.shippingType;
                }
                txtShipFee.Text = order.shippingFee;
                txtTrackingNo.Text = order.shippingNo;
                txtPayAmount.Text = order.totalPrice;

                cbxCurrency.SelectedText = order.currency;
                if (cbxCurrency.SelectedIndex < 0)
                {
                    cbxCurrency.SelectedText = "Other";
                    txtCurrency.Visible = true;
                    txtCurrency.Text = order.currency;
                }
                cbxPayType.SelectedText = order.paymentType;
                if (cbxPayType.SelectedIndex < 0)
                {
                    cbxPayType.SelectedText = "Other";
                    txtPayType.Visible = true;
                    txtPayType.Text = order.paymentType;
                }
                txtPayNo.Text = order.paymentNo;

                txtShippingName.Text = order.shippingName;
                txtShippingPhone.Text = order.shippingPhone;
                txtShippingAddress.Text = order.shippingAddress;

                labelOrderStatus.Text = order.status;
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

        private void InitCustomerNameAndDefaultAddressChckbox()
        {
            try
            {
                sql = "select * from tb_fbCustomers where fbid='" + curCustomerFbId + "'";
                FbCustomerInfo customer = (FbCustomerInfo)db.GetObject(sql, "tb_fbCustomers");

                if (customer == null)
                {
                    MessageBox.Show("获取客户失败，此客户可能已被删除！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtCustomerName.Text = customer.name;

                if (customer.shipName == txtShippingName.Text.Trim() && 
                    customer.shipPhone == txtShippingPhone.Text.Trim() &&
                    customer.shipAddress == txtShippingAddress.Text.Trim())
                {
                    chkbSetDefaultAddress.Checked = true;
                }
                else
                    chkbSetDefaultAddress.Checked = false;
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

        private Image BytesToImage(byte[] streamByte)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(streamByte);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            return img;
        }

        private byte[] ImageToBytes(Image img)
        {
            MemoryStream mstream = new MemoryStream();
            img.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length); mstream.Close();
            return byData;
        }

        public void InitListViewGoods()
        {
            listViewGoods.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));
            listViewGoods.View = View.Details;           //将view属性设为Details。
            listViewGoods.LabelEdit = true;              //允许用户编辑文本项。
            listViewGoods.AllowColumnReorder = true;     //允许用户重排列。
            listViewGoods.CheckBoxes = true;            //显示check boxes。
            listViewGoods.FullRowSelect = true;          //允许选择项及其子项。
            listViewGoods.GridLines = true;              //显示行列的网格线。

            listViewGoods.Clear();
            listViewGoods.Columns.Add("Photo", 100, HorizontalAlignment.Left);
            listViewGoods.Columns.Add("Color", 100, HorizontalAlignment.Left);
            listViewGoods.Columns.Add("Size", 100, HorizontalAlignment.Left);
            listViewGoods.Columns.Add("Price", 100, HorizontalAlignment.Left);
            listViewGoods.Columns.Add("Amount", 100, HorizontalAlignment.Left);
            listViewGoods.Columns.Add("Total Price", 100, HorizontalAlignment.Left);

            listViewGoods.Items.Clear();

            imglist.ImageSize = new Size(50, 50);
            //imglist.ColorDepth = ColorDepth.Depth32Bit;
            listViewGoods.SmallImageList = imglist;

            if (bAdd)
                return;

            try
            {
                sql = "select * from tb_fbOrderGoods where orderId='" + curOrderId + "'";
                List<fbOrderGoodsInfo> goodsList = (List<fbOrderGoodsInfo>)db.GetList(sql, "tb_fbOrderGoods");

                foreach (var goods in goodsList)
                {
                    ListViewItem it = new ListViewItem();

					Image img;
                    MemoryStream ms = new MemoryStream(goods.photo, 0, goods.photo.Length);
                    img = Image.FromStream(ms);
                    ms.Close();
                    imglist.Images.Add(img);

					it.ImageIndex = imglist.Images.Count - 1;
                    it.Text = "";
					it.Tag = goods.id.ToString();
                    it.SubItems.Add(goods.color);
                    it.SubItems.Add(goods.size);
					it.SubItems.Add(goods.price);
					it.SubItems.Add(goods.amount);
                    it.SubItems.Add(Convert.ToString(Convert.ToDouble(goods.price) * Convert.ToInt32(goods.amount)));
                    listViewGoods.Items.Add(it);
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
            imglist.Images.Add(img);
            Clipboard.Clear();

            ListViewItem it = new ListViewItem();
            it.Text = "";
            it.Tag = "";
            it.ImageIndex = imglist.Images.Count - 1;
            it.SubItems.Add("0");
            it.SubItems.Add("0");
			it.SubItems.Add("0");
			it.SubItems.Add("0");
            it.SubItems.Add("0");
            listViewGoods.Items.Add(it);
        }

        private void btnDelGoods_Click(object sender, EventArgs e)
        {

        }

        //订单状态改变规则：
        //新增订单：save：save。submit：根据信息完整性，未确认金额，未发货，已发货。
        //编辑订单：save：原状态为save的还是为save，原状态为其他的，根据信息状态修改。submit：根据信息状态修改，对于delete单，重新生效。delete：废弃单。
        private string getNewOrderStatus(string operate)
        {
            string curStatus = labelOrderStatus.Text.Trim();
            string ret = "";

            switch (operate)
            {
                case "Save":
                    if (curStatus == "未保存")
                        ret = "未提交";
                    else if (curStatus == "废弃单")
                        ret = "废弃单";
                    else //未确认金额,未发货,已发货
                    {
                        if (txtPayAmount.Text.Trim() == "")
                            ret = "未确认金额";
                        else if (this.txtTrackingNo.Text.Trim() == "")
                            ret = "未发货";
                        else// if (this.txtTrackingNo.Text.Trim() != "")
                            ret = "已发货";
                    }
                    break;
                case "Submit":
                    if (txtPayAmount.Text.Trim() == "")
                        ret = "未确认金额";
                    else if (this.txtTrackingNo.Text.Trim() == "")
                        ret = "未发货";
                    else// if (this.txtTrackingNo.Text.Trim() != "")
                        ret = "已发货";
                    break;
                case "Delete":
                    ret = "废弃单";
                    break;
                default:
                    break;
            }

            return ret;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //1. tb_fbOrders
                if (bAdd)
                {   
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("insert into tb_fbOrders(customerFbId, marketFbid, orderType, oriOrderId, " +
                        "createTime, lastEditTime, status, shippingAddress, shippingName, shippingPhone, shippingType, shippingFee, shippingNo, " +
                        "currency, totalPrice, paymentType, paymentNo, note) " +
                        "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')", 
                        txtCustomerId.Text.Trim(), curMarketFbId, cbxOrderType.SelectedText, txtOriOrderId, 
                        DateTime.Now.ToString(), DateTime.Now.ToString(), getNewOrderStatus("Save"), txtShippingAddress.Text.Trim(), txtShippingName.Text.Trim(), 
                        (cbxShipType.SelectedText == "Other" ? txtShipType.Text.Trim() : cbxShipType.SelectedText), txtShipFee.Text.Trim(), txtTrackingNo.Text.Trim(),
                        (cbxCurrency.SelectedText == "Other" ? txtCurrency.Text.Trim() : cbxCurrency.SelectedText), txtPayAmount.Text.Trim(),
                        (cbxPayType.SelectedText == "Other" ? txtPayType.Text.Trim() : cbxPayType.SelectedText), txtPayNo.Text.Trim(), txtPayNo.Text.Trim(), txtNote.Text.Trim());
                    db.InsertData(sb.ToString());
                }
                else // Edit
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("Update tb_fbOrders set orderType='{0}', oriOrderId='{1}', lastEditTime='{2}', status='{3}', shippingAddress='{4}'," +
                        "shippingName='{5}',shippingType='{6}',shippingFee='{7}',shippingNo='{8}',currency='{9}',totalPrice='{10}',paymentType='{11}',paymentNo='{12}'," +
                        "note='{14}' where orderId='{15}'",
                        cbxOrderType.SelectedText, txtOriOrderId, DateTime.Now.ToString(), getNewOrderStatus("Save"), 
                        txtShippingAddress.Text.Trim(), txtShippingName.Text.Trim(),
                        (cbxShipType.SelectedText == "Other" ? txtShipType.Text.Trim() : cbxShipType.SelectedText), txtShipFee.Text.Trim(), txtTrackingNo.Text.Trim(),
                        (cbxCurrency.SelectedText == "Other" ? txtCurrency.Text.Trim() : cbxCurrency.SelectedText), txtPayAmount.Text.Trim(),
                        (cbxPayType.SelectedText == "Other" ? txtPayType.Text.Trim() : cbxPayType.SelectedText), txtPayNo.Text.Trim(), txtPayNo.Text.Trim(),
                        txtNote.Text.Trim(), curOrderId);
                    db.UpdateData(sb.ToString());
                }

                //2. tb_fbOrderGoods
                if (bAdd)
                {
                    //获取此marketFbId，customerFbId最新创建的orderId
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("select * from tb_fbOrders where marketFbId='{0}' and customerFbId='{1}' and " +
                        "createTime in (select max(createTime) from tb_fbOrders where marketFbId='{3}' and customerFbId='{4}')", 
                        curMarketFbId, txtCustomerId.Text.Trim(), curMarketFbId, txtCustomerId.Text.Trim());
                    FbOrderInfo newOrder = (FbOrderInfo)db.GetObject(sb.ToString(), "tb_fbOrders");
                    curOrderId = newOrder.orderId;
                }
                foreach (ListViewItem item in this.listViewGoods.Items)
                {
                    if (item.Tag.ToString() == "")
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("insert into tb_fbOrderGoods(orderId, photo, color, size, price, amount) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", 
                            curOrderId, ImageToBytes(imglist.Images[item.ImageIndex]), item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text);
                        db.InsertData(sql);
                    }
                }

                //3. reShow
                FrmOrderAdd newFrm = new FrmOrderAdd();
                this.Hide();
                newFrm.bAdd = false;
                newFrm.curOrderId = curOrderId;
                newFrm.curMarketFbId = curMarketFbId;
                newFrm.curMarketFbAccount = curMarketFbAccount;
                newFrm.curCustomerFbId = curCustomerFbId;
                newFrm.MyInitFrm();
                this.Close();
                newFrm.Show();
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //1. tb_fbOrders
                if (bAdd)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("insert into tb_fbOrders(customerFbId, marketFbid, orderType, oriOrderId, " +
                        "createTime, lastEditTime, status, shippingAddress, shippingName, shippingPhone, shippingType, shippingFee, shippingNo, " +
                        "currency, totalPrice, paymentType, paymentNo, note) " +
                        "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')",
                        txtCustomerId.Text.Trim(), curMarketFbId, cbxOrderType.SelectedText, txtOriOrderId,
                        DateTime.Now.ToString(), DateTime.Now.ToString(), getNewOrderStatus("Submit"), txtShippingAddress.Text.Trim(), txtShippingName.Text.Trim(),
                        (cbxShipType.SelectedText == "Other" ? txtShipType.Text.Trim() : cbxShipType.SelectedText), txtShipFee.Text.Trim(), txtTrackingNo.Text.Trim(),
                        (cbxCurrency.SelectedText == "Other" ? txtCurrency.Text.Trim() : cbxCurrency.SelectedText), txtPayAmount.Text.Trim(),
                        (cbxPayType.SelectedText == "Other" ? txtPayType.Text.Trim() : cbxPayType.SelectedText), txtPayNo.Text.Trim(), txtPayNo.Text.Trim(), txtNote.Text.Trim());
                    db.InsertData(sb.ToString());
                }
                else // Edit
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("Update tb_fbOrders set orderType='{0}', oriOrderId='{1}', lastEditTime='{2}', status='{3}', shippingAddress='{4}'," +
                        "shippingName='{5}',shippingType='{6}',shippingFee='{7}',shippingNo='{8}',currency='{9}',totalPrice='{10}',paymentType='{11}',paymentNo='{12}'," +
                        "note='{14}' where orderId='{15}'",
                        cbxOrderType.SelectedText, txtOriOrderId, DateTime.Now.ToString(), getNewOrderStatus("Submit"),
                        txtShippingAddress.Text.Trim(), txtShippingName.Text.Trim(),
                        (cbxShipType.SelectedText == "Other" ? txtShipType.Text.Trim() : cbxShipType.SelectedText), txtShipFee.Text.Trim(), txtTrackingNo.Text.Trim(),
                        (cbxCurrency.SelectedText == "Other" ? txtCurrency.Text.Trim() : cbxCurrency.SelectedText), txtPayAmount.Text.Trim(),
                        (cbxPayType.SelectedText == "Other" ? txtPayType.Text.Trim() : cbxPayType.SelectedText), txtPayNo.Text.Trim(), txtPayNo.Text.Trim(),
                        txtNote.Text.Trim(), curOrderId);
                    db.UpdateData(sb.ToString());
                }

                //2. tb_fbOrderGoods
                if (bAdd)
                {
                    //获取此marketFbId，customerFbId最新创建的orderId
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("select * from tb_fbOrders where marketFbId='{0}' and customerFbId='{1}' and " +
                        "createTime in (select max(createTime) from tb_fbOrders where marketFbId='{3}' and customerFbId='{4}')",
                        curMarketFbId, txtCustomerId.Text.Trim(), curMarketFbId, txtCustomerId.Text.Trim());
                    FbOrderInfo newOrder = (FbOrderInfo)db.GetObject(sb.ToString(), "tb_fbOrders");
                    curOrderId = newOrder.orderId;
                }
                foreach (ListViewItem item in this.listViewGoods.Items)
                {
                    if (item.Tag.ToString() == "")
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("insert into tb_fbOrderGoods(orderId, photo, color, size, price, amount) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                            curOrderId, ImageToBytes(imglist.Images[item.ImageIndex]), item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text);
                        db.InsertData(sql);
                    }
                }

                //3. reShow
                FrmOrderAdd newFrm = new FrmOrderAdd();
                this.Hide();
                newFrm.bAdd = false;
                newFrm.curOrderId = curOrderId;
                newFrm.curMarketFbId = curMarketFbId;
                newFrm.curMarketFbAccount = curMarketFbAccount;
                newFrm.curCustomerFbId = curCustomerFbId;
                newFrm.MyInitFrm();
                this.Close();
                newFrm.Show();
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

        private void btnOrderDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (bAdd)
                {
                    MessageBox.Show("新增订单不能废弃，请直接关闭窗口！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else // Edit
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("Update tb_fbOrders set status='废弃单' where orderId='{0}'", curOrderId);
                    db.UpdateData(sb.ToString());
                }

                //3. reShow
                FrmOrderAdd newFrm = new FrmOrderAdd();
                this.Hide();
                newFrm.bAdd = false;
                newFrm.curOrderId = curOrderId;
                newFrm.curMarketFbId = curMarketFbId;
                newFrm.curMarketFbAccount = curMarketFbAccount;
                newFrm.curCustomerFbId = curCustomerFbId;
                newFrm.MyInitFrm();
                this.Close();
                newFrm.Show();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //1. Grath Shows

        //2. Data Shows

        //3. Operations

        //4. Input Check

    }
}
