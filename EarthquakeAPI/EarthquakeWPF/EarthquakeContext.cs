namespace EarthquakeWPF
{
    using System.Data.Entity;

    public class EarthquakeContext : DbContext
    {
        public EarthquakeContext()
            : base("name=EarthquakeContext")
        {
        }
        public DbSet<Client> Clients { get; set; }
    }
}