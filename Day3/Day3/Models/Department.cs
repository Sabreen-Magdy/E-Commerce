using System.ComponentModel.DataAnnotations.Schema;

namespace Day3.Models
{
    [Table("Department")]
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
