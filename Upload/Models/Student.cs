using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LabPractice.Models;

public partial class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Name is required")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage ="Email is required")]
    [EmailAddress(ErrorMessage = "Enter a valid email")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage ="Course is required")]
    public string Course { get; set; } = null!;
}
