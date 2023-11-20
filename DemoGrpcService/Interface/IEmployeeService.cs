using DemoGrpcService.Entity;

namespace DemoGrpcService.Interface
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(string id);
        Task<Employee> CreateAsync(Employee employee);
        Task UpdateAsync(string id, Employee employee);
        Task DeleteAsync(string id);
    }
}
