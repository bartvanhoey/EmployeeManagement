using System.Diagnostics;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View(_employeeRepository.GetAllEmployees());
        }

        public IActionResult Details(int id)
        {
            return View(new HomeDetailsViewModel
            { Employee = _employeeRepository.GetEmployee(id), PageTitle = "Employee Details" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (!ModelState.IsValid) return View();

            string uniqueFileName = null;

            if (model.Photos != null && model.Photos.Count > 0)
            {

                foreach (var photo in model.Photos)
                {
                    if (!String.IsNullOrWhiteSpace(photo.FileName))
                    {
                        var imagesFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        var filePath = Path.Combine(imagesFolder, uniqueFileName);
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }

                    
                }

            }
          var newEmployee = new Employee
            {
                Name = model.Name,
                Department = model.Department,
                Email = model.Email,
                PhotoPath = uniqueFileName
            };

            var employee = _employeeRepository.Add(newEmployee);

            
            return RedirectToAction("Details", new { id = employee.Id });

        }
    }
}