using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSI402.Models;

namespace CSI402.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
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
