namespace Restaurant_Backend.Repository.Order;

public interface IOrderRepository
{
    Entities.Order? GetById(int id);
    List<Entities.Order> GetAll();
    void Add(Entities.Order order);
    void Update(Entities.Order order);
    void Delete(Entities.Order order);
    
}