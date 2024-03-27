namespace day2.Models
{
    public class StudentList
    {
        static List<Student> students = new List<Student>()
        {
            new Student { Id = 1, Name = "John Doe", age = "20", Address = "123 Main St" },
            new Student { Id = 2, Name = "Jane Smith", age = "22", Address = "456 Oak Ave" },
            new Student { Id = 3, Name = "Bob Johnson", age = "19", Address = "789 Elm Blvd" }
        };

        public List<Student> GetAll()
        {
            return students;
        }
        public void Add(Student std)
        {
            students.Add(std);
        }

    }
}
