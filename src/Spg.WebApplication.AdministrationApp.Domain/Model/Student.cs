namespace Spg.WebApplication.AdministrationApp.Domain;

public class Student : EntityBase
{
    public enum GenderTypes { NA = 0, FEMALE = 1, MALE = 2 }
    
    protected Student () {}

    public Student(int id, GenderTypes gender, string firstName, string lastName, string email,
        Guid identifier, DateTime birthDate, int ssn, DateTime enrollmentDate, Address address, Class classroom)
    {
        Id = id;
        Gender = gender;
        FirstName = firstName;
        LastName = lastName;
        EMail = email;
        Guid = identifier;
        BirthDate = birthDate;
        SocialSecurityNumber = ssn;
        EnrollmentDate = enrollmentDate;
        Address = address;
        ClassNavigation = classroom;
    
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
    public Class ClassNavigation { get; set; }
}