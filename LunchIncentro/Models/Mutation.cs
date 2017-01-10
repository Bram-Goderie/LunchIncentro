using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LunchIncentro.Models
{
    public class Mutation
    {
        [Key]
        public string Id { get; set; }

        public string User { get; set; }
        public string Vestiging { get; set; }
        public float Amount { get; set; }
        public float Balance { get; set; }
        public DateTime DateTime { get; set; }
        public PayPossibilities PayPossibility{ get; set; }
        public PayChoice PayChoice { get; set; }
    }

    public class MutationsDbContext : DbContext
    {
        public DbSet<Mutation> Mutations { get; set; }
    }
}