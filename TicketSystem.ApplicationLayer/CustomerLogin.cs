using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DataLayer;

namespace TicketSystem.ApplicationLayer
{
    public class CustomerLogin
    {
        public static int Execute(string username, string password)
        {
            CustomerTableDataGW gw =  new CustomerTableDataGW();
            var userData = gw.GetByUsername(username);
            if (userData.Rows.Count == 0) return -1;
            var userRow = userData.Rows[0];
            var user = new CustomerDTO()
            {
                Id = Convert.ToInt32(userRow["customer_id"]),
                Password = userRow["password"]?.ToString() ?? ""
            };
            if (user.Password == password) return user.Id;
            else return -2;
        }
    }
}
