namespace Restaurant_Backend.Repository.Product;

public interface IProductRepository
{
    Entities.Product? GetById(int id);
    List<Entities.Product> GetAll();
    void Add(Entities.Product product);
    void Update(Entities.Product product);
    void Delete(Entities.Product product);
    
}