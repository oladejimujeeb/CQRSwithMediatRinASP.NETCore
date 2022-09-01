using CQRS.WithMediatR._ASPNETCore.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRS.WithMediatR._ASPNETCore.Context
{
    public class ApplicationContext: DbContext,IApplicationContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext>options):base(options)
        {

        }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
