using Microsoft.AspNetCore.Mvc;
using CSI402.ViewModels;

namespace CSI402.Controllers;

public class ProjectController : Controller
{
    public static List<ProjectUserViewModel> LoginUsers = new();
    public static List<ProjectUserViewModel> RegisterUsers = new();
    public IActionResult Index()
    {
        ViewBag.LoginUsers = LoginUsers;
        ViewBag.RegisterUsers = RegisterUsers;
        return View();
    }

    public IActionResult Login()
    {
        return View(new ProjectUserViewModel());
    }

    [HttpPost]

    public IActionResult Login(ProjectUserViewModel model)
    {
        LoginUsers.Add(model);

        return RedirectToAction("Index");
    }

    public IActionResult Register()
    {
        return View(new ProjectUserViewModel());
    }

    [HttpPost]

    public IActionResult Register(ProjectUserViewModel model)
    {
        RegisterUsers.Add(model);
        return RedirectToAction("Index");
    }

    public IActionResult UserList()
    {
        var Users = new List<ProjectUserViewModel>
        {
          new ProjectUserViewModel { Username = "Teeraphan", Name = "Teeraphan", Lastname = "Thienpromthong", Age = 20, Email = "teeraphan@example.com", Tel = "0812345678"},
          new ProjectUserViewModel { Username = "John", Name = "John", Lastname = "Doe", Age = 25, Email = "john.doe@example.com", Tel = "0898765432"},
          new ProjectUserViewModel { Username = "Jane", Name = "Jane", Lastname = "Smith", Age = 30, Email = "jane.smith@example.com", Tel = "0876543210"},
          new ProjectUserViewModel { Username = "Alice", Name = "Alice", Lastname = "Johnson", Age = 22, Email = "alice.johnson@example.com", Tel = "0855555555"},
          new ProjectUserViewModel { Username = "Bob", Name = "Bob", Lastname = "Brown", Age = 28, Email = "bob.brown@example.com", Tel = "0844444444"}
        };
        ViewBag.Users = Users;
        return View(ViewBag.Users);
    }

        public IActionResult AddUser()
        {
            return View(new ProjectUserViewModel());
        }
}
    