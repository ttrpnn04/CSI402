using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSI402.Models;
using CSI402.Models.Db;
using CSI402.ViewModels;

namespace CSI402.Controllers;

public class HomeController : Controller
{
    private readonly Csi402dbContext _db;

    public HomeController(Csi402dbContext db)
    {
        _db = db;
    }
    public IActionResult Lab08()
    {
        var user = (from u in _db.LabStudents select u).ToList();

        return View(user);
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Lab9()
    {
        return View();
    }

    [HttpPost]
    
    public IActionResult Lab9(Lab9Users data)
    {
        var u = new LabStudent();
        u.StdId = data.UserId;
        u.StdName = data.Name;
        u.StdLastname = data.Lastname;
        u.StdPassword = data.Password;
        _db.Add(u);
        _db.SaveChanges();
        return RedirectToAction("Lab9List","Home");
    }
    public IActionResult Lab9List()
    {
        var user = (from u in _db.LabStudents select u).ToList();
        return View(user);
    }
    public IActionResult Lab10(string UID)
    {
        var check = (from us in _db.LabStudents where us.StdId == UID select new Lab9Users
        {
            UserId = us.StdId,
            Name = us.StdName,
            Lastname = us.StdLastname,
            Password = us.StdPassword
        }).FirstOrDefault();
        return View(check);
    }
    [HttpPost]
    public IActionResult Lab10(Lab9Users data)
    {
        var user = (from u in _db.LabStudents where u.StdId == data.UserId select u).FirstOrDefault();

        user.StdName = data.Name;
        user.StdLastname = data.Lastname;
        user.StdPassword = data.Password;

        _db.Update(user);
        _db.SaveChanges();
        return RedirectToAction("Lab9List");
    }
    public IActionResult Lab10D(string UID)
    {
        var user = (from u in _db.LabStudents where u.StdId == UID select u).FirstOrDefault();
        _db.Remove(user);
        _db.SaveChanges();

        return RedirectToAction("Lab9List");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Assessment()
    {
        ViewBag.FullName = "Teeraphan Thienpromthong";
        ViewBag.RoomNumber = "09-904";
        ViewBag.YearOfStudy = 3;
        ViewBag.FavLanguage = "C#";

        int No1=7,No2=1,No3=3,No4=2,No5=1,No6=4,No7=6,No8=1,No9=9,No10=10,total;

        total=No1+No2+No3+No4+No5+No6+No7+No8+No9+No10;

        ViewBag.Total = total;

        string lowScore = "";

        if (No1 < 5) lowScore += "No1";
        if (No2 < 5) lowScore += " No2";
        if (No3 < 5) lowScore += " No3";
        if (No4 < 5) lowScore += " No4";
        if (No5 < 5) lowScore += " No5";
        if (No6 < 5) lowScore += " No6";
        if (No7 < 5) lowScore += " No7";
        if (No8 < 5) lowScore += " No8";
        if (No9 < 5) lowScore += " No9";
        if (No10 < 5) lowScore += " No10";

        ViewBag.LowScore = lowScore;
        ViewBag.LowScoreWork = lowScore;

        if (total >= 80)
        ViewBag.Grade = "A";
        else if (total >= 76)
        ViewBag.Grade = "B+";
        else if (total >= 70)
        ViewBag.Grade = "B";
        else if (total >= 66)
        ViewBag.Grade = "C+";
        else if (total >= 60)
        ViewBag.Grade = "C";
        else if (total >= 50)
        ViewBag.Grade = "D";
        else
        {
            ViewBag.Grade = "F";
        }

        return View();
    }

    [ActionName("User")]
    public IActionResult UserPage()
    {
        ViewData["Title"] = "User - CSI402";
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
