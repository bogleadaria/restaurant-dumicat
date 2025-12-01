namespace Restaurant_Backend.Repository.Menu;

public interface IMenuRepository
{
    Entities.Menu? GetById(int id);
    List<Entities.Menu> GetAll();
    void Add(Entities.Menu menu);
    void Update(Entities.Menu menu);
    void Delete(Entities.Menu menu);
}