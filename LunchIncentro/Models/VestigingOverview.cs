using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LunchIncentro.Models
{
    [NotMapped]
    public class VestigingOverview
    {
        public List<BalanceModel> Balances;
        public List<Mutation> Mutations;
    }
}