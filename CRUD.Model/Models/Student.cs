using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CRUD.Model.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FName { get; set; }
        [DisplayName("Last Name")]
        public string LName { get; set; }
        [DisplayName("Grade Point Average")]
        public float Gpa { get; set; }
    }
}
