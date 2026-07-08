using LabPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabPractice.Controllers
{
    public class StudentsController : Controller
    {
        LabDbContext db = new LabDbContext();
        public IActionResult Index()
        {
            var student = db.Students.ToList();
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if(!ModelState.IsValid)
            {
                return View(student);
            }    
            db.Students.Add(student);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Student studentToEdit = db.Students.Find(id);

            return View(studentToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Student studetUpdated)
        {
            Student student = db.Students.Find(studetUpdated.Id);

            student.Name = studetUpdated.Name;
            student.Email = studetUpdated.Email;
            student.Course = studetUpdated.Course;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Student studentToBeDeleted = db.Students.Find(id);

            if (studentToBeDeleted == null)
            {
                return NotFound();
            }

            db.Students.Remove(studentToBeDeleted);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
