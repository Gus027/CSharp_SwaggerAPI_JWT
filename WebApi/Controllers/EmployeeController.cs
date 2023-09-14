using Microsoft.AspNetCore.Mvc;
using WebApi.model;
using WebApi.ViewModel;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRespository _employeeRepository;

        public EmployeeController(IEmployeeRespository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        [HttpPost]
        public IActionResult Add([FromForm]EmployeeViewModel employeeView)
        {
            var filePath = Path.Combine("Storage", employeeView.photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeView.photo.CopyTo(fileStream);

            var employee = new Employee(employeeView.name, employeeView.age, filePath);

            _employeeRepository.Add(employee);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetEmployee() {
            var employee = _employeeRepository.Get();

            return Ok(employee);
        }
        

    }
}
