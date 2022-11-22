namespace Spg.WebApplication.AdministrationApp.Domain;

public class Address : EntityBase
{
    public Address()
    { }

    public Address(string street, string city, string state, string zipCode, string country)
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = zipCode;
        Country = country;
    }

    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    
    protected List<Student> _students = new();
    public IReadOnlyList<Student> Students => _students;
    
    protected List<Teacher> _teachers = new();
    public IReadOnlyList<Teacher> Teachers => _teachers;
    public bool AddStudent(Student student)
    {
        if(student == null) return false;
        _students.Add(student);
        return true;
    }

    public bool RemoveStudent(Student student)
    {
        if(student == null) return false;
        var existingStudent = Students.FirstOrDefault(s => s.Id == student.Id);
        if(existingStudent == null) return false;
        _students.Remove(existingStudent);
        return true;
    }
    public bool AddTeacher(Teacher teacher)
    {
        if(teacher == null) return false;
        _teachers.Add(teacher);
        return true;
    }

    public bool RemoveTeacher(Teacher teacher)
    {
        if(teacher == null) return false;
        var existingTeacher = Teachers.FirstOrDefault(t => t.Id == t.Id);
        if(existingTeacher == null) return false;
        _teachers.Remove(existingTeacher);
        return true;
    }
}