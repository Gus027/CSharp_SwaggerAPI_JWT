using WebApi.Domain.DTOs;

namespace WebApi.Domain.model
{
    public interface IEmployeeRespository
    {

        void Add(Employee employee);                                /// Post de algum Employee.

        List<EmployeeDTO> Get();                                       /// Get all Employeer's.

        List<EmployeeDTO> GetPage(int pageNumber, int pageQuantity);   /// Get por paginação de informações.

        Employee? GetEmployee(int id);                              /// Get pelo ID do Employee.
    }
}
