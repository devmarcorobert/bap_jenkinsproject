using Microsoft.EntityFrameworkCore;
using Spg.WebApplication.AdministrationApp.Domain;
using Spg.WebApplication.Infrastructure;
using Xunit;

namespace Spg.WebApplication.Test;

public class UnitTest1
{
    [Fact]
    public void CreateTestDB()
    {
        DbContextOptions options = new DbContextOptionsBuilder()
            .UseSqlite("Data Source=AdminApp_Test.db")
            .Options;

        AppDbContext db = new AppDbContext(options);
        db.Database.EnsureDeleted();
        Assert.True(db.Database.EnsureCreated());
    }

    [Fact]
    public void AddEntitiesTest()
    {
        DbContextOptions options = new DbContextOptionsBuilder()
            .UseSqlite("Data Source=AdminApp_Test.db")
            .Options;

        AppDbContext db = new AppDbContext(options);
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        Guid x = new Guid("3b05dbe1-7088-4fc6-bae4-e89f542e2a6a");
        Guid y = new Guid("5fb7097c-335c-4d07-b4fd-00004e2d28ca");
        Address a = new Address("a", "b", "c", "as", "a");
        DateTime b = new DateTime(1997, 1, 30);
        DateTime c = new DateTime(2001, 7, 12);
        DateTime e = new DateTime(2010, 7, 12);
        Department d = new Department("a", "b", null);

        Room room = new Room("a", "b", d);
        Class classroom = new Class("a", "b", d, room);
        Student s = new Student(Student.GenderTypes.NA, "b", "c", "a", y, c, 123, e, a, classroom);
        Teacher t = new Teacher(x, "x", "b", "c", b, Teacher.GenderTypes.MALE, "0124", a, c, 123, d);

        d.DepartmentDirector = t;

        db.Departments.Add(d);
        db.Rooms.Add(room);
        db.Classes.Add(classroom);
        db.Students.Add(s);
        db.Teachers.Add(t);
        db.SaveChanges();
        Assert.Equal(1, db.Departments.Count());
        Assert.Equal(1, db.Rooms.Count());
        Assert.Equal(1, db.Classes.Count());
        Assert.Equal(1, db.Students.Count());
        Assert.Equal(1, db.Teachers.Count());
    }

    [Fact]
    public void TestAddMethods()
    {
        DbContextOptions options = new DbContextOptionsBuilder()
            .UseSqlite("Data Source=AdminApp_Test.db")
            .Options;

        AppDbContext db = new AppDbContext(options);
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        Guid x = new Guid("3b05dbe1-7088-4fc6-bae4-e89f542e2a6a");
        Guid y = new Guid("5fb7097c-335c-4d07-b4fd-00004e2d28ca");
        Address a = new Address("a", "b", "c", "as", "a");
        DateTime b = new DateTime(1997, 1, 30);
        DateTime c = new DateTime(2001, 7, 12);
        DateTime e = new DateTime(2010, 7, 12);
        Department d = new Department("a", "b", null);

        Room room = new Room("a", "b", d);
        Class classroom = new Class("a", "b", d, room);
        Class classroom2 = new Class("1134", "c", d, room);
        Student s = new Student(Student.GenderTypes.NA, "b", "c", "a", y, c, 123, e, a, classroom);
        Teacher t = new Teacher(x, "x", "b", "c", b, Teacher.GenderTypes.MALE, "0124", a, c, 123, d);

        d.DepartmentDirector = t;

        t.AddClass(classroom);
        t.AddClass(classroom2);

        Assert.Equal(2, t.Classes.Count);
        
        t.RemoveClass(classroom);
        Assert.Equal(1, t.Classes.Count);

        classroom.AddStudent(s);
        Assert.Equal(1, classroom.Students.Count);
        classroom.RemoveStudent(s);
        Assert.Equal(0, classroom.Students.Count);

        d.AddRoom(room);
        Assert.Equal(1, d.Rooms.Count);
        d.RemoveRoom(room);
        Assert.Equal(0, d.Rooms.Count);

        a.AddStudent(s);
        Assert.Equal(1, a.Students.Count);
        a.RemoveStudent(s);
        Assert.Equal(0, a.Students.Count);

        a.AddTeacher(t);
        Assert.Equal(1, a.Teachers.Count);
        a.RemoveTeacher(t);
        Assert.Equal(0, a.Teachers.Count);
        
    }
}