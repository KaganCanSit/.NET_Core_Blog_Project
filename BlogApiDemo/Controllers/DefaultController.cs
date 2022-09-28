using BlogApiDemo.Controllers.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//API CONTROLLER
namespace BlogApiDemo.Controllers
{
    //API'yi bir web projesi icerisinde cagirabilmek icin olmasi gereken tanim
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var value = c.Employees.ToList();
            return Ok(value);
        }

        //Yeni employee eklenmesi islemi - Add
        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var c = new Context();
            c.Add(employee);
            c.SaveChanges();
            return Ok();
        }

        //Employee bilgisini Get üzerinden ip ile getir. Bulmak icin ise Employee icerisinde ara/find et.
        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        //Employee bilgisini ip ile bularak silme islemi - Delete
        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                c.Employees.Remove(employee);
                c.SaveChanges();
                return Ok();
            }
        }

        //Employee bilgisini Put yardimiyla guncelleme islemi - Delete
        [HttpPut]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var c = new Context();
            var emp = c.Find<Employee>(employee.ID);//Employee Bul
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                emp.Name = employee.Name;
                c.Update(emp);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
