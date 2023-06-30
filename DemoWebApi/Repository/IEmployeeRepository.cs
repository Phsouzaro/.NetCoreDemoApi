using DemoWebApi.Model;

namespace DemoWebApi.Repository
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        Employee? GetById(int id);
        List<Employee> GetAll();
    }
}
