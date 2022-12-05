using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DataLayer;

namespace TicketSystem.ApplicationLayer
{
    public class WorkerLogin
    {
        public static int Execute(string username, string password)
        {
            WorkerTDG gw = new WorkerTDG();
            var userData = gw.GetByName(username);
            if (userData.Rows.Count == 0) return -1;
            var userRow = userData.Rows[0];
            var user = new WorkerDTO()
            {
                Id = Convert.ToInt32(userRow["worker_id"]),
                Password = userRow["password"]?.ToString() ?? ""
            };
            if (user.Password == password) return user.Id;
            else return -2;
        }
    }
}
