namespace MVC02.Models
{
    public class StudentList
    {
        static  List<Student> students = new List<Student>()
        {
            new Student {ID = 1, Name ="Sama",Age= 21 , Email="Sama@gmail.com"},

            new Student {ID = 2, Name ="Rawan",Age= 20 , Email="Rawan@gmail.com"},

            new Student {ID = 3, Name ="youssif",Age= 17 , Email="youssif@gmail.com"},

        };

        public List<Student> GetStudents { get { return students; }}

        public void Add(Student std)
        {
            students.Add(std);
        }
    }
}
