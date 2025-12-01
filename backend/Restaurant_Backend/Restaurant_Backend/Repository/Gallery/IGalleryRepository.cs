namespace Restaurant_Backend.Repository.Gallery;

public interface IGalleryRepository
{
    Entities.Gallery? GetById(int id);
    List<Entities.Gallery> GetAll();
    void Add(Entities.Gallery gallery);
    void Update(Entities.Gallery gallery);
    void Delete(Entities.Gallery gallery);
}