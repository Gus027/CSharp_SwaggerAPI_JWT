using WebApi.Domain.DTOs;
using WebApi.Domain.model;

namespace WebApi.Infra.Repositoriy
{
    public class EmployeeRepository : IEmployeeRespository
    {
        private readonly ConnectionContext _connectionContext = new ConnectionContext();

        public void Add(Employee employee)
        {
            _connectionContext.Add(employee);
            _connectionContext.SaveChanges();
        }

        public List<EmployeeDTO> Get()
        {
            return _connectionContext.Employees
              .Select(g =>
                    new EmployeeDTO                     /// Atribuindo as informações concisas para o Front-End, somente o que se deseja utilizar.
                    {
                        idEmployeeDTO = g.id,
                        nameEmployeeDTO = g.name,
                        photoEmployeeDTO = g.photo
                    }
                ).ToList();
        }

        public Employee? GetEmployee(int id)
        {
            return _connectionContext.Employees.Find(id);
        }

        public List<EmployeeDTO> GetPage(int pageNumber, int pageQuantity)
        {
            return _connectionContext.Employees.Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select(g =>
                    new EmployeeDTO                     /// Atribuindo as informações concisas para o Front-End, somente o que se deseja utilizar.
                    {
                        idEmployeeDTO = g.id,
                       nameEmployeeDTO = g.name,
                       photoEmployeeDTO = g.photo
                    }
                ) .ToList();
        }
    }
}
