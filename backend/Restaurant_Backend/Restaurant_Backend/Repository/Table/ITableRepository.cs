namespace Restaurant_Backend.Repository.Table;

public interface ITableRepository
{
    Entities.Table? GetById(int id);
    List<Entities.Table> GetAll();
    void Add(Entities.Table table);
    void Update(Entities.Table table);
    void Delete(Entities.Table table);
}