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
            if(money<0) return -1;
            CustomerTableDataGW gw = new CustomerTableDataGW();
            var userData = gw.GetByUsername(customerName);
            if (userData.Rows.Count == 0) return -2;
            var userRow = userData.Rows[0];
            var user = new CustomerDTO()
            {
                Id = Convert.ToInt32(userRow["customer_id"]),
                Credits = Convert.ToInt32(userRow["credits"])
            };
            user.Credits += money;
            gw.AddCredits(user.Id, user.Credits);
            StationTDG tDG = new StationTDG();
            var workerstation = tDG.GetByWorkerId(workerId);
            var stationRow = workerstation.Rows[0];
            var station = new StationDTO()
            {
                Id = Convert.ToInt32(stationRow["station_id"]),
                Money = Convert.ToInt32(stationRow["money"])
            };
            station.Money += money;
            tDG.AddMoney(station.Id, station.Money);
            return 0;
        }
    }
}
