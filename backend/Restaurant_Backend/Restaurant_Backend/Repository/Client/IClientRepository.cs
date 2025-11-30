using Restaurant_Backend.Entities;

namespace Restaurant_Backend.Repository.Client;

public interface IClientRepository
{
    Entities.Client? GetById(int id);
    List<Entities.Client> GetAll();
    void Add(Entities.Client client);
    void Update(Entities.Client client);
    void Delete(Entities.Client client);
}