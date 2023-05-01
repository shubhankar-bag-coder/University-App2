using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    [Table("Student")]
    public class Student
    {  
        public string Name { get; set; }
        public string Home_City { get; set; }
        public string Department_Name { get; set; }
        public string Course_Enrolled { get; set; }
     }
}
