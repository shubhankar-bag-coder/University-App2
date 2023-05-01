using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Sql;

namespace BusinessLayer
{
    public class ProfessorBusinessLayer
    {
        public string Professors_Name {get;set;}
        public string Department_Name { get; set; }
        public string Listof_Courses_taught { get; set; }
    }
}