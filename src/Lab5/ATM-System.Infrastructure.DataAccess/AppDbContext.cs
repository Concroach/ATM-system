using Lab5.Application.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Infrastructure.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    public DbSet<AccountEntity> Accounts { get; set; }

    public DbSet<OperationEntity> Operations { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .HasKey(u => u.UserId);

        modelBuilder.Entity<AccountEntity>()
            .HasKey(a => a.AccountId);

        modelBuilder.Entity<AccountEntity>()
            .HasOne(a => a.User)
            .WithMany()
            .HasForeignKey(a => a.UserId);

        modelBuilder.Entity<OperationEntity>()
            .HasKey(o => o.OperationId);

        modelBuilder.Entity<OperationEntity>()
            .HasOne<AccountEntity>()
            .WithMany()
            .HasForeignKey(o => o.AccountId);
    }
}