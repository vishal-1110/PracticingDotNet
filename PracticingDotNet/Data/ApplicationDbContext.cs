using Microsoft.EntityFrameworkCore;
using PracticingDotNet.Model.Entities;

namespace PracticingDotNet.Data
{
    public class ApplicationDbContext: DbContext
    {
        // This class would typically inherit from DbContext and include DbSet properties for your entities.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}
