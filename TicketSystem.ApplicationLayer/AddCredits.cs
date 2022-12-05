using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DataLayer;

namespace TicketSystem.ApplicationLayer
{
    public class AddCredits
    {
        public static int Execute(int workerId,string customerName, int money)
        {
            CustomerTableDataGW gw = new CustomerTableDataGW();
            var userData = gw.GetByUsername(customerName);
            if (userData.Rows.Count == 0) return -1;
            var userRow = userData.Rows[0];
            var user = new CustomerDTO()
            {
                Id = Convert.ToInt32(userRow["customer_id"]),
                Credits = Convert.ToInt32(userRow["credits"])
            };
            user.Credits += money;
            gw.AddCredits(user.Id, user.Credits);

        }
    }
}
