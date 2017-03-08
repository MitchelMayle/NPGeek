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
        private const string SQL_GetAllParks = "SELECT * FROM park;";
        private const string SQL_GetParkDetails = "SELECT * FROM park where parkName=@parkName;";

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

                    while (reader.Read())
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

        public Park GetParkDetail(string parkName)
        {
            Park p = new Park();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(SQL_GetParkDetails, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@parkName", parkName);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        p.Name = Convert.ToString(reader["parkName"]);
                        p.State = Convert.ToString(reader["state"]);
                        p.Description = Convert.ToString(reader["parkDescription"]);
                        p.ParkImage = Convert.ToString(reader["parkCode"]);
                        p.Acreage = Convert.ToInt32(reader["Acreage"]);
                        p.Elevation = Convert.ToInt32(reader["elevationinfeet"]);
                        p.MilesOfTrail = Convert.ToDouble(reader["milesoftrail"]);
                        p.NumberOfCampSites = Convert.ToInt32(reader["numberofcampsites"]);
                        p.Climate = Convert.ToString(reader["climate"]);
                        p.YearFound = Convert.ToInt32(reader["yearfounded"]);
                        p.AnnualVisitorCount = Convert.ToInt32(reader["annualvisitorcount"]);
                        p.Quote = Convert.ToString(reader["inspirationalquote"]);
                        p.QuoteSource = Convert.ToString(reader["inspirationalquotesource"]);
                        p.EntryFee = Convert.ToInt32(reader["entryfee"]);
                        p.NumberAnimalSpecies = Convert.ToInt32(reader["numberofanimalspecies"]);


                    }
                }
            }
            catch (SqlException)
            {

                throw;
            }
            return p;

        }
    }
}