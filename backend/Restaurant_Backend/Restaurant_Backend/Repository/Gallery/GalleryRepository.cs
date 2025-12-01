namespace Restaurant_Backend.Repository.Gallery;

public class GalleryRepository(ApplicationDbContext context) :IGalleryRepository
{
    public Entities.Gallery? GetById(int id)
    {
        var gallery= context.Galleries.FirstOrDefault(g => g.Id == id);
        return gallery;
    }

    public List<Entities.Gallery> GetAll()
    {
        var galleries = context.Galleries.ToList();
        return galleries;
    }

    public void Add(Entities.Gallery gallery)
    {
        context.Galleries.Add(gallery);
        context.SaveChanges();
    }

    public void Update(Entities.Gallery gallery)
    {
        var exists = context.Galleries.FirstOrDefault(g => g.Id == gallery.Id);
        if (exists != null)
        {
            exists.FileName=gallery.FileName;
            exists.ContentType=gallery.ContentType;
            exists.Data=gallery.Data;
            exists.ProductId=gallery.ProductId;
            context.SaveChanges();
        }
    }

    public void Delete(Entities.Gallery gallery)
    {
        var exists = context.Galleries.FirstOrDefault(g => g.Id == gallery.Id);
        if (exists != null)
        {
            context.Galleries.Remove(exists);
            context.SaveChanges();
        }
    }
}