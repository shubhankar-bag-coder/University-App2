using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class Students
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Home_City { get; set; }
        public string Department_Name { get; set; }
        public string Course_Enrolled { get; set; }


    }
}
