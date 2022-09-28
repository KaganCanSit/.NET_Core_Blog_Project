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

        [HttpPost]
        public IActionResult EmployeeAdd()
        {
            return Ok();
        }
    }
}
