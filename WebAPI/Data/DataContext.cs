using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ButtonKeyboard> ButtonsKeyboard { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ButtonKeyboard>().ToTable(nameof(ButtonKeyboard));
            modelBuilder.Entity<ButtonKeyboard>().HasKey(i => i.Id);
            modelBuilder.Entity<ButtonKeyboard>().Property(n => n.Name).IsRequired().HasMaxLength(20);
            base.OnModelCreating(modelBuilder);
        }
    }
}
