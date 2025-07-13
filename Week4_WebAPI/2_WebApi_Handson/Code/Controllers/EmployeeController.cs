using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SwaggerPostmanDemo.Controllers
{
    [Route("api/Emp")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John", Role = "Manager" },
            new Employee { Id = 2, Name = "Alice", Role = "Developer" }
        };

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee emp)
        {
            employees.Add(emp);
            return CreatedAtAction(nameof(GetById), new { id = emp.Id }, emp);
        }

        [HttpGet("{id}")]
        [ActionName("GetById")]
        public ActionResult<Employee> GetById(int id)
        {
            var emp = employees.Find(e => e.Id == id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
