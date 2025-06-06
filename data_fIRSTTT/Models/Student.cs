using System;
using System.Collections.Generic;

namespace data_fIRSTTT.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Email { get; set; }

    public DateOnly? EnrollmentDate { get; set; }
}
