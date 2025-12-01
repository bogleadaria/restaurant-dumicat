using Restaurant_Backend.Entities;

namespace Restaurant_Backend.Repository.Menu_Item;

public class MenuItemRepository(ApplicationDbContext context):IMenuItemRepository
{
    public Entities.MenuItem? GetById(int id)
    {
        var  menuItem = context.MenuItems.FirstOrDefault(m => m.Id == id);
        return menuItem;
    }

    public List<Entities.MenuItem> GetAll()
    {
        var  menuItems = context.MenuItems.ToList();
        return menuItems;
    }

    public void Add(MenuItem menuItem)
    {
        context.MenuItems.Add(menuItem);
        context.SaveChanges();
    }

    public void Update(MenuItem menuItem)
    {
        var exists = context.MenuItems.FirstOrDefault(m => m.Id == menuItem.Id);
        if (exists != null)
        {
            exists.IngredientId = menuItem.IngredientId;
            exists.ProductId = menuItem.ProductId;
            exists.MenuId = menuItem.MenuId;
            exists.CategoryId = menuItem.CategoryId;
            context.SaveChanges();
        }
    }

    public void Delete(MenuItem menuItem)
    {
        var exists = context.MenuItems.FirstOrDefault(m => m.Id == menuItem.Id);
        if (exists != null)
        {
            context.MenuItems.Remove(exists);
            context.SaveChanges();
        }
    }
}