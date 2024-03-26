using System;
using System.Collections.Generic;

namespace WinFormsApp1.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
