using DemoWebApi.Model;
using DemoWebApi.Repository;
using DemoWebApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {
            var filePath = Path.Combine("Storage", employeeView.Photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            employeeView.Photo.CopyTo(fileStream);

            var employee = new Employee(employeeView.Name, employeeView.Age, filePath);

            _employeeRepository.Add(employee);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var listaEmployee = _employeeRepository.GetAll();

            return Ok(listaEmployee);
        }

        [Authorize]
        [HttpPost]
        [Route("/{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.GetById(id);
            byte[]? dataBytes = null;

            if(employee != null && employee.photo != null)
            {
                dataBytes = System.IO.File.ReadAllBytes(employee.photo);
            }
            if(dataBytes != null)
            {
                return File(dataBytes, "image/png");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
