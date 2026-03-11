using Microsoft.AspNetCore.Mvc;
using CSI402.ViewModels;
using CSI402.Models.Db;

namespace CSI402.Controllers;

public class ProjectController : Controller
{
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

        return RedirectToAction("Index");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]

    public IActionResult Register(ProjectUserViewModel data)
    {
        var u = new User();
        u.UserId = data.UserId;
        u.FullName = data.FullName;
        u.Email = data.Email;
        u.Password = data.Password;
        u.Phone = data.Phone;
        u.Address = data.Address;
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
    