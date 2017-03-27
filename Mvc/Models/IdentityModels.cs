using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mvc.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=MyConnection")
        {
        }
        //public virtual DbSet<Adress> Adresses { get; set; }
        //public virtual DbSet<Category> Categories { get; set; }
        //public virtual DbSet<Command> Commands { get; set; }
        //public virtual DbSet<CommandLine> CommandLines { get; set; }
        //public virtual DbSet<CommandStatu> CommandStatus { get; set; }
        //public virtual DbSet<Customer> Customers { get; set; }
        //public virtual DbSet<DeliverableCountry> DeliverableCountries { get; set; }
        //public virtual DbSet<DeliverablePrice> DeliverablePrices { get; set; }
        //public virtual DbSet<Medium> Media { get; set; }
        //public virtual DbSet<MediaType> MediaTypes { get; set; }
        //public virtual DbSet<Price> Prices { get; set; }
        //public virtual DbSet<Product> Products { get; set; }
        //public virtual DbSet<UnitType> UnitTypes { get; set; }
        //public  override DbSet<User> Users { get; set; }
        //public virtual DbSet<VATCategory> VATCategories { get; set; }
        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new   ApplicationDbInitializer());

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}