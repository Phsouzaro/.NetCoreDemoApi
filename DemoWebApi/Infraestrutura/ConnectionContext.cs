using DemoWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApi.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "Server=localhost;" +
            "Port=5432;"+
            "Database=postgres;" +
            "User Id=postgres;"+
            "Password=root;");
    }
}
