namespace TeisterMask.Data
{
   
    using Microsoft.EntityFrameworkCore;
    using TeisterMask.Models;

    public class TeisterMaskDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        private const string ConnectionString = @"Server=M11X\SQLEXPRESS;Database=TeisterMaskDb;Integrated Security=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
