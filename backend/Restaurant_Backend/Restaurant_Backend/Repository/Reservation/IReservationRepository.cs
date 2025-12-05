namespace Restaurant_Backend.Repository.Reservation;

public interface IReservationRepository
{  
    Entities.Reservation? GetById(int id);
    List<Entities.Reservation> GetAll();
    void Add(Entities.Reservation reservation);
    void Update(Entities.Reservation reservation);
    void Delete(Entities.Reservation reservation);
    
}