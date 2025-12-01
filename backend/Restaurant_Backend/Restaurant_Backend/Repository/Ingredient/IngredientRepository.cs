using Restaurant_Backend.Entities;
namespace Restaurant_Backend.Repository.Ingredient;

public class IngredientRepository(ApplicationDbContext context) :IIngredientRepository
{
    public Entities.Ingredient? GetById(int id)
    {
        var  ingredient = context.Ingredients.FirstOrDefault(i => i.Id == id);
        return ingredient;
    }
    public List<Entities.Ingredient> GetAll()
    {
        var ingredients = context.Ingredients.ToList();
        return ingredients;
    }

    public void Add(Entities.Ingredient ingredient)
    { 
        context.Ingredients.Add(ingredient);
        context.SaveChanges();
    }

    public void Update(Entities.Ingredient ingredient)
    {
        var exists = context.Ingredients.FirstOrDefault(i => i.Id == ingredient.Id);
        if (exists != null)
        {
            exists.Name = ingredient.Name;
            exists.IsAllergen= ingredient.IsAllergen;
            context.SaveChanges();
        }
    }

    public void Delete(Entities.Ingredient ingredient)
    {
        var exists = context.Ingredients.FirstOrDefault(i => i.Id == ingredient.Id);
        if (exists != null)
        {
            context.Ingredients.Remove(exists);
            context.SaveChanges();
        }
    }
}