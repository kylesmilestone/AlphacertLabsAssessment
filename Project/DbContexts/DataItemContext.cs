using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.DbContexts
{
    public class DataItemContext : DbContext
    {
        public DataItemContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DataItem> DataItems { get; set; }
    }
}
