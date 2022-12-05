using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.ApplicationLayer
{
    public class TrainDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int EntryFee { get; set; }
        public int PricePerKm { get; set;}
        public List<int> stations { get; set; }
        public List<TimeOnly> departures { get; set; }
    }
}
