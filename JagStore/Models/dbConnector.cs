using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JagStore.Models
{
    public class dbConnector
    {
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["JagStoreDBContext"].ConnectionString);

        public Product[] Distinct()
        {


            DataSet ds = new DataSet();

            connection.Open();
            SqlCommand comm = new SqlCommand("distinctItems", connection);
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(ds);
            da.Dispose();
            connection.Close();

            return converter(ds);
        }

        private Product[] converter(DataSet DS)
        {
            ProductDiscription[] p = null;
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                p[0] = new ProductDiscription();
                p[0].ProductID = DS.Tables[0].Rows[i].Field<Guid>("ProductID");
            }

            return null;
        }
    }
}