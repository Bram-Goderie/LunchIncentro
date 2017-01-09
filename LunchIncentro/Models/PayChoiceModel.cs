using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace LunchIncentro.Models
{
    public class PayChoiceModel
    {
        public PayChoice PayChoice { get; set; }
        public Vestiging Vestiging { get; set; }
        public BalanceModel Balance { get; set; }
        public PayResult PayResult { get; set; }

        public string PayChoiceText
        {
            get{
                switch (PayChoice)
                {
                    case PayChoice.DirectPay:
                        return "Direct betalen";
                    case PayChoice.Increment:
                        return "Saldo Ophogen";
                    case PayChoice.Nothing:
                        return "Niets doen";
                    case PayChoice.SaldoPay:
                        return "Betalen uit saldo";
                    default:
                        return "";
                }
            }
        }

        public float Adjustment { get; set; }
    }

    public enum PayChoice
    {
        Nothing,
        DirectPay,
        Increment,
        SaldoPay
    }

    public enum PayPossibilities
    {
        Nothing,
        PayPal,
        Ideal,
        Contant
    }

    public enum PayResult
    {
        Succes,
        Failure,
        Pending
    }
}