using Company.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
