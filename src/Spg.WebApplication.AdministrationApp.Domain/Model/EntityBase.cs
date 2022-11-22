namespace Spg.WebApplication.AdministrationApp.Domain;

public class EntityBase
{
    public int Id { get; private set;}
    public DateTime? LastChangeDate { get; set; }
}