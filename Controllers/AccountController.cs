using System;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{

    public class AccountController : Controller
    {

        public AccountController() { }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // [HttpPost]
        // public IActionResult Register(RegisterViewModel model)
        // {
        //         return View();
        // }


    }
}