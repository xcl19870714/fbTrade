using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using FB_Trade_Models;

namespace FB_Trade_DAL
{
    [Serializable]
    public class DBCommon
    {
        private readonly string connString = ConfigurationManager.ConnectionStrings["FbTrade_ConnectionString"].ConnectionString;
        
        public bool CheckExist(string sqlSelStr)
        {
            //select count(*) from tb_users where name='aaa' and pwd = 'bbb'
            bool success = false;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlSelStr, conn);
            try
            {
                conn.Open();
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    success = true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return success;
        }

        public int GetCount(string sqlSelStr)
        {
            //select count(*) from tb_users where name='aaa' and pwd = 'bbb'
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlSelStr, conn);
            try
            {
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Object GetObject(string sqlSelStr, string table)
        {
            //select * from tb_users where name='aaa'
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlSelStr, conn);
            Object obj = null;

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    switch(table)
                    {
                        case "tb_admins":
                            AdminInfo admin = new AdminInfo();
                            admin.Id = Convert.ToInt32(reader["id"]);
                            admin.Name = Convert.ToString(reader["name"]);
                            admin.Pwd = Convert.ToString(reader["pwd"]);
                            obj = admin;
                            break;
                        case "tb_users":
                            UserInfo user = new UserInfo();
                            user.Id = Convert.ToInt32(reader["id"]);
                            user.Name = Convert.ToString(reader["name"]);
                            user.Pwd = Convert.ToString(reader["pwd"]);
                            user.AdminId = Convert.ToInt32(reader["adminId"]);
                            user.Note = Convert.ToString(reader["note"]);
                            user.CreateTime = Convert.ToString(reader["createTime"]);
                            obj = user;
                            break;
                        case "tb_fbMarketAccounts":
                            FbMarketAccountInfo fb = new FbMarketAccountInfo();
                            fb.fbId = Convert.ToString(reader["fbId"]);
                            fb.name = Convert.ToString(reader["name"]);
                            fb.fbAccount = Convert.ToString(reader["fbAccount"]);
                            fb.fbPwd = Convert.ToString(reader["fbPwd"]);
                            fb.fbUrl = Convert.ToString(reader["fbUrl"]);
                            fb.note = Convert.ToString(reader["note"]);
                            fb.userId = Convert.ToInt32(reader["userId"]);
                            fb.createTime = Convert.ToString(reader["createTime"]);
                            obj = fb;
                            break;
                        case "tb_fbCustomers":
                            FbCustomerInfo cu = new FbCustomerInfo();
                            cu.fbId = Convert.ToString(reader["fbId"]);
                            cu.name = Convert.ToString(reader["name"]);
                            cu.fbUrl = Convert.ToString(reader["fbUrl"]);
                            cu.friendsNum = Convert.ToString(reader["friendsNum"]);
                            cu.country = Convert.ToString(reader["country"]);
                            cu.state = Convert.ToString(reader["state"]);
                            cu.city = Convert.ToString(reader["city"]);
                            cu.email = Convert.ToString(reader["email"]);
                            cu.introduction = Convert.ToString(reader["introduction"]);
                            cu.shipName = Convert.ToString(reader["shipName"]);
                            cu.shipPhone = Convert.ToString(reader["shipPhone"]);
                            cu.shipAddress = Convert.ToString(reader["shipAddress"]);
                            obj = cu;
                            break;
                        case "tb_fbCustomerShips":
                            FbCustomerShipInfo cuShip = new FbCustomerShipInfo();
                            cuShip.id = Convert.ToInt32(reader["id"]);
                            cuShip.customerFbId = Convert.ToString(reader["customerFbId"]);
                            cuShip.marketFbId = Convert.ToString(reader["marketFbId"]);
                            cuShip.shipType = Convert.ToString(reader["shipType"]);
                            cuShip.customerType = Convert.ToString(reader["customerType"]);
                            cuShip.interestedGoods = Convert.ToString(reader["interestedGoods"]);
                            cuShip.note = Convert.ToString(reader["note"]);
                            if (Convert.ToString(reader["trace"]) == "")
                                cuShip.trace = 0;
                            else
                                cuShip.trace = Convert.ToInt32(reader["trace"]);
                            cuShip.traceDate = Convert.ToString(reader["traceDate"]);
                            cuShip.lastEditTime = Convert.ToString(reader["lastEditTime"]);
                            obj = cuShip;
                            break;
						case "tb_fbCustomerContacts":
							FbCustomerContactInfo contact = new FbCustomerContactInfo();
							contact.id = Convert.ToInt32(reader["id"]);
							contact.marketFbId = Convert.ToString(reader["marketFbId"]);
							contact.marketFbAccount = Convert.ToString(reader["marketFbAccount"]);
							contact.customerFbId = Convert.ToString(reader["customerFbId"]);
							contact.time = Convert.ToString(reader["time"]);
							contact.content = Convert.ToString(reader["content"]);
	                        obj = contact;
	                        break;
                        case "tb_fbGroups":
                            FbGroupInfo group = new FbGroupInfo();
                            group.fbId = Convert.ToString(reader["fbId"]);
                            group.name = Convert.ToString(reader["name"]);
                            group.fbUrl = Convert.ToString(reader["fbUrl"]);
                            group.membersNum = Convert.ToString(reader["membersNum"]);
                            group.introduction = Convert.ToString(reader["introduction"]);
                            group.gpSource = Convert.ToString(reader["gpSource"]);
                            group.gpType = Convert.ToString(reader["gpType"]);
                            group.needVerify = Convert.ToString(reader["needVerify"]);
                            obj = group;
                            break;
                        case "tb_fbGroupShips":
                            FbGroupShipInfo groupShip = new FbGroupShipInfo();
                            groupShip.id = Convert.ToInt32(reader["id"]);
                            groupShip.groupFbId = Convert.ToString(reader["groupFbId"]);
                            groupShip.marketFbId = Convert.ToString(reader["marketFbId"]);
                            groupShip.status = Convert.ToString(reader["status"]);
                            groupShip.customersNum = Convert.ToString(reader["customersNum"]);
                            groupShip.contactCustomersNum = Convert.ToString(reader["contactCustomersNum"]);
                            groupShip.tradeCustomersNum = Convert.ToString(reader["tradeCustomersNum"]);
                            groupShip.ordersNum = Convert.ToString(reader["ordersNum"]);
                            groupShip.tweetsNum = Convert.ToString(reader["tweetsNum"]);
                            groupShip.tweetFeedback = Convert.ToString(reader["tweetFeedback"]);
                            groupShip.mark = Convert.ToString(reader["mark"]);
                            groupShip.note = Convert.ToString(reader["note"]);
                            groupShip.lastEditTime = Convert.ToString(reader["lastEditTime"]);
                            obj = groupShip;
                            break;
						case "tb_fbGroupLogs":
							FbGroupLogInfo log = new FbGroupLogInfo();
							log.id = Convert.ToInt32(reader["id"]);
							log.groupFbId = Convert.ToString(reader["groupFbId"]);
							log.marketFbId = Convert.ToString(reader["marketFbId"]);
							log.marketFbAccount = Convert.ToString(reader["marketFbAccount"]);
							log.time = Convert.ToString(reader["time"]);
							log.logs = Convert.ToString(reader["logs"]);
	                        obj = log;
	                        break;
                        case "tb_fbOrders":
                            FbOrderInfo order = new FbOrderInfo();
                            order.orderId = Convert.ToString(reader["orderId"]);
                            order.customerFbId = Convert.ToString(reader["customerFbId"]);
                            order.marketFbId = Convert.ToString(reader["marketFbId"]);
                            order.orderType = Convert.ToString(reader["orderType"]);
                            order.oriOrderId = Convert.ToString(reader["oriOrderId"]);
                            order.createTime = Convert.ToString(reader["createTime"]);
                            order.lastEditTime = Convert.ToString(reader["lastEditTime"]);
                            order.status = Convert.ToString(reader["status"]);
                            order.shippingAddress = Convert.ToString(reader["shippingAddress"]);
                            order.shippingName = Convert.ToString(reader["shippingName"]);
                            order.shippingPhone = Convert.ToString(reader["shippingPhone"]);
                            order.shippingType = Convert.ToString(reader["shippingType"]);
                            order.shippingFee = Convert.ToString(reader["shippingFee"]);
                            order.shippingNo = Convert.ToString(reader["shippingNo"]);
                            order.currency = Convert.ToString(reader["currency"]);
                            order.totalPrice = Convert.ToString(reader["totalPrice"]);
                            order.paymentType = Convert.ToString(reader["paymentType"]);
                            order.paymentNo = Convert.ToString(reader["paymentNo"]);
                            order.note = Convert.ToString(reader["note"]);
                            obj = order;
                            break;

                        default:
                            break;
                    }
                    
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return obj;
        }

