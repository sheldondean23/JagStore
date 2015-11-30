using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JagStore.Models.Connector
{
    public class Cart : dbConnector
    {
        public void Add(Guid InvoiceItemID, Guid? Product, int Quantity)
        {

            connection.Open();
            SqlCommand comm = new SqlCommand("addItems", connection);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@InvoiceItemID", SqlDbType.UniqueIdentifier)).Value = InvoiceItemID;
            comm.Parameters.Add(new SqlParameter("@Product", SqlDbType.UniqueIdentifier)).Value = Product;
            comm.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int)).Value = Quantity;
            rowsAffected = comm.ExecuteNonQuery();
            connection.Close();

        }

        public void Edit(Guid InvoiceItemID, Guid? Product, int Quantity)
        {

            connection.Open();
            SqlCommand comm = new SqlCommand("updateItems", connection);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@InvoiceItemID", SqlDbType.UniqueIdentifier)).Value = InvoiceItemID;
            comm.Parameters.Add(new SqlParameter("@Product", SqlDbType.UniqueIdentifier)).Value = Product;
            comm.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int)).Value = Quantity;
            rowsAffected = comm.ExecuteNonQuery();
            connection.Close();

        }

        public void Delete(Guid InvoiceItemID)
        {

            connection.Open();
            SqlCommand comm = new SqlCommand("deleteItems", connection);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@InvoiceItemID", SqlDbType.UniqueIdentifier)).Value = InvoiceItemID;
            rowsAffected = comm.ExecuteNonQuery();
            connection.Close();

        }
    }
}