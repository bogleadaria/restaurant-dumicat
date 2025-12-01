namespace Restaurant_Backend.Repository.Reservation;

public class ReservationRepository(ApplicationDbContext context) :IReservationRepository
{
    public Entities.Reservation? GetById(int id)
    {
        var  reservation = context.Reservations.FirstOrDefault(p => p.Id == id);
        return reservation;
    }

    public List<Entities.Reservation> GetAll()
    {
        var  reservations = context.Reservations.ToList();
        return reservations;
    }

    public void Add(Entities.Reservation reservation)
    {
        context.Reservations.Add(reservation);
        context.SaveChanges();
    }

    public void Update(Entities.Reservation reservation)
    {
        var exists = context.Reservations.FirstOrDefault(p => p.Id == reservation.Id);
        if (exists != null)
        {
            exists.ClientId= reservation.ClientId;
            exists.Status= reservation.Status;
            exists.Date= reservation.Date;
            exists.PeopleCount= reservation.PeopleCount;
            exists.TableId= reservation.TableId;
            exists.Time = reservation.Time;
            context.SaveChanges();
        }
    }

    public void Delete(Entities.Reservation reservation)
    {
        var exists = context.Reservations.FirstOrDefault(p => p.Id == reservation.Id);
        if (exists != null)
        {
            context.Reservations.Remove(exists);
            context.SaveChanges();
        }
    }
}