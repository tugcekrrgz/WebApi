using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //Employee Data
        public static List<Employee> employees = new List<Employee>()
        {
            new Employee
            {
                EmployeeId = 1, Firstname="Nancy", Lastname="Davoilo"
            },
            new Employee
            {
                EmployeeId = 2, Firstname="Andrew", Lastname="Fuller"
            },
            new Employee
            {
                EmployeeId = 3, Firstname="Jenny", Lastname="Dothswpth"
            }
        };

        
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault(x=> x.EmployeeId==id);

            if(employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{id}")]
        public IActionResult PostEmployee(Employee employee)
        {
            employees.Add(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, Employee updated)
        {
            var employee = employees.FirstOrDefault(x => x.EmployeeId==id);
            if(employee != null)
            {
                employee.Firstname = updated.Firstname;
                employee.Lastname = updated.Lastname;
                return Ok($"{id} numaralı çalışan güncellendi!");
            }
            else
            {
                return NotFound("Böyle bir çalışan bulunamadı!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(x => x.EmployeeId == id);
            if (employee != null)
            {
                employees.Remove(employee);
                return Ok($"{id} numaralı çalışan listeden kaldırıldı!");
            }
            else
            {
                return NotFound("Böyle bir çalışan bulunamadı!");
            }
        }
    }
}
