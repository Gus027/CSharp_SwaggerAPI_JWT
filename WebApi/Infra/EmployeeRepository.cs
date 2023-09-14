using WebApi.model;

namespace WebApi.Infra
{
    public class EmployeeRepository : IEmployeeRespository
    {
        private readonly ConnectionContext _connectionContext = new ConnectionContext();

        public void Add(Employee employee)
        {
            _connectionContext.Add(employee);
            _connectionContext.SaveChanges();
        }

        public List<Employee> Get()
        {
            return _connectionContext.Employees.ToList();
        }

        public Employee? GetEmployee(int id)
        {
            return _connectionContext.Employees.Find(id);
        }
    }
}
