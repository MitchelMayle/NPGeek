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
        private const string SQL_GetFiveDayForecast = "SELECT * FROM weather WHERE parkCode = @parkCode;";

        private const string SQL_SaveSurvey = "INSERT INTO survey_result values(@parkCode,@emailAddress,@state,@activityLevel);";
        private const string SQL_GetAllSurveys = "SELECT park.parkname,count(survey_result.parkcode) as count FROM survey_result INNER JOIN park on park.parkcode=survey_result.parkcode GROUP BY park.parkname;";

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

        public List<Forecast> GetFiveDayForecast(string parkCode)
        {
            List<Forecast> forecast = new List<Forecast>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetFiveDayForecast, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Forecast f = new Forecast()
                        {
                            ForecastDay = Convert.ToInt32(reader["fiveDayForecastValue"]),
                            HighTemp = Convert.ToInt32(reader["high"]),
                            LowTemp = Convert.ToInt32(reader["low"]),
                            Condition = Convert.ToString(reader["forecast"])
                        };

                        forecast.Add(f);
                    }
                
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return forecast;
        }

        public bool SaveSurvey(Survey newsurvey)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_SaveSurvey, conn);
                    cmd.Parameters.AddWithValue("@parkCode", newsurvey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", newsurvey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", newsurvey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", newsurvey.ActivityLevel);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }

            }
            catch(SqlException )
            {
                throw;
            }
        }

        public Dictionary<string,int> GetAllSurveys()
        {
            Dictionary<string,int> surveyResult = new Dictionary<string, int>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllSurveys, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        surveyResult.Add(Convert.ToString(reader["parkname"]), Convert.ToInt32(reader["count"]));
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return surveyResult;
        }
    }
}