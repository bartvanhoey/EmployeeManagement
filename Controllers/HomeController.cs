using System.Diagnostics;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View(_employeeRepository.GetAllEmployees());
        }

        public IActionResult Details(int id)
        {
            return View(new HomeDetailsViewModel
                {Employee = _employeeRepository.GetEmployee(id), PageTitle = "Employee Details"});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(Employee newEmployee)
        {
            var employee = _employeeRepository.Add(newEmployee);
            return RedirectToAction("Details", new {id = employee.Id});
        }
    }
}