namespace Spg.WebApplication.AdministrationApp.Domain;

public class Class : EntityBase
{
    protected Class(){}

    public Class(string name, string description, Department department
        , Room room)
    {
        Name = name;
        Description = description;
        DepartmentNavigation = department;
        RoomNavigation = room;
    }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public Department DepartmentNavigation { get; set; }
    public Room RoomNavigation { get; set; }
    public int StudentsAmount { get; set; }
    
    protected List<Student> _students = new();
    public IReadOnlyList<Student> Students => _students;

    public bool AddStudent(Student student)
    {
        if(student == null) return false;
        StudentsAmount++;
        _students.Add(student);
        return true;
    }

    public bool RemoveStudent(Student student)
    {
        if(student == null) return false;
        var existingStudent = Students.FirstOrDefault(s => s.Id == student.Id);
        if(existingStudent == null) return false;
        StudentsAmount--;
        _students.Remove(existingStudent);
        return true;
        
    }

    protected List<Teacher> _teachers = new();
    public IReadOnlyList<Teacher> Teachers => _teachers;

    public bool AddTeacher(Teacher teacher)
    {
        if(teacher == null) return false;
        _teachers.Add(teacher);
        return true;
    }

    public bool RemoveTeacher(Teacher teacher)
    {
        if(teacher == null) return false;
        var existingTeacher = Teachers.FirstOrDefault(t => t.Id == teacher.Id);
        if(existingTeacher == null) return false;
        _teachers.Remove(existingTeacher);
        return true;
    }
}