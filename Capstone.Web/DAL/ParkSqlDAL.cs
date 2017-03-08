using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        private const string SQL_GetAllParks = "SELECT parkName, state, parkDescription, parkCode FROM park;";

        private string connectionString;
        public ParkSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Park> GetAllParks()
        {
            List<Park> listOfParks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllParks, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Park p = new Park()
                        {
                            Name = Convert.ToString(reader["parkName"]),
                            State = Convert.ToString(reader["state"]),
                            Description = Convert.ToString(reader["parkDescription"]),
                            ParkImage = Convert.ToString(reader["parkCode"])
                        };

                        listOfParks.Add(p);
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }

            return listOfParks;
        }
    }
}