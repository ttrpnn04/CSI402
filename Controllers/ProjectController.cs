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
}
    