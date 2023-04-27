using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Reports
{
    public static class ConnectionManager
    {

        public static SqlConnection Open()
        {
            SqlConnection ConnectionManager = new SqlConnection();
            try
            {

                ConnectionManager.ConnectionString = "Data Source=135.22.67.113;Initial Catalog=Skypet;User ID=skypetuser;Password=skypetuser@123";
                ConnectionManager.Open();
            }
            catch (Exception)
            {
                throw;
            }
            return ConnectionManager;
        }

        public static void Close(SqlConnection con)
        {
            try
            {
                con.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
