using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using MVCStudent.Models;

namespace MVCStudent.Controllers
{
    public class StudentController :Controller
    {
        private MVCStudentEntities _Database = new MVCStudentEntities();
        IQueryable<Student> students;

        public ActionResult StudentInfo()
        {
            students = _Database.Students.Include(s => s.Course).Include(s => s.Parent);
            return View(students.ToList());
        }

        public ActionResult Parent(string ID)
        {
            var parent = _Database.Parents.Find(ID);
            return RedirectToAction("Parent", "Parents", parent);
        }
    }
}