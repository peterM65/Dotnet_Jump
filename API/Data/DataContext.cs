using API.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Character> Characters => Set<Character>();
    }
}
