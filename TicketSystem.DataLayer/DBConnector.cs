using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DataLayer
{
    public class DBConnector
    {
        public static SqlConnectionStringBuilder GetBuilder()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"dbsys.cs.vsb.cz\STUDENT";  
            builder.UserID = "CEP0037";         
            builder.Password = "McY2L8X4R0A1ubqe";      
            builder.InitialCatalog = "CEP0037";
            builder.TrustServerCertificate= true;
            return builder;
        }
    }
}
