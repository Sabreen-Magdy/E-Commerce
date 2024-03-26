using Microsoft.EntityFrameworkCore;
using System;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly EfContext context;
        public Form1()
        {
            InitializeComponent();
            using (var context = new EfContext())
            {
                var departments = context.Departments.ToList();
                comboBox1.DataSource = departments;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
            }

            // Load students into the DataGridView with department information
            using (var context = new EfContext())
            {
                var students = context.Students.Include(s => s.Department)
                                               .Select(s => new { Name = s.Name, Age = s.Age, Department = s.Department.Name, DepartmentAddress = s.Department.Address })
                                               .ToList();

                dataGridView1.DataSource = students;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {

            string name = textBox2.Text;
            int age = int.Parse(textBox3.Text);
            string address = textBox4.Text;
            int departmentId = (int)comboBox1.SelectedValue; // Assuming the value member is the department ID


            var newStudent = new Student
            {
                Name = name,
                Age = age,
                DepartmentId = departmentId
            };

            using (var context = new EfContext())
            {
                context.Students.Add(newStudent);
                context.SaveChanges();
            }

            using (var context = new EfContext())
            {
                var students = context.Students.Include(s => s.Department).Select(s => new { Name = s.Name, Age = s.Age, Department = s.Department.Name, DepartmentAddress = s.Department.Address })
                                               .ToList();
                dataGridView1.DataSource = students;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the search keywords from textboxes
            string departmentName = textBox1.Text;
            string studentName = textBox2.Text;

            // Query the database for students with the specified department and student names
            using (var context = new EfContext())
            {
                var query = context.Students.Include(s => s.Department)
                                            .Where(s => (string.IsNullOrEmpty(departmentName) || s.Department.Name.Contains(departmentName)) &&
                                                        (string.IsNullOrEmpty(studentName) || s.Name.Contains(studentName)))
                                            .Select(s => new { Name = s.Name, Age = s.Age, Department = s.Department.Name, DepartmentAddress = s.Department.Address })
                                            .ToList();

                // Update the DataGridView with the search results
                dataGridView1.DataSource = query;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                string selectedStudentName = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

                DialogResult result = MessageBox.Show($"Are you sure you want to delete the student {selectedStudentName}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var context = new EfContext())
                    {
                        var selectedStudent = context.Students.SingleOrDefault(s => s.Name == selectedStudentName);

                        if (selectedStudent != null)
                        {
                            context.Students.Remove(selectedStudent);
                            context.SaveChanges();
                        }
                    }


                    using (var context = new EfContext())
                    {
                        var students = context.Students.Include(s => s.Department)
                                                       .Select(s => new { Name = s.Name, Age = s.Age, Department = s.Department.Name, DepartmentAddress = s.Department.Address })
                                                       .ToList();

                        dataGridView1.DataSource = students;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var context = new EfContext())
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Assuming the columns in the DataGridView match the properties in the Student entity
                    string studentName = row.Cells["Name"].Value?.ToString();
                    int newAge;

                    if (int.TryParse(row.Cells["Age"].Value?.ToString(), out newAge))
                    {
                        var student = context.Students.SingleOrDefault(s => s.Name == studentName);

                        if (student != null)
                        {
                            // Update properties
                            student.Age = newAge;

                            // If other properties need updating, add them here

                            // Mark entity as modified
                            context.Entry(student).State = EntityState.Modified;
                        }
                    }
                }

                // Save changes to the database
                context.SaveChanges();
            }

            // Refresh the DataGridView with the updated data
          //  RefreshDataGridView();

        }
    }
}
