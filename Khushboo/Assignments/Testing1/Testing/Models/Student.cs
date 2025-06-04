using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Testing.Models;

public  class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public int Gender { get; set; }

    public string? Department { get; set; }

    public string? Email { get; set; }
     

    //for file uploading and downloading
    public string FileName { get; set; }
    [NotMapped]
    public Document Document { get; set; }
    public  IFormFile StudentImage { get; set; }
}
