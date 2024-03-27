﻿using System;
using System.Collections.Generic;

namespace WinFormsApp1.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
