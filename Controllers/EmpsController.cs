using LabPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpsController : Controller
    {
        LabDbContext db = new LabDbContext();

        [HttpGet]
        public IActionResult Get()
        {
            var emp = db.Emps.ToList();
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult Post(Emp emp)
        {
            db.Emps.Add(emp);
            db.SaveChanges();

            return Ok(new
            {
                message = "Record addedd!!",
                emp = emp
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Emp emp)
        {
            Emp emps = db.Emps.Find(id);

            if(emps == null)
            {
                return NotFound(new
                {
                    message = "Record not found!!"
                });
            }

            emps.Name = emp.Name;
            emps.Address = emp.Address;

            return Ok(new
            {
                message = "Record updated",
                emp = emp
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Emp emp = db.Emps.Find(id);

            if(emp == null)
            {
                return NotFound(new
                {
                    message = "Record not found."
                });
            }

            db.Emps.Remove(emp);
            db.SaveChanges();

            return Ok(new
            {
                messsage = "Record deleted.."
            });
        }
    }
}
