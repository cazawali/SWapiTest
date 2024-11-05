using Microsoft.EntityFrameworkCore;

namespace SWapiTest.Server.Data
{
    public class SearchStarDbContext : DbContext
    {
        public SearchStarDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SearchResultFilm> SearchResultFilms { get; set; }
        public DbSet<SearchResultVehicle> SearchResultVehicles { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("\"Data Source=MOONRAIDER;Initial Catalog=SearchStar;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False\"");
        }*/
    }
}
