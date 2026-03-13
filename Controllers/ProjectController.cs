using Microsoft.AspNetCore.Mvc;
using CSI402.ViewModels;
using CSI402.Models.Db;
using CSI402.Models;
using System.Diagnostics;

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
        ViewBag.LoginUsers = new List<object>();
        ViewBag.RegisterUsers = new List<object>();
        return View();
    }

    public IActionResult Login()
    {
        return View(new ProjectUserViewModel());
    }

    [HttpPost]
    public IActionResult Login(ProjectUserViewModel model)
    {
        var user = _db.Users.FirstOrDefault(u => (u.UserName == model.UserName || u.Email == model.UserName) && u.Password == model.Password);
        if (user != null)
        {
            HttpContext.Session.SetString("User", user.UserName);
            return RedirectToAction("UserList");
        }
        else
        {
            ModelState.AddModelError("", "Invalid username/email or password");
            return View(model);
        }
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]

    public IActionResult Register(ProjectUserViewModel data)
    {
        var u = new User();
        u.UserName = data.UserName;
        u.Fullname = data.Fullname;
        u.Email = data.Email;
        u.Password = data.Password;
        u.Phone = data.Phone;
        u.Address = data.Address;
        u.Role = "user";
        _db.Add(u);
        _db.SaveChanges();
         return RedirectToAction("UserList");
    }

    public IActionResult UserList()
    {
        var user = (from u in _db.Users select u).ToList();
        return View(user);
    }

        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]  
    public IActionResult AddUser(ProjectUserViewModel data)
    {
        var u = new User();
        u.UserId = data.UserId;
        u.UserName = data.UserName;
        u.Fullname = data.Fullname;
        u.Email = data.Email;
        u.Password = data.Password;
        u.Phone = data.Phone;
        u.Address = data.Address;
        u.Role = data.Role;
        _db.Add(u);
        _db.SaveChanges();
         return RedirectToAction("UserList");
    }
    public IActionResult EditUser(int UID)
    {
        var check = (from us in _db.Users where us.UserId == UID select new ProjectUserViewModel
        {
            UserId = us.UserId,
            UserName = us.UserName,
            Fullname = us.Fullname,
            Email = us.Email,
            Password = us.Password,
            Phone = us.Phone,
            Address = us.Address,
            Role = us.Role
        }).FirstOrDefault();
         return View(check);
    }
    [HttpPost]
    public IActionResult EditUser(ProjectUserViewModel data)
    {
        var user = (from u in _db.Users where u.UserId == data.UserId select u).FirstOrDefault();
        
        user.UserName = data.UserName;
        user.Fullname = data.Fullname;
        user.Email = data.Email;
        user.Password = data.Password;
        user.Phone = data.Phone;
        user.Address = data.Address;
        user.Role = data.Role;

        _db.Update(user);
        _db.SaveChanges();
        
        return RedirectToAction("UserList");
    }
    public IActionResult DeleteUser(int UID)
    {
        var user = (from u in _db.Users where u.UserId == UID select u).FirstOrDefault();
        _db.Remove(user);
        _db.SaveChanges();
        
        return RedirectToAction("UserList");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("User");
        return RedirectToAction("Index", "Project");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
    