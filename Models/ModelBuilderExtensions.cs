using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

public static class ModelBuilderExtensions
{
    public static void SeedEmployees(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
                        new Employee
                        {
                            Id = 1,
                            Name = "Mary",
                            Department = Dept.IT,
                            Email = "mary@pragimtech.com"

                        }, new Employee
                        {
                            Id = 2,
                            Name = "John",
                            Department = Dept.HR,
                            Email = "john@pragimtech.com"

                        });
    }
}