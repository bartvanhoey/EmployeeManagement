#region License
// EmployeeRepository.cs - Created -- 
// All code Copyright (c) -2019 and property of EurAm plc
// Reproduction of this material is strictly forbidden unless prior written permission is obtained from EurAm plc
#endregion

using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>
        {
            new Employee {Id = 1, Name = "Mary", Department = "HR", Email = "mary@pragimtech.com"},
            new Employee {Id = 2, Name = "John", Department = "IT", Email = "john@pragimtech.com"},
            new Employee {Id = 3, Name = "Mark", Department = "ACCOUNTING", Email = "mark@pragimtech.com"},
        };
        
        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }
    }
}