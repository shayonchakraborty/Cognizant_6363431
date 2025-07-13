using Microsoft.AspNetCore.Mvc;
using EmployeeUpdateApi.Models;

namespace EmployeeUpdateApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new()
        {
            new Employee
            {
                Id = 1,
                Name = "John",
                Salary = 50000,
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

        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee updatedEmp)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var existing = employees.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return BadRequest("Invalid employee id");

            // Update
            existing.Name = updatedEmp.Name;
            existing.Salary = updatedEmp.Salary;
            existing.Permanent = updatedEmp.Permanent;
            existing.Department = updatedEmp.Department;
            existing.Skills = updatedEmp.Skills;
            existing.DateOfBirth = updatedEmp.DateOfBirth;

            return Ok(existing);
        }
    }
}
