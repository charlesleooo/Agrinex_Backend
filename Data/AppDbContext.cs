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
}