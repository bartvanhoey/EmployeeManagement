using System.Collections.Generic;
using EmployeeManagement.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Repositories
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        private readonly ILogger<SqlEmployeeRepository> _logger;

        public SqlEmployeeRepository(AppDbContext context, ILogger<SqlEmployeeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Employee GetEmployee(int id) {

      _logger.LogTrace("Trace Log");
            _logger.LogDebug("Debug Log");
            _logger.LogInformation("Information Log");
            _logger.LogWarning("Warning Log");
            _logger.LogError("Error Log");
            _logger.LogCritical("Critical Log");

             return _context.Employees.Find(id);
        }


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