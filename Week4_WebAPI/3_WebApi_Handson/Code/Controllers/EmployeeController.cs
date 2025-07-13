using Microsoft.AspNetCore.Mvc;
using CustomWebApiTask3.Models;
using CustomWebApiTask3.Filters;

namespace CustomWebApiTask3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(CustomAuthFilter))]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new();

        public EmployeeController()
        {
            if (_employees.Count == 0)
                _employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Salary = 60000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "IT" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "SQL" }
                    },
                    DateOfBirth = new DateTime(1990, 1, 1)
                }
            };
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> Get()
        {
            // Uncomment this to test the exception filter
            // throw new Exception("Something went wrong");
            return Ok(_employees);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee emp)
        {
            _employees.Add(emp);
            return CreatedAtAction(nameof(Get), new { id = emp.Id }, emp);
        }
    }
}
