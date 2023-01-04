using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Observer_Design_Pattern.DAL
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-FJT4L6QM;initial catalog=DbObserver1;integrated security=true");
        }
        public DbSet<Discount> Discounts { get; set; }
    }
}
   
