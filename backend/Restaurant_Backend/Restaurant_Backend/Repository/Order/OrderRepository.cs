namespace Restaurant_Backend.Repository.Order;

public class OrderRepository(ApplicationDbContext context) :IOrderRepository
{
    public Entities.Order? GetById(int id)
    {
        var  order = context.Orders.FirstOrDefault(o => o.Id == id);
        return order;
    }

    public List<Entities.Order> GetAll()
    {
        var orders = context.Orders.ToList();
        return orders;
    }

    public void Add(Entities.Order order)
    {
        context.Orders.Add(order);
        context.SaveChanges();
    }

    public void Update(Entities.Order order)
    {
        var exists = context.Orders.FirstOrDefault(o => o.Id == order.Id);
        if (exists != null)
        {
            exists.ProductId = order.ProductId;
            exists.ClientId = order.ClientId;
            exists.TotalPrice = order.TotalPrice;
            exists.Status = order.Status;
            context.SaveChanges();
        }
    }

    public void Delete(Entities.Order order)
    {
        var exists = context.Orders.FirstOrDefault(o => o.Id == order.Id);
        if (exists != null)
        {
            context.Orders.Remove(exists);
            context.SaveChanges();
        }
    }
}