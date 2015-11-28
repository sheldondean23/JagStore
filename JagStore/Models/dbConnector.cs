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
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["JagStoreContext"].ConnectionString);

        public void AddToCart(Guid InvoiceItemID,Guid Product,int Quantity)
        {

            connection.Open();
            SqlCommand comm = new SqlCommand("addItems", connection);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@InvoiceItemID", SqlDbType.UniqueIdentifier)).Value = InvoiceItemID;
            comm.Parameters.Add(new SqlParameter("@Product", SqlDbType.UniqueIdentifier)).Value = Product;
            comm.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int)).Value = Quantity;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            connection.Close();
            
        }

        private Product[] converter(DataSet DS)
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
    }
}