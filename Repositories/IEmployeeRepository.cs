#region License
// IEmployeeRepository.cs - Created -- 
// All code Copyright (c) -2019 and property of EurAm plc
// Reproduction of this material is strictly forbidden unless prior written permission is obtained from EurAm plc
#endregion

using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int i);
    }
}