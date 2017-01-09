using System.ComponentModel.DataAnnotations.Schema;

namespace LunchIncentro.Models
{
    [NotMapped]
    public class VestigingOverzicht
    {
        public Vestiging Vestiging { get; set; }
        public BalanceModel Balance { get; set; }
        public PayChoice PayChoice { get; set; }
        public PayPossibilities Possibility { get; set; }
        public PayResult PayResult { get; set; }
        public float PayAmount { get; set; }

        public VestigingOverzicht(Vestiging vestiging, BalanceModel balance)
        {
            Vestiging = vestiging;
            Balance = balance;
        }
    }
}