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
using System.Configuration;
using System.Data.SqlClient;
using FB_Trade_Models;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace FB_TRADE
{
    public partial class FrmOrderAdd : Form
    {
        public bool bAdmin = false;

        public string curMarketFbId = string.Empty;
        public string curMarketFbAccount = string.Empty;
        //Add
        public bool bAdd = true;
        public string curCustomerFbId = string.Empty;
        public string orderAddType = string.Empty;
        public string orderAddFrom = string.Empty;
        //Edit
        public string curOrderId = string.Empty;

        public FrmMain pFrmMain;

        private DBCommon db = new DBCommon();
        private StringBuilder sb = new StringBuilder();

        //辅助函数
        private Image BytesToImage(byte[] streamByte)
        {
            MemoryStream ms = new MemoryStream(streamByte);
            Image image = System.Drawing.Image.FromStream(ms);
            ms.Close();
            return image;
        }

        private byte[] ImageToBytes(Image image)
        {
            try
            {
                if (image == null) return null;
                using (Bitmap bitmap = new Bitmap(image))
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        bitmap.Save(stream, ImageFormat.Jpeg);
                        return stream.GetBuffer();
                    }
                }
            }
            finally
            {
                if (image != null)
                {
                    image.Dispose();
                    image = null;
                }
            }

            //ImageFormat format = image.RawFormat;
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    if (format.Equals(ImageFormat.Jpeg))
            //    {
            //        image.Save(ms, ImageFormat.Jpeg);
            //    }
            //    else if (format.Equals(ImageFormat.Png))
            //    {
            //        image.Save(ms, ImageFormat.Png);
            //    }
            //    else if (format.Equals(ImageFormat.Bmp))
            //    {
            //        image.Save(ms, ImageFormat.Bmp);
            //    }
            //    else if (format.Equals(ImageFormat.Gif))
            //    {
            //        image.Save(ms, ImageFormat.Gif);
            //    }
            //    else if (format.Equals(ImageFormat.Icon))
            //    {
            //        image.Save(ms, ImageFormat.Icon);
            //    }
            //    byte[] buffer = new byte[ms.Length];
            //    //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
            //    ms.Seek(0, SeekOrigin.Begin);
            //    ms.Read(buffer, 0, buffer.Length);
            //    return buffer;
            //}

            //    MemoryStream mstream = new MemoryStream();
            //    img.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            //    byte[] byData = new Byte[mstream.Length];
            //    mstream.Position = 0;
            //    mstream.Read(byData, 0, byData.Length);
            //    mstream.Close();
            //    return byData;
        }

        private string CreateImageFromBytes(string fileName, byte[] buffer)
        {
            string file = fileName;
            Image image = BytesToImage(buffer);
            ImageFormat format = image.RawFormat;
            if (format.Equals(ImageFormat.Jpeg))
            {
                file += ".jpeg";
            }
            else if (format.Equals(ImageFormat.Png))
            {
                file += ".png";
            }
            else if (format.Equals(ImageFormat.Bmp))
            {
                file += ".bmp";
            }
            else if (format.Equals(ImageFormat.Gif))
            {
                file += ".gif";
            }
            else if (format.Equals(ImageFormat.Icon))
            {
                file += ".icon";
            }
            System.IO.FileInfo info = new System.IO.FileInfo(file);
            System.IO.Directory.CreateDirectory(info.Directory.FullName);
            File.WriteAllBytes(file, buffer);
            return file;
        }

        private static bool IsDigital(string value)
        {
            if (value == "")
                return false;
            else
                return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }

        //1. 构造界面
        public FrmOrderAdd()
        {
            InitializeComponent();
            MyComponentInit();
        }

        private void MyComponentInit()
        {
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ShowItemToolTips = false;

            this.cbxOrderType.Items.Clear();
            this.cbxOrderType.Items.Add("订单");
            this.cbxOrderType.Items.Add("分期付款单");
            this.cbxOrderType.Items.Add("售后单");
            this.cbxOrderType.SelectedIndex = 0;

            this.cbxShipType.Items.Clear();
            this.cbxShipType.Items.Add("EMS");
            this.cbxShipType.Items.Add("Other");
            this.cbxShipType.SelectedIndex = 0;

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
            this.cbxCurrency.SelectedIndex = 0;

            this.cbxPayType.Items.Clear();
            this.cbxPayType.Items.Add("Paypal");
            this.cbxPayType.Items.Add("Credit Card");
            this.cbxPayType.Items.Add("Western Union");
            this.cbxPayType.Items.Add("货到付款");
            this.cbxPayType.Items.Add("Other");
            this.cbxPayType.SelectedIndex = 0;

            this.labelChangedNotify.Visible = false;

            txtShipType.Visible = false;
            txtCurrency.Visible = false;
            txtPayType.Visible = false;

            btnCheckCustomerExist.Visible = false;

            dataGridViewGoods.AllowUserToAddRows = false;
            dataGridViewGoods.RowHeadersVisible = false;
            dataGridViewGoods.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

            DataGridViewCheckBoxColumn columnCheckbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            columnCheckbox.HeaderText = "";
            columnCheckbox.Name = "checkbox";
            columnCheckbox.Width = dataGridViewGoods.Width / 100 * 3;
            DataGridViewTextBoxColumn columnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            columnId.HeaderText = "id";
            columnId.Name = "id";
            columnId.Width = dataGridViewGoods.Width / 100 * 0;
            columnId.Visible = false;
            DataGridViewImageColumn columnPhoto = new System.Windows.Forms.DataGridViewImageColumn();
            columnPhoto.HeaderText = "Photo";
            columnPhoto.Name = "photo";
            columnPhoto.Width = dataGridViewGoods.Width / 100 * 5;
            DataGridViewTextBoxColumn columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            columnName.HeaderText = "Name";
            columnName.Name = "name";
            columnName.Width = dataGridViewGoods.Width / 100 * 27;
            DataGridViewTextBoxColumn columnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            columnColor.HeaderText = "Color";
            columnColor.Name = "color";
            columnColor.Width = dataGridViewGoods.Width / 100 * 10;
            DataGridViewTextBoxColumn columnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            columnSize.HeaderText = "Size";
            columnSize.Name = "size";
            columnSize.Width = dataGridViewGoods.Width / 100 * 10;
            DataGridViewTextBoxColumn columnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            columnPrice.HeaderText = "Price";
            columnPrice.Name = "price";
            columnPrice.Width = dataGridViewGoods.Width / 100 * 10;
            DataGridViewTextBoxColumn columnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            columnAmount.HeaderText = "Amount";
            columnAmount.Name = "amount";
            columnAmount.Width = dataGridViewGoods.Width / 100 * 10;
            DataGridViewTextBoxColumn columnTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            columnTotalPrice.HeaderText = "Total Price";
            columnTotalPrice.Name = "totalPrice";
            columnTotalPrice.Width = dataGridViewGoods.Width / 100 * 35;

            dataGridViewGoods.Columns.Clear();
            dataGridViewGoods.Columns.Add(columnCheckbox);
            dataGridViewGoods.Columns.Add(columnId);
            dataGridViewGoods.Columns.Add(columnPhoto);
            dataGridViewGoods.Columns.Add(columnName);
            dataGridViewGoods.Columns.Add(columnColor);
            dataGridViewGoods.Columns.Add(columnSize);
            dataGridViewGoods.Columns.Add(columnPrice);
            dataGridViewGoods.Columns.Add(columnAmount);
            dataGridViewGoods.Columns.Add(columnTotalPrice);

            DataGridViewImageCell cell = new DataGridViewImageCell();
            cell.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridViewGoods.Columns["photo"].CellTemplate = cell;
        }

        //2. 数据加载
        public void MyFrmInit()
        {
            labelCurMarketFbInfo.Text = curMarketFbAccount;

            if (!bAdd)//Edit
            {
                InitOrderInfo();
                InitCustomerInfoById();
                InitGridViewGoods();
                txtCustomerId.ReadOnly = true;
            }
            else
            {
                if (orderAddType != "" && orderAddFrom != "")//复制
                {
                    //先临时改成正常Edit
                    bAdd = false; 
                    curOrderId = orderAddFrom;

                    InitOrderInfo();
                    InitCustomerInfoById();
                    InitGridViewGoods();
                    txtCustomerId.ReadOnly = true;

                    //再改成Add状态
                    bAdd = true;
                    curOrderId = "";

                    txtOrderId.Text = "";
                    txtCreateTime.Text = "";
                    txtLastEditTime.Text = "";

                    if (orderAddType == "复制")
                        cbxOrderType.SelectedIndex = cbxOrderType.Items.IndexOf("订单");
                    else if (orderAddType == "新建售后")
                        cbxOrderType.SelectedIndex = cbxOrderType.Items.IndexOf("售后单");
                    else if (orderAddType == "新建分期")
                        cbxOrderType.SelectedIndex = cbxOrderType.Items.IndexOf("分期付款单");
                    else
                        MessageBox.Show("未知订单新建类型！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOriOrderId.Text = orderAddFrom;


                    labelOrderStatus.Text = "未保存";

                    //还原商品信息
                    for (int i = 0; i < dataGridViewGoods.Rows.Count; i++)
                    {
                        DataGridViewRow row = dataGridViewGoods.Rows[i];
                        row.Cells[1].Value = "0";
                    }

                }
                else //普通Add
                {
                    if (curCustomerFbId != "")
                    {
                        txtCustomerId.Text = curCustomerFbId;
                        InitCustomerInfoById();
                        //txtCustomerId.ReadOnly = true;
                    }
                    btnCheckCustomerExist.Visible = true;
                }
            }
        }

        private void InitOrderInfo()
        {
            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbOrders where orderId='{0}'", curOrderId);
                FbOrderInfo order = (FbOrderInfo)db.GetObject(sb.ToString(), "tb_fbOrders");

                if (order == null)
                {
                    MessageBox.Show("读取订单失败，此订单可能已被删除！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                curCustomerFbId = order.customerFbId;
                txtCustomerId.Text = curCustomerFbId;

                txtOrderId.Text = order.orderId;
                txtCreateTime.Text = order.createTime;
                txtLastEditTime.Text = order.lastEditTime;
                cbxOrderType.SelectedIndex = cbxOrderType.Items.IndexOf(order.orderType);
                txtOriOrderId.Text = order.oriOrderId;

                txtShipFee.Text = order.shippingFee;
                txtTrackingNo.Text = order.shippingNo;
                txtPayAmount.Text = order.totalPrice;

                if (order.shippingType != "EMS")
                {
                    cbxShipType.SelectedIndex = cbxShipType.Items.IndexOf("Other");
                    txtShipType.Visible = true;
                    txtShipType.Text = order.shippingType;
                }
                else
                    cbxShipType.SelectedIndex = cbxShipType.Items.IndexOf(order.shippingType);
                
                if (order.currency != "AUD" && order.currency != "NZD" && order.currency != "USD" && order.currency != "CAD" && order.currency != "EUR" &&
                    order.currency != "GBP" && order.currency != "台币" && order.currency != "人民币")
                {
                    cbxCurrency.SelectedIndex = cbxCurrency.Items.IndexOf("Other");
                    txtCurrency.Visible = true;
                    txtCurrency.Text = order.currency;
                }
                else
                    cbxCurrency.SelectedIndex = cbxCurrency.Items.IndexOf(order.currency);

                if (order.paymentType != "Paypal" && order.paymentType != "Credit Card" && order.paymentType != "Western Union" && order.paymentType != "货到付款")
                {
                    cbxPayType.SelectedIndex = cbxPayType.Items.IndexOf("Other");
                    txtPayType.Visible = true;
                    txtPayType.Text = order.paymentType;
                }
                else
                    cbxPayType.SelectedIndex = cbxPayType.Items.IndexOf(order.paymentType); 

                txtPayNo.Text = order.paymentNo;

                txtShippingName.Text = order.shippingName;
                txtShippingPhone.Text = order.shippingPhone;
                txtShippingAddress.Text = order.shippingAddress;

                labelOrderStatus.Text = order.status;
                labelOrderStatus.ForeColor = System.Drawing.Color.Red;
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

        private void InitCustomerInfoById()
        {
            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbCustomers where fbId='{0}'", txtCustomerId.Text.Trim());
                FbCustomerInfo customer = (FbCustomerInfo)db.GetObject(sb.ToString(), "tb_fbCustomers");

                if (customer == null)
                {
                    MessageBox.Show("此客户在系统中不存在，请先创建客户！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //转到新建客户页面
                    this.txtCustomerId.Focus();
                    return;
                }

                txtCustomerName.Text = customer.name;
                txtCountry.Text = customer.country;
                txtCity.Text = customer.city;

                if (bAdd)
                {
                    txtShippingName.Text = customer.shipName;
                    txtShippingPhone.Text = customer.shipPhone;
                    txtShippingAddress.Text = customer.shipAddress;
                    chkbSetDefaultAddress.Checked = false;
                }
                else
                {
                    if (customer.shipName == txtShippingName.Text.Trim() &&
                    customer.shipPhone == txtShippingPhone.Text.Trim() &&
                    customer.shipAddress == txtShippingAddress.Text.Trim())
                    {
                        chkbSetDefaultAddress.Checked = true;
                    }
                    else
                        chkbSetDefaultAddress.Checked = false;
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
        

        public void InitGridViewGoods()
        {
            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbOrderGoods where orderId='{0}'", curOrderId);
                List<fbOrderGoodsInfo> goodsList = (List<fbOrderGoodsInfo>)db.GetList(sb.ToString(), "tb_fbOrderGoods");

                dataGridViewGoods.Rows.Clear();
                foreach (var goods in goodsList)
                {
                    int index = dataGridViewGoods.Rows.Add();

                    dataGridViewGoods.Rows[index].Cells["checkbox"].Value = 0;
                    dataGridViewGoods.Rows[index].Cells["id"].Value = goods.id;
                    dataGridViewGoods.Rows[index].Cells["photo"].Value = BytesToImage(goods.photo);
                    dataGridViewGoods.Rows[index].Cells["name"].Value = goods.name;
                    dataGridViewGoods.Rows[index].Cells["color"].Value = goods.color;
                    dataGridViewGoods.Rows[index].Cells["size"].Value = goods.size;
                    dataGridViewGoods.Rows[index].Cells["price"].Value = goods.price;
                    dataGridViewGoods.Rows[index].Cells["amount"].Value = goods.amount;
                }

                CalcTotalPrice();
                this.labelChangedNotify.Visible = false;
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
        
        //3. 操作
        private void cbxShipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtShipType.Visible  = (cbxShipType.SelectedItem.ToString() == "Other");
        }

        private void cbxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCurrency.Visible = (cbxCurrency.SelectedItem.ToString() == "Other");
        }

        private void cbxPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPayType.Visible = (cbxPayType.SelectedItem.ToString() == "Other");
        }

        private void btnCheckCustomerExist_Click(object sender, EventArgs e)
        {
            if (txtCustomerId.Text.Trim() == "")
            {
                MessageBox.Show("请输入客户Facebook ID！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCustomerId.Focus();
                return;
            }

            InitCustomerInfoById();
        }

        private void btnInsertGoods_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage() == false)
            {
                MessageBox.Show("剪切板没有截图，请先截图！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int index = dataGridViewGoods.Rows.Add();
            dataGridViewGoods.Rows[index].Cells["checkbox"].Value = false;
            dataGridViewGoods.Rows[index].Cells["id"].Value = "0";
            dataGridViewGoods.Rows[index].Cells["photo"].Value = Clipboard.GetImage();
            dataGridViewGoods.Rows[index].Cells["name"].Value = "0";
            dataGridViewGoods.Rows[index].Cells["color"].Value = "0";
            dataGridViewGoods.Rows[index].Cells["size"].Value = "0";
            dataGridViewGoods.Rows[index].Cells["price"].Value = "0";
            dataGridViewGoods.Rows[index].Cells["amount"].Value = "0";
            dataGridViewGoods.Rows[index].Cells["totalPrice"].Value = "0";

            Clipboard.Clear();
        }

        private void btnDelGoods_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("确定删除选中商品？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (choice == DialogResult.No)
                return;

            for (int i = 0; i < dataGridViewGoods.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridViewGoods.Rows[i];
                if (row.Cells[0].Value.ToString() == "True")
                {
                    if (row.Cells[1].Value.ToString() != "")
                    {
                        sb.Clear();
                        sb.AppendFormat("delete from tb_fbOrderGoods where id={0}", row.Cells[1].Value.ToString());

                        try
                        {
                            db.DeleteData(sb.ToString());
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
                    dataGridViewGoods.Rows.Remove(row);
                    i = i - 1;
                    //dataGridViewGoods.Rows.Remove(row);
                }
            }
        }

        private void CalcTotalPrice()
        {
            double total = 0.0, all = 0.0;
            for (int i = 0; i < dataGridViewGoods.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridViewGoods.Rows[i];

                if (IsDigital(row.Cells["price"].Value.ToString().Trim()) && IsDigital(row.Cells["amount"].Value.ToString().Trim()))
                {
                    total = (Convert.ToDouble(row.Cells["price"].Value.ToString().Trim()) * Convert.ToDouble(row.Cells["amount"].Value.ToString().Trim()));
                    row.Cells["totalPrice"].Value = total.ToString("0.000");
                    all += total;
                }
                else
                    row.Cells["totalPrice"].Value = "0";
            }

            labelTotal.Text = all.ToString("0.000");
        }

        private void btnCalcTotal_Click(object sender, EventArgs e)
        {
            CalcTotalPrice();
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

        private void doSave(string operation)
        {
            try
            {
                //1. tb_fbOrders
                if (bAdd)
                {
                    sb.Clear();
                    sb.AppendFormat("insert into tb_fbOrders(customerFbId, marketFbid, orderType, oriOrderId, " +
                        "createTime, lastEditTime, status, shippingAddress, shippingName, shippingPhone, shippingType, shippingFee, shippingNo, " +
                        "currency, totalPrice, paymentType, paymentNo, note) " +
                        "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')",
                        txtCustomerId.Text.Trim(), curMarketFbId, cbxOrderType.SelectedItem.ToString(), txtOriOrderId.Text.Trim(),
                        DateTime.Now.ToString(), DateTime.Now.ToString(), getNewOrderStatus(operation), txtShippingAddress.Text.Trim(), txtShippingName.Text.Trim(), txtShippingPhone.Text.Trim(),
                        (cbxShipType.SelectedItem.ToString() == "Other" ? txtShipType.Text.Trim() : cbxShipType.SelectedItem.ToString()), txtShipFee.Text.Trim(), txtTrackingNo.Text.Trim(),
                        (cbxCurrency.SelectedItem.ToString() == "Other" ? txtCurrency.Text.Trim() : cbxCurrency.SelectedItem.ToString()), txtPayAmount.Text.Trim(),
                        (cbxPayType.SelectedItem.ToString() == "Other" ? txtPayType.Text.Trim() : cbxPayType.SelectedItem.ToString()), txtPayNo.Text.Trim(), txtNote.Text.Trim());
                    db.InsertData(sb.ToString());
                }
                else // Edit
                {
                    sb.Clear();
                    sb.AppendFormat("Update tb_fbOrders set orderType='{0}', oriOrderId='{1}', lastEditTime='{2}', status='{3}', shippingAddress='{4}'," +
                        "shippingName='{5}',shippingPhone='{6}',shippingType='{7}',shippingFee='{8}',shippingNo='{9}',currency='{10}',totalPrice='{11}',paymentType='{12}',paymentNo='{13}'," +
                        "note='{14}' where orderId='{15}'",
                        cbxOrderType.SelectedItem.ToString(), txtOriOrderId.Text.Trim(), DateTime.Now.ToString(), getNewOrderStatus(operation),
                        txtShippingAddress.Text.Trim(), txtShippingName.Text.Trim(), txtShippingPhone.Text.Trim(),
                        (cbxShipType.SelectedItem.ToString() == "Other" ? txtShipType.Text.Trim() : cbxShipType.SelectedItem.ToString()), txtShipFee.Text.Trim(), txtTrackingNo.Text.Trim(),
                        (cbxCurrency.SelectedItem.ToString() == "Other" ? txtCurrency.Text.Trim() : cbxCurrency.SelectedItem.ToString()), txtPayAmount.Text.Trim(),
                        (cbxPayType.SelectedItem.ToString() == "Other" ? txtPayType.Text.Trim() : cbxPayType.SelectedItem.ToString()), txtPayNo.Text.Trim(),
                        txtNote.Text.Trim(), curOrderId);
                    db.UpdateData(sb.ToString());
                }

                //2. tb_fbOrderGoods
                if (bAdd)
                {
                    //获取此marketFbId，customerFbId最新创建的orderId
                    sb.Clear();
                    sb.AppendFormat("select * from tb_fbOrders where marketFbId='{0}' and customerFbId='{1}' and " +
                        "createTime in (select max(createTime) from tb_fbOrders where marketFbId='{2}' and customerFbId='{3}')",
                        curMarketFbId, txtCustomerId.Text.Trim(), curMarketFbId, txtCustomerId.Text.Trim());
                    FbOrderInfo newOrder = (FbOrderInfo)db.GetObject(sb.ToString(), "tb_fbOrders");
                    curOrderId = newOrder.orderId;
                }

                for (int i = 0; i < dataGridViewGoods.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridViewGoods.Rows[i];
                    if (row.Cells[1].Value.ToString() != "0")
                    {
                        sb.Clear();
                        sb.AppendFormat("update tb_fbOrderGoods set name='{0}',color='{1}',size='{2}',price='{3}',amount='{4}' where id={5}",
                            row.Cells["name"].Value.ToString(), row.Cells["color"].Value.ToString(), row.Cells["size"].Value.ToString(), row.Cells["price"].Value.ToString(),
                            row.Cells["amount"].Value.ToString(), row.Cells["id"].Value.ToString());
                        db.UpdateData(sb.ToString());
                    }
                    else
                    {
                        //sb.Clear();
                        //sb.AppendFormat("insert into tb_fbOrderGoods(orderId, photo, name, color, size, price, amount) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                        //    curOrderId, ImageToBytes((Image)(row.Cells["photo"].Value)), row.Cells["name"].Value.ToString(), row.Cells["color"].Value.ToString(), row.Cells["size"].Value.ToString(),
                        //    row.Cells["price"].Value.ToString(), row.Cells["amount"].Value.ToString());
                        //db.InsertData(sb.ToString());

                        string connString = ConfigurationManager.ConnectionStrings["FbTrade_ConnectionString"].ConnectionString;
                        SqlConnection conn = new SqlConnection(connString);

                        string sql = "insert into tb_fbOrderGoods(orderId, photo, name, color, size, price, amount) values(@orderId,@photo,@name,@color,@size,@price,@amount)";
                        SqlCommand com = new SqlCommand(sql, conn);
                        com.Parameters.Add("@orderId", SqlDbType.VarChar, 30).Value = curOrderId;
                        
                        com.Parameters.Add("@name", SqlDbType.Text).Value = row.Cells["name"].Value.ToString();
                        com.Parameters.Add("@color", SqlDbType.VarChar, 30).Value = row.Cells["color"].Value.ToString();
                        com.Parameters.Add("@size", SqlDbType.VarChar, 30).Value = row.Cells["size"].Value.ToString();
                        com.Parameters.Add("@price", SqlDbType.VarChar, 30).Value = row.Cells["price"].Value.ToString();
                        com.Parameters.Add("@amount", SqlDbType.VarChar, 30).Value = row.Cells["amount"].Value.ToString();
                        com.Parameters.Add("@photo", SqlDbType.Image).Value = ImageToBytes((Image)(row.Cells["photo"].Value));

                        try
                        {
                            conn.Open();
                            com.ExecuteNonQuery(); ;
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message, "数据库异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "程序异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }

                //默认地址
                if (chkbSetDefaultAddress.Checked)
                {
                    sb.Clear();
                    sb.AppendFormat("update tb_fbCustomers set shipName='{0}',shipPhone='{1}',shipAddress='{2}' where fbId='{3}'", 
                        txtShippingName.Text.Trim(), txtShippingPhone.Text.Trim(), txtShippingAddress.Text.Trim(), txtCustomerId.Text.Trim());
                    db.UpdateData(sb.ToString());
                }

                //保存成功
                MessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.bAdd = false;
                this.MyComponentInit();
                this.MyFrmInit();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            doSave("Save");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            doSave("Submit");
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
                    sb.Clear();
                    sb.AppendFormat("Update tb_fbOrders set status='{0}' where orderId='{1}'", bAdmin ? "管理员废弃单" : "自己删除单", curOrderId);
                    db.UpdateData(sb.ToString());
                }

                //3. reShow
                MessageBox.Show("操作成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.MyFrmInit();
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

        private void dataGridViewGoods_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!bAdd)
                this.labelChangedNotify.Visible = true;
        }

        public bool CloseComfirm()
        {
            if (labelChangedNotify.Visible == true)
            {
                DialogResult choice = MessageBox.Show("商品信息修改未保存，确定要关闭吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (choice == DialogResult.No)
                    return false;
            }

            return true;
        }

        private void btnOrderCopy_Click(object sender, EventArgs e)
        {
            if (this.txtOrderId.Text.Trim() == "")
            {
                MessageBox.Show("此订单编号为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtOrderId.Focus();
                return;
            }

            try
            {
                sb.Clear();
                sb.AppendFormat("select count(*) from tb_fbOrders where orderId='{0}'", txtOrderId.Text.Trim());
                if (db.CheckExist(sb.ToString()) == false)
                {
                    MessageBox.Show("订单在系统中不存在，请先创建！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FrmOrderAdd frm = new FrmOrderAdd();
                this.pFrmMain.AddPage(frm, "复制订单");

                frm.bAdmin = this.bAdmin;
                frm.bAdd = true;
                frm.orderAddType = "复制";
                frm.orderAddFrom = txtOrderId.Text.Trim();
                frm.curMarketFbId = this.curMarketFbId;
                frm.curMarketFbAccount = curMarketFbAccount;
                frm.pFrmMain = this.pFrmMain;

                frm.MyFrmInit();
                frm.Show();
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

        private void btnCustomerEdit_Click(object sender, EventArgs e)
        {
            if (this.txtCustomerId.Text.Trim() == "")
            {
                MessageBox.Show("客户编号为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCustomerId.Focus();
                return;
            }

            try
            {
                sb.Clear();
                sb.AppendFormat("select count(*) from tb_fbCustomerShips where customerFbId='{0}' and marketFbId='{1}'", 
                    txtCustomerId.Text.Trim(), curMarketFbId);
                if (db.CheckExist(sb.ToString()) == false)
                {
                    MessageBox.Show("客户不存在，将跳转至创建客户界面！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FrmCustomerAdd frm = new FrmCustomerAdd();
                    this.pFrmMain.AddPage(frm, "新增客户");

                    frm.bAdd = true;
                    frm.curMarketFbId = this.curMarketFbId;
                    frm.curMarketFbAccount = curMarketFbAccount;
                    frm.pFrmMain = this.pFrmMain;
                    frm.bAdmin = this.bAdmin;

                    frm.MyFrmInit();
                    frm.Show();
                }
                else
                {
                    FrmCustomerAdd frm = new FrmCustomerAdd();
                    this.pFrmMain.AddPage(frm, "编辑客户");

                    frm.bAdd = false;
                    frm.curCustomerFbId = txtCustomerId.Text.Trim();
                    frm.curMarketFbId = this.curMarketFbId;
                    frm.curMarketFbAccount = curMarketFbAccount;
                    frm.pFrmMain = this.pFrmMain;
                    frm.bAdmin = this.bAdmin;

                    frm.MyFrmInit();
                    frm.Show();
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
}
