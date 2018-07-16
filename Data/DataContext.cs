using Microsoft.EntityFrameworkCore;
using ObaOba.API.Models;

namespace ObaOba.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users {get;set;}

        private void ConfigureUser(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>(x => {
                x.ToTable("User");
                x.HasKey(c => c.Id).HasName("Id");
                x.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                x.Property(c => c.Name).HasColumnName("Name").HasMaxLength(30).IsRequired();
                x.Property(c => c.LastName).HasColumnName("LastName").HasMaxLength(30).IsRequired();
                x.Property(c => c.Email).HasColumnName("Email").HasMaxLength(100).IsRequired();
                x.Property(c => c.DateCreated).HasColumnName("DateCreated").IsRequired();
                x.Property(c => c.DateUpdated).HasColumnName("DateUpdated");
                x.Property(c => c.PasswordHash).HasColumnName("PasswordHash").IsRequired();
                x.Property(c => c.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();

            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForNpgsqlUseSerialColumns();
            modelBuilder.HasDefaultSchema("ObaOba");

            ConfigureUser(modelBuilder);
        }
    }
}