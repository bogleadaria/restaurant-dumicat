using Microsoft.AspNetCore.Http.HttpResults;
using Restaurant_Backend.Entities;

namespace Restaurant_Backend.Repository.Category;

public class CategoryRepository : ICategoryRepository
{
    readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Entities.Category? GetById(int id)
    {
        var category =  _context.Categories.FirstOrDefault(c => c.Id == id);
        return category;
    }

    public List<Entities.Category> GetAll()
    {
        return _context.Categories.ToList();
    }

    public void Add(Entities.Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void Update(Entities.Category category)
    {
        var exists = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
        if (exists != null)
        {
            exists.Name = category.Name;
            _context.SaveChanges();
        }
    }

    public void Delete(Entities.Category category)
    {
        var exists = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
        if (exists != null)
        {
            _context.Categories.Remove(exists);
            _context.SaveChanges();
        }
    }

}