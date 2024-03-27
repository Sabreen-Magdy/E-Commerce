using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Day3.Models
{
    [Table("Student")]
    public class Student
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
