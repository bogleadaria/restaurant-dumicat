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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(mi => mi.Id);

            entity.HasOne(mi => mi.Menu)
                  .WithMany(m => m.MenuItems)
                  .HasForeignKey(mi => mi.MenuId);

            entity.HasOne(mi => mi.Product)
                  .WithMany(p => p.MenuItems)
                  .HasForeignKey(mi => mi.ProductId);

            entity.HasOne(mi => mi.Category)
                  .WithMany(c => c.MenuItems)
                  .HasForeignKey(mi => mi.CategoryId);

            entity.HasOne(mi => mi.Ingredient)
                  .WithMany(i => i.MenuItems)
                  .HasForeignKey(mi => mi.IngredientId);
        });
        
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
        });
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(o => o.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.ClientId);
            entity.HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId);
        });
        modelBuilder.Entity<ProductIngredient>(entity =>
        {
            entity.HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);

            entity.HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);
        });
        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasOne(r => r.Client)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.ClientId);
            entity.HasOne(r => r.Table)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TableId);
        });
        modelBuilder.Entity<Gallery>(entity =>
        {
            entity.HasOne(g => g.Product)
                .WithMany(p => p.Galleries)
                .HasForeignKey(g => g.ProductId);
        });
        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasOne(t => t.Product)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.ProductId);
        });
    }

    
}