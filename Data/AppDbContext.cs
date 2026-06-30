using agrinex_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace agrinex_backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { 
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //User Table
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasKey(user => user.Id)
                .HasName("pk_users");

            entity.Property(user => user.RoleId)
                .HasColumnName("role_id")
                .IsRequired();

            entity.HasOne(user => user.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(user => user.RoleId)
                .HasConstraintName("fk_users_role")
                .OnDelete(DeleteBehavior.Restrict);
                
            entity.Property(user => user.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(user => user.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(user => user.Email)
                .HasColumnName("email")
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(user => user.PasswordHash)
                .HasColumnName("password_hash")
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(user => user.ContactNumber)
                .HasColumnName("contact_number")
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(user => user.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

            entity.Property(user => user.UpdatedAt)
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

            entity.HasIndex(user => user.Email)
                .IsUnique()
                .HasDatabaseName("uq_users_email");
        });

        //Role Table
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("roles");

            entity.HasKey(role => role.Id)
                .HasName("pk_roles");

            entity.Property(role => role.Id)
                .HasColumnName("id");

            entity.Property(role => role.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();

            entity.HasIndex(role => role.Name)
                .IsUnique()
                .HasDatabaseName("uq_roles_name");
        });
    }
}