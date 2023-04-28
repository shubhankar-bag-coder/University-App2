using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_App2.Models;

namespace University_App2.Controllers
{
    public class ProfessorController : Controller
    {
        public ActionResult Professor_List()
        {
            StudentContext professorContext = new StudentContext();
            List<Professors>professor= professorContext.Professors.ToList();
            return View(professor);
        }
       
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}