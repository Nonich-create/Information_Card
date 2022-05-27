using Information_Card.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Information_Card.Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
