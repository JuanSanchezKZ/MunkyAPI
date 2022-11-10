using Microsoft.EntityFrameworkCore;
using AxelWebApi.Models;

namespace AxelWebApi.Data
{
    public class ApiDbContext: DbContext
    {
       public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options)
        {

        }
        public  DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        
    }
}
