using Microsoft.AspNetCore.Http.HttpResults;
using Restaurant_Backend.Entities;

namespace Restaurant_Backend.Repository.Client;

public class ClientRepository : IClientRepository
{
    readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Entities.Client? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Entities.Client> GetAll()
    {
        throw new NotImplementedException();
    }

public void Add(Entities.Client client)
    {
        throw new NotImplementedException();
    }

    public void Update(Entities.Client client)
    {
        throw new NotImplementedException();
    }
    public void Delete(Entities.Client client)
    {
        throw new NotImplementedException();
    }
    
    
}