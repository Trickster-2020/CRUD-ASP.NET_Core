using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CRUD.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
       public DbSet<Employees> Employees { get; set; }

    }
}
