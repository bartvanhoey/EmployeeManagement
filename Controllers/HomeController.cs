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

            var uniqueFileName = ProcessUploadedFile(model);

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


        [HttpGet]
        public ViewResult Edit(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            var employeeEditViewModel = new EmployeeEditViewModel
            {
                Department = employee.Department,
                Id = employee.Id,
                Email = employee.Email,
                ExistingPhotoPath = employee.PhotoPath,
                Name = employee.Name
            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (!ModelState.IsValid) return View();

            var employee = _employeeRepository.GetEmployee(model.Id);

            employee.Name = model.Name;
            employee.Department = model.Department;
            employee.Email = model.Email;

            if (model.Photo != null)
            {
                if (!string.IsNullOrWhiteSpace(model.ExistingPhotoPath))
                {
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                    System.IO.File.Delete(filePath);
                }
                employee.PhotoPath = ProcessUploadedFile(model);
            }
            _employeeRepository.Update(employee);
            return RedirectToAction("Index");
        }

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null && !String.IsNullOrWhiteSpace(model.Photo.FileName))
            {
                var imagesFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                var filePath = Path.Combine(imagesFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}