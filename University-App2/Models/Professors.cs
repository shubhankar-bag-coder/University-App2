using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace University_App2.Models
{
    [Table("Professors")]
    public class Professors
    {
        [Key]
        public int Professor_ID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string Professors_Name { get; set; }

        public string Department_Name { get; set; }


        public string Listof_Courses_taught { get; set; }
    }
}