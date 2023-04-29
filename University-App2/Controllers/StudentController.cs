using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer; 
// using University_App2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace University_App2.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Students()
        {
            StudentClassLayer studentClassLayer = new StudentClassLayer();
            List<Student> student= studentClassLayer.Students.ToList();

            return View(student);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, string Home_City, string Department_Name, string Course_Enrolled)
        {
            return RedirectToAction("Index");
        }

    }
}