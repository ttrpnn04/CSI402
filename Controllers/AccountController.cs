using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSI402.Models;
using CSI402.ViewModels;

namespace CSI402.Controllers;

public class AccountController : Controller
{
    // Static list to store users (in real app, use database)
    private static List<LabUserViewModel> users = new List<LabUserViewModel>
    {
        new LabUserViewModel {UserId = "001", Name = "Teeraphan", LastName = "Thienpromthong", Age = 20, Address = "123 Main Street"},
        new LabUserViewModel {UserId = "002", Name = "John", LastName = "Doe", Age = 25, Address = "456 Elm Street"},
        new LabUserViewModel {UserId = "003", Name = "Jane", LastName = "Smith", Age = 30, Address = "789 Oak Avenue"},
    };

    // Static list to store login records
    private static List<LoginRecord> loginRecords = new List<LoginRecord>();
    public IActionResult Lab5()
    {
        // var User = new LabUserViewModel
        // {
        //     UserId = 123456,
        //     Name = "Teeraphan ",
        //     LastName = "Thienpromthong",
        //     Age = 20,
        //     Address = "123 Main Street",
        //     Height = 175.5m,
        //     Weight = 70.0m
        // };
        
        // var user = new List<LabUserViewModel>
        // {
        //     new LabUserViewModel {UserId = 123456, Name = "Teeraphan", LastName = "Thienpromthong", Age = 20, Address = "123 Main Street", Height = 175.5m, Weight = 70.0m},
        //     new LabUserViewModel {UserId = 654321, Name = "John", LastName = "Doe", Age = 25, Address = "456 Elm Street", Height = 180.0m, Weight = 80.0m},
        //     new LabUserViewModel {UserId = 789012, Name = "Jane", LastName = "Smith", Age = 30, Address = "789 Oak Avenue", Height = 165.0m, Weight = 60.0m},
        // };
        // return View(user);
        return View();
    }
    [HttpPost]
    public IActionResult Lab5(LabUserViewModel data)
    {
        string? a, b, c;
        a = data.UserId ?? "";
        b = data.Name ?? "";
        c = data.LastName ?? "";


        @ViewBag.UserId = a;
        @ViewBag.Name = b;
        @ViewBag.LastName = c;
  

        return View();
    }
    
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Test1()
    {
        return View();
    }
        public IActionResult Test2()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
