using ASPDemoMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPDemoMvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ServiceRequest> serviceRequests { get; set; }

        public DbSet<UsersModel> users { get; set; }

    }
}
