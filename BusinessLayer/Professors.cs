using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BusinessLayer
{
    [Table("Professors")]
    public class Professors
    {

        [Required]
        public int Professor_ID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string Professors_Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string Department_Name { get; set; }

        [Required]
        public string Listof_Courses_taught { get; set; }    
    }
}
