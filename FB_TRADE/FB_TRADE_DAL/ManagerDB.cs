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
    public class AdminDB
    {
        #region  常量、变量的定义
        private readonly string connString = ConfigurationManager.ConnectionStrings["FbTrade_ConnectionString"].ConnectionString;
        #endregion

    }
}
