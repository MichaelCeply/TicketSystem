using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DataLayer
{
    public class StationTDG
    {
        public DataTable GetAll()
        {
            string query = $"SELECT* FROM STATION";
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
        public DataTable GetByName(string name)
        {
            string query = $"SELECT* FROM STATION WHERE name = '{name}'";
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
        public DataTable GetByWorkerId(int id)
        {
            string query = $"select* from Station join Station_Worker on Station.station_id = Station_Worker.station_id join Worker on Worker.worker_id = Station_Worker.worker_id where Worker.worker_id = {id}";
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
        public void AddMoney(int id, int money)
        {
            string query = $"UPDATE STATION SET money = {money} WHERE station_id = {id}";
            var connString = DBConnector.GetBuilder();
            using (SqlConnection connection = new SqlConnection(connString.ToString()))
            {
                // Open connection
                connection.Open();

                // prepare command
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
