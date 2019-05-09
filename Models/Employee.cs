#region License
// Employee.cs - Created -- 
// All code Copyright (c) -2019 and property of EurAm plc
// Reproduction of this material is strictly forbidden unless prior written permission is obtained from EurAm plc
#endregion
namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
    }
}