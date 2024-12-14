using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab2.DataAccess;
namespace Lab4.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private DepartmentDbContext _db;
        public DepartmentController()
        {
            _db = new DepartmentDbContext();
        }
        [HttpGet]
        public Department[] GetDepartments()
        {
            var data = _db.Departments.ToArray();
            return data;
        }
        [HttpGet("{id}")]
        public Department GetDepartment(int id)
        {
            var data = _db.Departments.FirstOrDefault(s => s.Id == id);
            return data;
        }
        [HttpPost]
        public void Post([FromBody] Department department)
        {
            _db.Departments.Add(department);
            _db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteDepartment(int id)
        {
            var data = _db.Departments.FirstOrDefault(s => s.Id == id);

            if (data != null)
            {
                _db.Departments.Remove(data);
                _db.SaveChanges();
            }
        }
        [HttpPut("{id}")]
        public void UpdateDepartment([FromBody] Department department, int id)
        {
            var existingDepartment = _db.Departments.FirstOrDefault(s => s.Id == id);

            if (existingDepartment != null)
            {
                existingDepartment.Nosaukums = department.Nosaukums;
                existingDepartment.DarbiniekuSK = department.DarbiniekuSK;
                existingDepartment.Apraksts = department.Apraksts;
            }

            _db.SaveChanges();
        }

    }
}
