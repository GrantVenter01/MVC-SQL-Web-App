using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using MVCStudent.Models;

namespace MVCStudent.Controllers
{
    public class ParentsController : Controller
    {
        private MVCStudentEntities _Database = new MVCStudentEntities();

        public ActionResult Parent(Parent parent)
        {
            return View("ParentDetails", parent);
        }

        //Save Button
        [HttpPost]
        public ActionResult Save(Parent model)
        {
            if (ModelState.IsValid)
            {
                _Database.Entry(model).State = EntityState.Modified;
                _Database.SaveChanges();

                return RedirectToAction("StudentDetails", "Students");
            }

            return View("Parent", model);
        }
    }
}