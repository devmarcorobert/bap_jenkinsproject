namespace Spg.WebApplication.AdministrationApp.Domain;

public class Teacher : EntityBase
{
    public enum GenderTypes { NA = 0, FEMALE = 1, MALE = 2 }
    protected Teacher () {}

    public Teacher(Guid guid, string firstname, string lastname, string email, DateTime
            birthday, GenderTypes gender, string phoneNumber, Address address, DateTime enrollmentDate,
        int ssn, Department department)
    {
        Guid = guid;
        FirstName = firstname;
        LastName = lastname;
        EMail = email;
        BirthDate = birthday;
        Gender = gender;
        Phone = phoneNumber;
        Address = address;
        EnrollmentDate = enrollmentDate;
        SocialSecurityNumber = ssn;
        DepartmentNavigation = department;
    }
    
    
    public Guid Guid { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EMail { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderTypes Gender { get; set; }
    public int SocialSecurityNumber { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public Address Address { get; set; }
    public string Phone { get; set; }
    
    public Department? DepartmentNavigation { get; set;}

    protected List<Class> _classes = new();
    public IReadOnlyList<Class> Classes => _classes;

    public bool AddClass(Class newclass)
    {
        if(newclass == null) return false;
        _classes.Add(newclass);
        return true;
    }

    public bool RemoveClass(Class newclass)
    {
        if(newclass == null) return false;
        var existingClass = Classes.FirstOrDefault(c => c.Id == newclass.Id);
        if(existingClass == null) return false;
        _classes.Remove(existingClass);
        return true;
    }
}