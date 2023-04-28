using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace University_App2.Models
{
    [Table("Student")]
    public class Student
    {

        public int StudentID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,25}$",
         ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }

        [Required]
        public string Home_City { get; set; }

        [Required]
        public string Department_Name { get; set; }

        [Required]
        public string Course_Enrolled { get; set; }
    }
}