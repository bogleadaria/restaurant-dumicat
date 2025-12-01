namespace Restaurant_Backend.Repository.Ingredient;

public interface IIngredientRepository
{
    Entities.Ingredient? GetById(int id);
    List<Entities.Ingredient> GetAll();
    void Add(Entities.Ingredient ingredient);
    void Update(Entities.Ingredient ingredient);
    void Delete(Entities.Ingredient ingredient);
    
}