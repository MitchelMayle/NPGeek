using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Park
    {
        public List<Forecast> FiveDayForecast { get; set; }

        public string Name { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public string ParkImage { get; set; }
        public int Acreage { get; set; }
        public int Elevation { get; set; }
        public double MilesOfTrail { get; set; }
        public int NumberOfCampSites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string Quote { get; set; }
        public string QuoteSource { get; set; }
        public int EntryFee { get; set; }
        public int NumberAnimalSpecies { get; set; }
    }
}