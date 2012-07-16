using System.Data.Entity;

namespace KendoUIWebApi.Models
{
    public class KendoUIWebApiContext : DbContext
    {
        public KendoUIWebApiContext() : base("name=KendoUIWebApiContext")
        {
        }

        public DbSet<Foo> Foos { get; set; }
    }
}
