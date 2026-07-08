using LabPractice.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LabPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        LabDbContext db = new LabDbContext();
        // GET: api/<StudentController>
        //[HttpGet]
        //public IEnumerable<Student> Get()
        //{
        //    return db.Students.ToList();
        //}

        [HttpGet]
        public IActionResult Get()
        {
            var students = db.Students;

            return Ok(students);
        }

        // GET api/<StudentController>/5
        //[HttpGet("{id}")]
        //public Student Get(int id)
        //{
        //    return db.Students.Find(id);
        //}

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(db.Students.Find(id));
        }

        // POST api/<StudentController>
        //[HttpPost]
        //public void Post([FromBody] Student student)
        //{
        //    db.Add(student);
        //    db.SaveChanges();
        //}

        [HttpPost]
        public IActionResult Post(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();

            //return Created("", student);
            return Ok(new
            {
                message = "Student record added..",
                student = student
            });
        }



        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            Student studentToUpdate = db.Students.Find(id);

            if (studentToUpdate == null)
            {
                return NotFound();
            }

            studentToUpdate.Name = student.Name;
            studentToUpdate.Email = student.Email;
            studentToUpdate.Course = student.Course;

            db.SaveChanges();

            return Ok(new
            {
                message = "Record Updated Successfully",
                student = student
            });
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Student studentToBeDeleted = db.Students.Find(id);
            db.Students.Remove(studentToBeDeleted);

            if (studentToBeDeleted == null)
            {
                return NotFound();
            }

            db.SaveChanges();

            return Ok(new
            {
                message = "Record deleted successfully.."
            });
        }
    }
}
