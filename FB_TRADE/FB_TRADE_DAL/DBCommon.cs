using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using FbTrade.Models;

namespace FbTrade.DAL
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

        public Object GetObect(string sqlSelStr, string table)
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
                            
                            obj = user;
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
                    case "tb_admins":
                        break;
                    case "tb_users":
                        List<UserInfo> userList = new List<UserInfo>();
                        while (reader.Read())
                        {
                            UserInfo user = new UserInfo();
                            user.Id = Convert.ToInt32(reader["id"]);
                            user.Name = Convert.ToString(reader["name"]);
                            user.Pwd = Convert.ToString(reader["pwd"]);
                            user.AdminId = Convert.ToInt32(reader["adminId"]);
                            user.AdminName = Convert.ToString(reader["adminName"]);
                            userList.Add(user);
                            //student.BornDate = Convert.ToDateTime(reader["BornDate"]);
                        }
                        obj = userList;
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
