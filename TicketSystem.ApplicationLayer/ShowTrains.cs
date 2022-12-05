using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DataLayer;

namespace TicketSystem.ApplicationLayer
{
    public class ShowTrains
    {
        public static List<string>? Execute(int userId, string startStation, string lastStation, string time, out int err)
        {
            err= 0;
            StationTDG stGW = new StationTDG();
            var first = stGW.GetByName(startStation);
            if (first.Rows.Count == 0) { err = -1; return null; }
            var firstRow = first.Rows[0];
            var last = stGW.GetByName(lastStation);
            if (last.Rows.Count == 0) { err = -2; return null; }
            var lastRow = last.Rows[0];
            var start = new StationDTO()
            {
                Id = Convert.ToInt32(firstRow["station_id"]),
                Name = firstRow["name"]?.ToString() ?? ""
            };
            var end = new StationDTO()
            {
                Id = Convert.ToInt32(lastRow["station_id"]),
                Name = lastRow["name"]?.ToString() ?? ""
            };
            TrainTDG TTTG = new TrainTDG();
            var trains = TTTG.GetAll();
            List<TrainDTO> list = new List<TrainDTO>();
            foreach (DataRow row in trains.Rows)
            {
                int id = Convert.ToInt32(row["train_id"]);
                if(list.Count > 0)
                {
                    if(list.Last().Id == id)
                    {
                        list.Last().stations.Add(Convert.ToInt32(row["station_id"]));
                        list.Last().departures.Add(TimeOnly.Parse(row["departure_time"]?.ToString() ?? ""));
                    }
                    else
                    {
                        TrainDTO tmp = new TrainDTO()
                        {
                            Id = id,
                            Type = row["category"]?.ToString() ?? "",
                            EntryFee = Convert.ToInt32(row["entry_fee"]),
                            PricePerKm = Convert.ToInt32(row["price_per_kilometer"]),
                            stations = new List<int> { Convert.ToInt32(row["station_id"]) },
                            departures = new List<TimeOnly> { TimeOnly.Parse(row["departure_time"]?.ToString() ?? "") }
                        };
                        list.Add(tmp);
                    }
                }
                else 
                {
                    TrainDTO tmp = new TrainDTO()
                    {
                        Id = id,
                        Type = row["category"]?.ToString() ?? "",
                        EntryFee = Convert.ToInt32(row["entry_fee"]),
                        PricePerKm = Convert.ToInt32(row["price_per_kilometer"]),
                        stations = new List<int> { Convert.ToInt32(row["station_id"]) },
                        departures = new List<TimeOnly> { TimeOnly.Parse(row["departure_time"]?.ToString() ?? "") }
                    };
                    list.Add(tmp);
                }
                
            }
            TimeOnly timeOnly = TimeOnly.Parse(time);

            List<TrainDTO> filteredTrain = new List<TrainDTO>();
            foreach (var train in list)
            {
                if(train.stations.IndexOf(start.Id)!=-1 && train.stations.IndexOf(end.Id)!=-1)
                {
                    if(train.stations.IndexOf(start.Id)< train.stations.IndexOf(end.Id))
                    {
                        if (train.departures[train.stations.IndexOf(start.Id)]>timeOnly)
                            filteredTrain.Add(train);
                    }
                }
            }
            List<string> strings= new List<string>();
            foreach(var item in filteredTrain)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(item.Id + "-" + item.Type);
                int ind1 = item.stations.IndexOf(start.Id);
                sb.AppendLine(start.Name + ":" + item.departures[ind1]);
                int ind2 = item.stations.IndexOf(end.Id);
                sb.AppendLine(end.Name + ":" + item.departures[ind2]);
                strings.Add(sb.ToString());
            }

            return strings;
        }
    }
}
