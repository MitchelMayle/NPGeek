using Capstone.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAL parkDAL;
        public HomeController(IParkDAL parkDAL)
        {
            this.parkDAL = parkDAL;
        }
        
        public ActionResult Index()
        {
            return View("Index", parkDAL.GetAllParks());
        }

        public ActionResult ParkDetail(string parkName)
        {
            Park park = parkDAL.GetParkDetail(parkName);

            park.FiveDayForecast = parkDAL.GetFiveDayForecast(park.ParkImage);

            return View("ParkDetail", park);
        }
    }
}