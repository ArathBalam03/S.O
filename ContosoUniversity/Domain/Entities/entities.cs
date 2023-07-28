using ContosoUniversity.Domain.Entities.Base;
public class Course : BaseEntity
{
    public int Credits { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class Department : BaseEntity
{
    public double Budget { get; set; }
    public int InstructorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
}

public class Person : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime HireDate { get; set; }
    public DateTime? EnrollmentDate { get; set; }
    public string Address { get; set; } = string.Empty;
    public bool? HasParkingLot { get; set; }
}
