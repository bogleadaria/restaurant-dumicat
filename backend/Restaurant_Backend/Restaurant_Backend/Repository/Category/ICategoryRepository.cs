using Restaurant_Backend.Entities;

namespace Restaurant_Backend.Repository.Category;

public interface ICategoryRepository
{
    Entities.Category? GetById(int id);
    List<Entities.Category> GetAll();
    void Add(Entities.Category category);
    void Update(Entities.Category category);
    void Delete(Entities.Category category);
}