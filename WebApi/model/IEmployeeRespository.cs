namespace WebApi.model
{
    public interface IEmployeeRespository
    {

        void Add(Employee employee);

        List<Employee> Get();  

        Employee? GetEmployee(int id);
    }
}
