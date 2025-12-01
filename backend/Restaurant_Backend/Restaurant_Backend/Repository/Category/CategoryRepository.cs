using Microsoft.AspNetCore.Http.HttpResults;
using Restaurant_Backend.Entities;

namespace Restaurant_Backend.Repository.Category;

public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    public Entities.Category? GetById(int id)
    {
        var category =  context.Categories.FirstOrDefault(c => c.Id == id);
        return category;
    }

    public List<Entities.Category> GetAll()
    {
        return context.Categories.ToList();
    }

    public void Add(Entities.Category category)
    {
        context.Categories.Add(category);
        context.SaveChanges();
    }

    public void Update(Entities.Category category)
    {
        var exists = context.Categories.FirstOrDefault(c => c.Id == category.Id);
        if (exists != null)
        {
            exists.Name = category.Name;
            context.SaveChanges();
        }
    }

    public void Delete(Entities.Category category)
    {
        var exists = context.Categories.FirstOrDefault(c => c.Id == category.Id);
        if (exists != null)
        {
            context.Categories.Remove(exists);
            context.SaveChanges();
        }
    }

}