namespace Spg.WebApplication.AdministrationApp.Domain;

public class Room : EntityBase
{
    protected Room () {}

    public Room(string name, string description, Department department)
    {
        Name = name;
        Description = description;
        DepartmentNavigation = department;
    }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public Department DepartmentNavigation { get; set; }
   
}