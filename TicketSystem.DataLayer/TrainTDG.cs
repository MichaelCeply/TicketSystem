using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DataLayer
{
    public class TrainTDG
    {
        public DataTable GetAll()
        {
            string query = $"select* from train join Train_Timetable on train.train_id = Train_Timetable.train_id join Timetable on Train_Timetable.timetable_id = Timetable.timetable_id";
            var result = new DataTable();
            var connString = DBConnector.GetBuilder();
            using (SqlConnection connection = new SqlConnection(connString.ToString()))
            {
                // Open connection
                connection.Open();

                // prepare command
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // execute command
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // read data from result
                        result.Load(reader);
                    }
                }
            }
            return result;
        }
    }
}
