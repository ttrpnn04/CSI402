using Microsoft.AspNetCore.Mvc;
using CSI402.ViewModels;
using CSI402.Models.Db;

namespace CSI402.Controllers;

public class ProjectController : Controller
{
    public static List<ProjectUserViewModel> LoginUsers = new();
    private readonly Csi402dbContext _db;

    public ProjectController(Csi402dbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        // ViewBag.LoginUsers = LoginUsers;
        // ViewBag.RegisterUsers = RegisterUsers;
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

    public IActionResult Register(ProjectUserViewModel data)
    {
        var u = new User
        {
            UserId = data.UserId,
            FullName = data.FullName,
            Email = data.Email,
            Password = data.Password,
            Phone = data.Phone,
            Address = data.Address,
            Role = data.Role
        };
        _db.Add(u);
        _db.SaveChanges();
         return RedirectToAction("UserList", "Home");
    }

    public IActionResult UserList()
    {
        var user = (from u in _db.Users select u).ToList();
        return View(user);
    }

        public IActionResult AddUser()
        {
            return View(new ProjectUserViewModel());
        }
}
    