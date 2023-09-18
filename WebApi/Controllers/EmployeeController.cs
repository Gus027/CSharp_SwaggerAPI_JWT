using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ViewModel;
using WebApi.Domain.model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRespository _employeeRepository;
        private readonly ILogger<EmployeeController> _ILogger;             /// Caso precise de informações para monitoramento do logger na aplicação.

        public EmployeeController(IEmployeeRespository employeeRepository, ILogger<EmployeeController> ILogger)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _ILogger = ILogger ?? throw new ArgumentNullException(nameof(ILogger));
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
        public IActionResult GetEmployee()
        {
 
            var employee = _employeeRepository.Get();

            _ILogger.LogInformation("Employee GETALL chamada na aplicação.");
            _ILogger.LogInformation("Retornando Result OK().");

            return Ok(employee);

            _ILogger.LogInformation("Aplicação finalizada.");

        }

        [HttpGet]
        [Route("{id}/employee")]
        public IActionResult GetEmployeeId(int id) { 
        
               var employeeId = _employeeRepository.GetEmployee(id);
               return Ok(employeeId);
        }

        [HttpGet]
        [Route("{page}/{qnt}/employee")]
        public IActionResult GetPage(int page, int qnt) {

            
            var employeePage = _employeeRepository.GetPage(page, qnt);   // Testando a Paginação da aplicação na requisição da API

            _ILogger.LogInformation("Employee GETPAGE chamada na aplicação.");
            _ILogger.LogInformation("Retornando Result OK().");

            return Ok(employeePage);

            _ILogger.LogInformation("Aplicação finalizada.");
           
        }
    }
}
