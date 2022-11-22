namespace Spg.WebApplication.AdministrationApp.Domain;

public class Department : EntityBase
{
    protected Department()
    { }

    public Department(string name, string description, Teacher teacher)
    {
        Name = name;
        Description = description;
        DepartmentDirector = teacher;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    
    public int TeacherId { get; set; }
    public Teacher DepartmentDirector { get; set; }
    
    protected List<Room> _rooms = new();
    public IReadOnlyList<Room> Rooms => _rooms;

    public bool AddRoom(Room room)
    {
        if(room == null) return false;
        _rooms.Add(room);
        return true;
    }

    public bool RemoveRoom(Room room)
    {
        if(room == null) return false;
        var existingRoom = Rooms.FirstOrDefault(r => r.Id == room.Id);
        if(existingRoom == null) return false;
        _rooms.Remove(existingRoom);
        return true;
    }
}