using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>()
        {
            new Employee {Id = 1, Name = "Mary", Department = "HR", Email = "mary@pragimtech.com"},
            new Employee {Id = 2, Name = "John", Department = "Accounting", Email = "john@pragimtech.com"},
            new Employee {Id = 3, Name = "Mark", Department =  "IT", Email = "mark@pragimtech.com"}
        };
        
        public Employee GetEmployee(int id) => _employees.FirstOrDefault(x => x.Id == id);
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }
    }
}