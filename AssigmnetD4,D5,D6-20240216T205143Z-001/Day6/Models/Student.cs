using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using AppAssigments.Constants;

namespace AppAssigments.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Name field must be Required..!!")]
        [Remote("IsUsernameExisted" , "Students" , AdditionalFields = "Id" , ErrorMessage = "This Student is already existed..!!")]
        public string Name { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Name field must be Required..!!")]
        public string Address { get; set; }
        [Required]
        [CustomAge(ErrorMessage = "Age must be more than 18 year")]
        public int Age {  get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
