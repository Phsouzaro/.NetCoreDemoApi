using DemoWebApi.Model;
using DemoWebApi.Repository;

namespace DemoWebApi.Infraestrutura
{
    public class EmployeeRepositoryImpl : IEmployeeRepository
    {

        private readonly ConnectionContext _contexto = new();

        public void Add(Employee employee)
        {
            _contexto.Employees.Add(employee);
            _contexto.SaveChanges();
        }

        public List<Employee> GetAll()
        {
            return _contexto.Employees.ToList();
        }

        public Employee? GetById(int id)
        {
            return _contexto.Employees.Find(id);
        }
    }
}
