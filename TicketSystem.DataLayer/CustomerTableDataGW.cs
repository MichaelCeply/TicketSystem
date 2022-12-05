using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DataLayer
{
    public class CustomerTableDataGW
    {
        
        public DataTable GetAll()
        {
            string query = $"SELECT* FROM CUSTOMER";
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
        public DataTable GetByUsername(string username)
        {
            string query = $"SELECT* FROM CUSTOMER WHERE username = '{username}'";
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
        public DataTable GetByEmail(string email)
        {
            string query = $"SELECT* FROM CUSTOMER WHERE username = '{email}'";
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
        public void AddCustomer(int id,string name, string email,string password)
        {
            string query = $"INSERT INTO [Customer] VALUES({id},'{name}','{email}','{password}',0,null,null)";
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
        public void AddCredits(int id, int credits)
        {
            string query = $"UPDATE CUSTOMER SET credits = {credits} WHERE customer_id = {id}";
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
