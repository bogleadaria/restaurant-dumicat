namespace Restaurant_Backend.Repository.Ticket;

public class TicketRepository(ApplicationDbContext context) : ITicketRepository
{
    public Entities.Ticket? GetById(int id)
    {
        var ticket = context.Tickets.FirstOrDefault(p => p.Id == id);
        return ticket;
    }

    public List<Entities.Ticket> GetAll()
    {
        var  tickets = context.Tickets.ToList();
        return tickets;
    }

    public void Add(Entities.Ticket ticket)
    {
        context.Tickets.Add(ticket);
        context.SaveChanges();
    }

    public void Update(Entities.Ticket ticket)
    {
        var exists =  context.Tickets.FirstOrDefault(p => p.Id == ticket.Id);
        if (exists != null)
        {
            exists.ProductId= ticket.ProductId;
            exists.OrderId= ticket.OrderId;
            exists.TicketNumber= ticket.TicketNumber;
            context.SaveChanges();
        }
    }

    public void Delete(Entities.Ticket ticket)
    {
        var exists = context.Tickets.FirstOrDefault(p => p.Id == ticket.Id);
        if (exists != null)
        {
            context.Tickets.Remove(exists);
            context.SaveChanges();
        }
    }
}