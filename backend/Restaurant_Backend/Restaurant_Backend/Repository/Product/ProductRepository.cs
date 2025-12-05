namespace Restaurant_Backend.Repository.Product;

public class ProductRepository(ApplicationDbContext context):IProductRepository
{
    public Entities.Product? GetById(int id)
    {
        var product = context.Products.FirstOrDefault(p => p.Id == id);
        return product;
    }

    public List<Entities.Product> GetAll()
    {
        var products = context.Products.ToList();
        return products;
    }

    public void Add(Entities.Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();
    }

    public void Update(Entities.Product product)
    {
        var exists = context.Products.FirstOrDefault(p => p.Id == product.Id);
        if (exists != null)
        {
            exists.Name = product.Name;
            exists.Price = product.Price;
            exists.CategoryId = product.CategoryId;
            exists.Stock = product.Stock;
            context.SaveChanges();
        }
    }

    public void Delete(Entities.Product product)
    {
        var exists = context.Products.FirstOrDefault(p => p.Id == product.Id);
        if (exists != null)
        {
            context.Products.Remove(exists);
            context.SaveChanges();
        }
    }
}