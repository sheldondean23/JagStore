using JagStore.Models.Connector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Jagstore.Models.Connector
{
    public class Receipt : dbConnector
    {
        public void Create(string UserID, string Address, string City, string State, string ZipCode, decimal Total, string Address2 = "", string ShipTo = "Default")
        {
            DateTime InvoiceDate = DateTime.Now;
            DateTime ShippingDate = InvoiceDate.AddDays(3);

            connection.Open();
            SqlCommand comm = new SqlCommand("addInvoice", connection);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@UserID", SqlDbType.NVarChar)).Value = UserID;
            comm.Parameters.Add(new SqlParameter("@InvoiceDate", SqlDbType.DateTime)).Value = InvoiceDate;
            comm.Parameters.Add(new SqlParameter("@ShippingDate", SqlDbType.DateTime)).Value = ShippingDate;
            comm.Parameters.Add(new SqlParameter("@ShipToName", SqlDbType.NVarChar)).Value = ShipTo;
            comm.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar)).Value = Address;
            comm.Parameters.Add(new SqlParameter("@Address2", SqlDbType.NVarChar)).Value = Address2;
            comm.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar)).Value = City;
            comm.Parameters.Add(new SqlParameter("@State", SqlDbType.NVarChar)).Value = State;
            comm.Parameters.Add(new SqlParameter("@ZipCode", SqlDbType.NVarChar)).Value = ZipCode;
            comm.Parameters.Add(new SqlParameter("@Total", SqlDbType.Money)).Value = Total;
            rowsAffected = comm.ExecuteNonQuery();
            connection.Close();    
        }
    }
}