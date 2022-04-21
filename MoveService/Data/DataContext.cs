using Microsoft.EntityFrameworkCore;
using MoveService.Models;

namespace MoveService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Move> Moves { get; set; }
    }
}
