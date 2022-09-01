using CQRS.WithMediatR._ASPNETCore.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRS.WithMediatR._ASPNETCore.Context
{
    public interface IApplicationContext
    {
        public DbSet<Product> Products { get; set; }
        Task<int> SaveChanges();
        
    }
}
