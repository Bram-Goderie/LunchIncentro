using System.ComponentModel.DataAnnotations.Schema;

namespace LunchIncentro.Models
{
    [NotMapped]
    public class VestigingOverzicht
    {
        public Vestiging Vestiging { get; set; }
        public BalanceModel Balance { get; set; }
        public  PayChoice PayChoice { get; set; }

        public VestigingOverzicht(Vestiging vestiging, BalanceModel balance)
        {
            Vestiging = vestiging;
            Balance = balance;
        }
    }
}