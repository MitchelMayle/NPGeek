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
            return View("ParkDetail", parkDAL.GetParkDetail(parkName));
        }
    }
}