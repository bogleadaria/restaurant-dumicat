namespace Restaurant_Backend.Repository.Product_Ingredient;

public interface IProductIngredientRepository
{
    Entities.ProductIngredient? GetById(int id);
    List<Entities.ProductIngredient> GetAll();
    void Add(Entities.ProductIngredient productIngredient);
    void Update(Entities.ProductIngredient productIngredient);
    void Delete(Entities.ProductIngredient productIngredient);
    
}