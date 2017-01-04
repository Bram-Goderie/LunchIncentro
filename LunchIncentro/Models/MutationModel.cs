using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LunchIncentro.Models
{
    public class MutationModel
    {
        [Key]
        public string Id { get; set; }

        public string User { get; set; }
        public string Vestiging { get; set; }
        public float Mutation { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class MutationDbContext : DbContext
    {
        public DbSet<MutationModel> Mutations { get; set; }
    }
}