using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Forecast
    {
        public int HighTemp { get; set; }
        public int LowTemp { get; set; }
        public string Condition { get; set; }
        public int ForecastDay { get; set; }

        public DateTime Today { get; set; }
    }
}