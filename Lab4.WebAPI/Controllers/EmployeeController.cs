using Microsoft.AspNetCore.Mvc;
using Lab2.DataAccess;
using System.Linq;

namespace Lab4.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private DepartmentDbContext _db;

        public EmployeeController()
        {
            _db = new DepartmentDbContext();
        }

        [HttpGet("department/{departmentId}")]
        public ActionResult<IEnumerable<Employee>> GetEmployeesByDepartment(int departmentId)
        {
            var employees = _db.Employees.Where(e => e.Department.Id == departmentId).ToList();

            if (!employees.Any())
                return NotFound($"No employees found for department ID {departmentId}");

            return Ok(employees);
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = _db.Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            _db.Employees.Remove(employee);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
