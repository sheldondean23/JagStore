using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JagStore.Models.Connector
{
    public class dbConnector
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["JagStoreContext"].ConnectionString);
        public int rowsAffected;
    }
}