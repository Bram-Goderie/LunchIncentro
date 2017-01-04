using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace LunchIncentro.Models
{
    public class Vestiging
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ManagerUser { get; set; }
        public string Bunq { get; set; }
        public string Image { get; set; }
        public float StandardCost { get; set; }
    }

    public class VestigingDbContext : DbContext
    {
        public DbSet<Vestiging> Vestigingen { get; set; }
    }
}