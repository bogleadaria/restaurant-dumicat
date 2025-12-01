namespace Restaurant_Backend.Repository.Ticket;

public interface ITicketRepository
{
    Entities.Ticket? GetById(int id);
    List<Entities.Ticket> GetAll();
    void Add(Entities.Ticket ticket);
    void Update(Entities.Ticket ticket);
    void Delete(Entities.Ticket ticket);
}