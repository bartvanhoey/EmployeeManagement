using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>()
        {
            new Employee {Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@pragimtech.com"},
            new Employee {Id = 2, Name = "John", Department = Dept.IT, Email = "john@pragimtech.com"},
            new Employee {Id = 3, Name = "Mark", Department = Dept.IT, Email = "mark@pragimtech.com"}
        };

        public Employee GetEmployee(int id) => _employees.FirstOrDefault(x => x.Id == id);

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);
            return employee;
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = _employees.FirstOrDefault(x => x.Id == employeeChanges.Id);
            if (employee == null) return null;
            employee.Name = employeeChanges.Name;
            employee.Email = employeeChanges.Email;
            employee.Department = employeeChanges.Department;

            return employee;

        }

        public Employee Delete(int id)
        {
            var employee = _employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
                _employees.Remove(employee);

            return employee;
        }
    }
}