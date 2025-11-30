using Microsoft.EntityFrameworkCore;
using Restaurant_Backend.Entities;
namespace Restaurant_Backend;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories{ get; set; }
}