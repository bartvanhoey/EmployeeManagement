using System.Collections.Generic;
using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public SqlEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public Employee GetEmployee(int id) => _context.Employees.Find(id);


        public IEnumerable<Employee> GetAllEmployees() => _context.Employees;

        public Employee Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee Update(Employee employeeChanges)
        {
          var employee = _context.Employees.Attach(employeeChanges);
          employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
         _context.SaveChanges();
         return employeeChanges;
        }

        public Employee Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return null;
            _context.Remove(employee);
            _context.SaveChanges();
            return employee;
        }
    }
}