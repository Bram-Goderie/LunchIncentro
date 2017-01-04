using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Helpers;
using System.Web.Mvc;
using LunchIncentro.Models;
using Microsoft.AspNet.Identity;

namespace LunchIncentro.Controllers
{
    public class VestigingOverzichtController : Controller
    {
        public static PayChoice ChosenPayChoice = PayChoice.Nothing;
        private static string vestigingIdSaver = "";
        // GET: VestigingOverzicht
        public ActionResult Index(string vestigingID)
        {
            if (vestigingID != null) vestigingIdSaver = vestigingID;
            else vestigingID = vestigingIdSaver;
            var vestigingen = DependencyResolver.Current.GetService<VestigingsController>()
                .GetVestigingenWithBalance(User.Identity.GetUserName());
            var vestigingOverzicht = vestigingen.FirstOrDefault(v => v.Vestiging.Id.Equals(vestigingID));
            ViewBag.payChoice = new SelectList(Enum.GetNames(typeof(PayChoice)));

            return View(vestigingOverzicht);
        }
    }
}
