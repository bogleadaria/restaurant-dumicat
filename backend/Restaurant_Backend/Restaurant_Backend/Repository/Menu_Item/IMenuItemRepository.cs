namespace Restaurant_Backend.Repository.Menu_Item;

public interface IMenuItemRepository
{
    Entities.MenuItem? GetById(int id);
    List<Entities.MenuItem> GetAll();
    void Add(Entities.MenuItem menuItem);
    void Update(Entities.MenuItem menuItem);
    void Delete(Entities.MenuItem menuItem);
    
}