namespace Restaurant_Backend.Repository.Menu;

public class MenuRepository(ApplicationDbContext context):IMenuRepository
{
    public Entities.Menu? GetById(int id)
    {
        var menu = context.Menus.FirstOrDefault(m => m.Id == id);
        return menu;
    }

    public List<Entities.Menu> GetAll()
    {
        var  menus = context.Menus.ToList();
        return menus;
    }

    public void Add(Entities.Menu menu)
    {
        context.Menus.Add(menu);
        context.SaveChanges();
    }

    public void Update(Entities.Menu menu)
    {
        var exists = context.Menus.FirstOrDefault(m => m.Id == menu.Id);
        if (exists != null)
        {
            exists.Name = menu.Name;
            context.SaveChanges();
        }
    }

    public void Delete(Entities.Menu menu)
    {
        var exists = context.Menus.FirstOrDefault(m => m.Id == menu.Id);
        if (exists != null)
        {
            context.Menus.Remove(exists);
            context.SaveChanges();
        }
    }
}