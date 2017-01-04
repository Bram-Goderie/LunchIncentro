using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LunchIncentro.Models;

namespace LunchIncentro.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.V = (new AccountController()).GetUserVestiging(User.Identity.Name);
            return View();
        }
    }
}