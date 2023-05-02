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
        public ActionResult View_Students()
        {
            StudentClassLayer studentClassLayer = new StudentClassLayer();
            List<Student> student =studentClassLayer.Students.ToList();

            return View(student);
        }


        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentClassLayer studentClassLayer = new StudentClassLayer();
            Student student = studentClassLayer.Students.Single(stu=> stu.StudentID == id );

            return View(student);
        }


        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            if(ModelState.IsValid)
            {
                Student student = new Student();
                UpdateModel(student);

                StudentClassLayer studentClassLayer = new StudentClassLayer();
                studentClassLayer.AddStudent(student);

                return RedirectToAction("View_Students", "Student");
            }
            return View();           
        }

    }
}
