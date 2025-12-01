using Microsoft.EntityFrameworkCore;
using Restaurant_Backend.Entities;
namespace Restaurant_Backend;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories{ get; set; }
    public DbSet<Client> Clients{ get; set; }
    public DbSet<Gallery> Galleries{ get; set; }
    public DbSet<Ingredient> Ingredients { get; set;}
    public DbSet<Menu> Menus { get; set;}
    public DbSet<MenuItem> MenuItems { get; set;}
    public DbSet<Order> Orders{ get; set; }
    public DbSet<Product> Products{ get; set; }
    public DbSet<ProductIngredient> ProductIngredients{ get; set; }
    public DbSet<Reservation> Reservations{ get; set; }
    public DbSet<Table> Tables{ get; set; }
    public DbSet<Ticket> Tickets{ get; set; }
}