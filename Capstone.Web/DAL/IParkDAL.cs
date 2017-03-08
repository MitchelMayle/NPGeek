using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public interface IParkDAL
    {
        List<Park> GetAllParks();
        Park GetParkDetail(string parkName);
        List<Forecast> GetFiveDayForecast(string parkCode);
    }
}