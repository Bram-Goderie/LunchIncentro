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

        private static VestigingOverzicht vestigingOverzicht;
        // GET: VestigingOverzicht
        public ActionResult Index(string vestigingID)
        {
            if (vestigingID != null) vestigingIdSaver = vestigingID;
            else vestigingID = vestigingIdSaver;
            var vestigingen = DependencyResolver.Current.GetService<VestigingsController>()
                .GetVestigingenWithBalance(User.Identity.GetUserName());
            vestigingOverzicht = vestigingen.FirstOrDefault(v => v.Vestiging.Id.Equals(vestigingID));
            vestigingOverzicht.PayAmount = vestigingOverzicht.Vestiging.StandardCost;
            ViewBag.payChoice = new SelectList(Enum.GetNames(typeof(PayChoice)));
            ViewBag.Possibility = new SelectList(Enum.GetNames(typeof(PayPossibilities)));

            return View(vestigingOverzicht);
        }

        public ActionResult Payment(string Possibility, float PayAmount, PayChoice payChoice)
        {
            vestigingOverzicht.PayChoice = payChoice;
            vestigingOverzicht.Possibility = (PayPossibilities)Enum.Parse(typeof(PayPossibilities), Possibility);
            vestigingOverzicht.PayAmount = PayAmount * (vestigingOverzicht.PayChoice.Equals(PayChoice.SaldoPay) ? -1 : 1);
            return View(vestigingOverzicht);
        }

        public ActionResult Result(string payResult)
        {
            vestigingOverzicht.PayResult = (PayResult)Enum.Parse(typeof(PayResult), payResult);
            if (vestigingOverzicht.PayResult.Equals(PayResult.Succes))
            {
                DependencyResolver.Current.GetService<MutationsController>()
                    .NewMutation(vestigingOverzicht);
            }
            return View(vestigingOverzicht);
        }
    }
}
