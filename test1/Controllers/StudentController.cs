using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test1.Models;

namespace test1.Controllers
{
    public class StudentController : Controller
    {
        static IList<Student> studentList = new List<Student>{
                new Student() { StudentId = 1, StudentName = "John", Age = 18,Sex = true } ,
                new Student() { StudentId = 2, StudentName = "Steve",  Age = 21,Sex=false } ,
                new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 ,Sex=true} ,
                new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 ,Sex=false} ,
                new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 ,Sex= false} ,
                new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 ,Sex=true} ,
                new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 ,Sex=true}
            };
        // GET: Student
        public ActionResult Index()
        {
            TempData["Test"] = "Design by KhangVu!";
            ViewBag.TestTotal = studentList.ToArray().Length;
            ViewData["listStudent"] = studentList;
            return View(studentList.OrderBy(i=>i.StudentId).ToList());
        }
        public ActionResult Edit(int Id)
        {
            String name="";
            if (TempData.ContainsKey("Test")) {
                name = TempData["Test"].ToString();
            }
            var std = studentList.Where(s => s.StudentId == Id).FirstOrDefault();
            return View(std);
        }
        [HttpPost]
        public ActionResult Edit(Student std)
        {
            var student = studentList.Where(s => s.StudentId == std.StudentId).FirstOrDefault();
            var std1 = studentList.Where(s => s.StudentName == std.StudentName && s.StudentId != std.StudentId).FirstOrDefault();
            if (std1 != null)
            {
                ModelState.AddModelError("name", "Student Name Already Exist!");
                return View(std);
            }
            studentList.Remove(student);
            studentList.Add(std);
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public ActionResult Check()
        {
            return View();
        }

    }
}