using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LunchIncentro.Models
{
    public class BalanceModel
    {
        [Key]
        public string Id { get; set; }

        public string User { get; set; }
        public string Vestiging { get; set; }
        public float Balance { get; set; }
        public DateTime Date { get; set; }

        public BalanceModel() { }

        public BalanceModel(float balance, string vestigingId, string user)
        {
            Id = "-1";
            Vestiging = vestigingId;
            Balance = balance;
            User = user;
            Date = DateTime.Now;
        }
    }

    public class BalanceDbContext : DbContext
    {
        public DbSet<BalanceModel> Balances { get; set; }
    }
}