        public Object GetStringList(string sqlSelStr, string name)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlSelStr, conn);
            List<string> strList = new List<string>();

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string str;
                    str = Convert.ToString(reader[name]);
                    strList.Add(str);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return strList;
        }

        public Object GetList(string sqlSelStr, string table)
        {
            //select * from tb_users where adminName='admin'
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlSelStr, conn);
            Object obj = null;

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                switch(table)
                {
                    case "tb_users":
                        List<UserInfo> userList = new List<UserInfo>();
                        while (reader.Read())
                        {
                            UserInfo user = new UserInfo();
                            user.Id = Convert.ToInt32(reader["id"]);
                            user.Name = Convert.ToString(reader["name"]);
                            user.Pwd = Convert.ToString(reader["pwd"]);
                            user.AdminId = Convert.ToInt32(reader["adminId"]);
                            user.Note = Convert.ToString(reader["note"]);
                            user.CreateTime = Convert.ToString(reader["createTime"]);
                            userList.Add(user);
                        }
                        obj = userList;
                        break;
                    case "tb_fbMarketAccounts":
                        List<FbMarketAccountInfo> marketFbList = new List<FbMarketAccountInfo>();
                        while (reader.Read())
                        {
                            FbMarketAccountInfo fb = new FbMarketAccountInfo();
                            fb.fbId = Convert.ToString(reader["fbId"]);
                            fb.name = Convert.ToString(reader["name"]);
                            fb.fbAccount = Convert.ToString(reader["fbAccount"]);
                            fb.fbPwd = Convert.ToString(reader["fbPwd"]);
                            fb.fbUrl = Convert.ToString(reader["fbUrl"]);
                            fb.note = Convert.ToString(reader["note"]);
                            fb.userId = Convert.ToInt32(reader["userId"]);
                            fb.createTime = Convert.ToString(reader["createTime"]);
                            marketFbList.Add(fb);
                        }
                        obj = marketFbList;
                        break;
                    case "tb_fbCustomerShips":
                        List<FbCustomerShipInfo> customerShipList = new List<FbCustomerShipInfo>();
                        while (reader.Read())
                        {
                            FbCustomerShipInfo cuShip = new FbCustomerShipInfo();
                            cuShip.id = Convert.ToInt32(reader["id"]);
                            cuShip.customerFbId = Convert.ToString(reader["customerFbId"]);
                            cuShip.marketFbId = Convert.ToString(reader["marketFbId"]);
                            cuShip.shipType = Convert.ToString(reader["shipType"]);
                            cuShip.customerType = Convert.ToString(reader["customerType"]);
                            cuShip.interestedGoods = Convert.ToString(reader["interestedGoods"]);
                            cuShip.note = Convert.ToString(reader["note"]);
                            if (Convert.ToString(reader["trace"]) == "")
                                cuShip.trace = 0;
                            else
                                cuShip.trace = Convert.ToInt32(reader["trace"]);
                            cuShip.traceDate = Convert.ToString(reader["traceDate"]);
                            cuShip.lastEditTime = Convert.ToString(reader["lastEditTime"]);
                            customerShipList.Add(cuShip);
                        }
                        obj = customerShipList;
                        break;
                    case "tb_fbCustomerContacts":
                        List<FbCustomerContactInfo> contactsList = new List<FbCustomerContactInfo>();
                        while (reader.Read())
                        {
							FbCustomerContactInfo contact = new FbCustomerContactInfo();
							contact.id = Convert.ToInt32(reader["id"]);
							contact.marketFbId = Convert.ToString(reader["marketFbId"]);
							contact.marketFbAccount = Convert.ToString(reader["marketFbAccount"]);
							contact.customerFbId = Convert.ToString(reader["customerFbId"]);
							contact.time = Convert.ToString(reader["time"]);
							contact.content = Convert.ToString(reader["content"]);
                            contactsList.Add(contact);
                        }
                        obj = contactsList;
                        break;
                    case "tb_fbGroups":
                        List<FbGroupInfo> groupList = new List<FbGroupInfo>();
                        while (reader.Read())
                        {
                            FbGroupInfo group = new FbGroupInfo();
                            group.fbId = Convert.ToString(reader["fbId"]);
                            group.name = Convert.ToString(reader["name"]);
                            group.fbUrl = Convert.ToString(reader["fbUrl"]);
                            group.membersNum = Convert.ToString(reader["membersNum"]);
                            group.introduction = Convert.ToString(reader["introduction"]);
                            group.gpSource = Convert.ToString(reader["gpSource"]);
                            group.gpType = Convert.ToString(reader["gpType"]);
                            group.needVerify = Convert.ToString(reader["needVerify"]);
                            groupList.Add(group);
                        }
                        obj = groupList;
                        break;
                    case "tb_fbGroupShips":
                        List<FbGroupShipInfo> groupShipList = new List<FbGroupShipInfo>();
                        while (reader.Read())
                        {
                            FbGroupShipInfo groupShip = new FbGroupShipInfo();
                            groupShip.id = Convert.ToInt32(reader["id"]);
                            groupShip.groupFbId = Convert.ToString(reader["groupFbId"]);
                            groupShip.marketFbId = Convert.ToString(reader["marketFbId"]);
                            groupShip.status = Convert.ToString(reader["status"]);
                            groupShip.customersNum = Convert.ToString(reader["customersNum"]);
                            groupShip.contactCustomersNum = Convert.ToString(reader["contactCustomersNum"]);
                            groupShip.tradeCustomersNum = Convert.ToString(reader["tradeCustomersNum"]);
                            groupShip.ordersNum = Convert.ToString(reader["ordersNum"]);
                            groupShip.tweetsNum = Convert.ToString(reader["tweetsNum"]);
                            groupShip.tweetFeedback = Convert.ToString(reader["tweetFeedback"]);
                            groupShip.mark = Convert.ToString(reader["mark"]);
                            groupShip.note = Convert.ToString(reader["note"]);
                            groupShip.lastEditTime = Convert.ToString(reader["lastEditTime"]);
                            groupShipList.Add(groupShip);
                        }
                        obj = groupShipList;
                        break;
					case "tb_fbGroupLogs":
                        List<FbGroupLogInfo> groupLogList = new List<FbGroupLogInfo>();
                        while (reader.Read())
                        {
							FbGroupLogInfo log = new FbGroupLogInfo();
							log.id = Convert.ToInt32(reader["id"]);
							log.groupFbId = Convert.ToString(reader["groupFbId"]);
							log.marketFbId = Convert.ToString(reader["marketFbId"]);
							log.marketFbAccount = Convert.ToString(reader["marketFbAccount"]);
							log.time = Convert.ToString(reader["time"]);
							log.logs = Convert.ToString(reader["logs"]);
                            groupLogList.Add(log);
                        }
                        obj = groupLogList;
                        break;
                    case "tb_fbOrders":
                        List<FbOrderInfo> orderList = new List<FbOrderInfo>();
                        while (reader.Read())
                        {
                            FbOrderInfo order = new FbOrderInfo();
                            order.orderId = Convert.ToString(reader["orderId"]);
                            order.customerFbId = Convert.ToString(reader["customerFbId"]);
                            order.marketFbId = Convert.ToString(reader["marketFbId"]);
                            order.orderType = Convert.ToString(reader["orderType"]);
                            order.oriOrderId = Convert.ToString(reader["oriOrderId"]);
                            order.createTime = Convert.ToString(reader["createTime"]);
                            order.lastEditTime = Convert.ToString(reader["lastEditTime"]);
                            order.status = Convert.ToString(reader["status"]);
                            order.shippingAddress = Convert.ToString(reader["shippingAddress"]);
                            order.shippingName = Convert.ToString(reader["shippingName"]);
                            order.shippingPhone = Convert.ToString(reader["shippingPhone"]);
                            order.shippingType = Convert.ToString(reader["shippingType"]);
                            order.shippingFee = Convert.ToString(reader["shippingFee"]);
                            order.shippingNo = Convert.ToString(reader["shippingNo"]);
                            order.currency = Convert.ToString(reader["currency"]);
                            order.totalPrice = Convert.ToString(reader["totalPrice"]);
                            order.paymentType = Convert.ToString(reader["paymentType"]);
                            order.paymentNo = Convert.ToString(reader["paymentNo"]);
                            order.note = Convert.ToString(reader["note"]);
                            orderList.Add(order);
                        }
                        obj = orderList;
                        break;
					case "tb_fbOrderGoods":
                        List<fbOrderGoodsInfo> goodsList = new List<fbOrderGoodsInfo>();
                        while (reader.Read())
                        {
                            fbOrderGoodsInfo goods = new fbOrderGoodsInfo();
                            goods.id = Convert.ToInt32(reader["id"]);
                            goods.orderId = Convert.ToString(reader["orderId"]);
                            goods.photo = (Byte[])(reader["photo"]); 
                            goods.name = Convert.ToString(reader["name"]);
                            goods.color = Convert.ToString(reader["color"]);
                            goods.size = Convert.ToString(reader["size"]);
                            goods.price = Convert.ToString(reader["price"]);
                            goods.amount = Convert.ToString(reader["amount"]);
                            goodsList.Add(goods);
                        }
                        obj = goodsList;
                        break;
                    default:
                        break;
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return obj;
        }

        public bool DeleteData(string sqlDelStr)
        {
            //delete from tb_users where name='aaa'
            bool success = false;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlDelStr, conn);
            try
            {
                conn.Open();
                success = (cmd.ExecuteNonQuery() >= 1);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return success;
        }

        public bool UpdateData(string sqlUpdateStr)
        {
            //update tb_users set name='bbb',pwd='ccc' where name='aaa'
            bool success = false;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlUpdateStr, conn);
            try
            {
                conn.Open();
                success = (cmd.ExecuteNonQuery() >= 1);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return success;
        }

        public bool InsertData(string sqlInsertStr)
        {
            //Insert into students values(1,’aaa’);
            //insert into students(sid,sname) values(4,'ddd');
            //Insert into students set sid = 2,sname =‘bbb’;
            bool success = false;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlInsertStr, conn);
            try
            {
                conn.Open();
                success = (cmd.ExecuteNonQuery() >= 1);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return success;
        }
    }
}
