using Heroes.Models;
using Microsoft.EntityFrameworkCore;

namespace Heroes.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Heroe> Heroes { get; set; }
}