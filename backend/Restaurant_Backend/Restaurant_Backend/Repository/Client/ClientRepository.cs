using Microsoft.AspNetCore.Http.HttpResults;
using Restaurant_Backend.Entities;

namespace Restaurant_Backend.Repository.Client;

public class ClientRepository(ApplicationDbContext context) : IClientRepository
{
    public Entities.Client? GetById(int id)
    {
        var client = context.Clients.FirstOrDefault(x => x.Id == id);
        return client;
    }

    public List<Entities.Client> GetAll()
    {
        return  context.Clients.ToList();
    }

public void Add(Entities.Client client)
    {
        context.Clients.Add(client);
        context.SaveChanges();
    }

    public void Update(Entities.Client client)
    {
        var exists = context.Clients.FirstOrDefault(x => x.Id == client.Id);
        if (exists != null)
        {
            exists.Name = client.Name;
            exists.Address = client.Address;
            exists.Phone = client.Phone;
            exists.Mail = client.Mail;
        }
        context.SaveChanges();
    }
    public void Delete(Entities.Client client)
    {
        var exists=context.Clients.FirstOrDefault(x => x.Id == client.Id);
        if (exists != null)
        {
            context.Clients.Remove(client);
            context.SaveChanges();
        }
    }
    
    
}