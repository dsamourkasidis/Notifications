using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNotification.Service
{
    class conndb
    {
        
        public static void Dbquery(int id, string group, string msg, int status)
        {   // 1. Create a connection to the db
            ConnectionStringSettings conSettings = System.Configuration.ConfigurationManager.ConnectionStrings["db"];
            string conng = conSettings.ConnectionString;
            SqlConnection conn = new SqlConnection(
               conng
);
            try
            {
                // 2. Open the connection
                conn.Open();
                // 3. Pass the connection to a command object
                DateTime dtime = DateTime.Now;
                SqlCommand cmd = new SqlCommand("insert into Alerts(UserId,GroupName,Message,Datetime,Status) values (@id,@group,@msg,@dtime,@status)", conn);
                //4.Add parameters: id=0 when alert sentToAll or sentToGroup, group=0 when alert sentToAll or sendPrivate
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@group", group);
                cmd.Parameters.AddWithValue("@msg", msg);
                cmd.Parameters.AddWithValue("@dtime", dtime);
                cmd.Parameters.AddWithValue("@status", status);
                //5.Execute the insert command with nonquery
                cmd.ExecuteNonQuery();

            }
            finally
            {
                // 6. Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}

