using Restaurant_Backend.Entities;

namespace Restaurant_Backend.Repository.Product_Ingredient;

public class ProductIngredientRepository(ApplicationDbContext context):IProductIngredientRepository
{
    public Entities.ProductIngredient? GetById(int id)
    {
        var productIngredient = context.ProductIngredients.FirstOrDefault(x => x.IngredientId == id);
        return productIngredient;
    }
    public List<Entities.ProductIngredient> GetAll(){
        var productIngredients = context.ProductIngredients.ToList();
        return productIngredients;
    }

    public void Add(ProductIngredient productIngredient)
    {
        context.ProductIngredients.Add(productIngredient);
        context.SaveChanges();
    }

    public void Update(ProductIngredient productIngredient)
    {
        var exists = context.ProductIngredients.FirstOrDefault(x => x.Id == productIngredient.Id);
        if (exists != null)
        {
            exists.IngredientId = productIngredient.IngredientId;
            exists.ProductId = productIngredient.ProductId;
            context.SaveChanges();
        }
    }

    public void Delete(ProductIngredient productIngredient)
    {
        var exists = context.ProductIngredients.FirstOrDefault(x => x.Id == productIngredient.Id);
        if (exists != null)
        {
            context.ProductIngredients.Remove(exists);
            context.SaveChanges();
        }
    }
}