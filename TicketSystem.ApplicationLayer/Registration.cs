using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DataLayer;

namespace TicketSystem.ApplicationLayer
{
    public class Registration
    {
        public static int Execute(string username,string email,string password)
        {
            CustomerTableDataGW gw = new CustomerTableDataGW();
            var userDataName = gw.GetByUsername(username);
            if (userDataName.Rows.Count != 0) return -1;
            var userDataEmail = gw.GetByEmail(email);
            if (userDataEmail.Rows.Count != 0) return -2;
            if(password.Length>8 && password.Any(char.IsDigit) ) return -3;
            int id = gw.GetAll().Rows.Count;
            gw.AddCustomer(id,username,email,password);
            return id;
        }
    }
}
