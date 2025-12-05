namespace Restaurant_Backend.Repository.Table;

public class TableRepository(ApplicationDbContext context) : ITableRepository
{
    public Entities.Table? GetById(int id)
    {
        var  table = context.Tables.FirstOrDefault(t => t.Id == id);
        return table;
    }

    public List<Entities.Table> GetAll()
    {
        var  tables = context.Tables.ToList();
        return tables;
    }

    public void Add(Entities.Table table)
    {
        context.Tables.Add(table);
        context.SaveChanges();
    }

    public void Update(Entities.Table table)
    {
        var exists =  context.Tables.FirstOrDefault(t => t.Id == table.Id);
        if (exists != null)
        {
            exists.SeatNumber= table.SeatNumber;
            exists.TableNumber = table.TableNumber;
            context.SaveChanges();
        }
    }

    public void Delete(Entities.Table table)
    {
        var exists =  context.Tables.FirstOrDefault(t => t.Id == table.Id);
        if (exists != null)
        {
            context.Tables.Remove(exists);
            context.SaveChanges();
        }
    }
}