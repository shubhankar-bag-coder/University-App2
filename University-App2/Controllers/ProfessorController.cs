using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace University_App2.Controllers
{
    public class ProfessorController : Controller
    {
        public ActionResult Professor_List()
        {
            ProfessorBusinessLayer professorBusinessLayer = new ProfessorBusinessLayer();
            List<Professors>profeesor = professorBusinessLayer.Professors.ToList();

            return View(profeesor);
        }


        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            if(ModelState.IsValid)
            {
                Professors professors = new Professors();
                UpdateModel(professors);

                ProfessorBusinessLayer professorBusinessLayer = new ProfessorBusinessLayer();
                professorBusinessLayer.AddProfessor(professors);

                return RedirectToAction("Professor_List", "Professor");

            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id, string name)
        {
            ProfessorBusinessLayer professorBusinessLayer = new ProfessorBusinessLayer();
            Professors professor= professorBusinessLayer.Professors.Single(pro => pro.Professor_ID== id);

            return View(professor);
        }
    }
}