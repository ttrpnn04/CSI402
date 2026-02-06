using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSI402.Models;
using CSI402.ViewModels;

namespace CSI402.Controllers;

public class AccountController : Controller
{
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
        string a,b,c;
        a=data.UserId;
        b=data.Name;
        c=data.LastName;

        @ViewBag.UserId = a;
        @ViewBag.Name = b;
        @ViewBag.LastName = c;

        return View();
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
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

    public IActionResult Assessment()
    {
        String name = "Chonlakorn Bualuang",
        classroom = "05-0904",
        educationYear = "3",
        favLanguage = "HTML,CSS,JavaScript";

        ViewBag.Name = name;
        ViewBag.Classroom = classroom;
        ViewBag.EducationYear = educationYear;
        ViewBag.FavLanguage = favLanguage;

        int W1 = 4, W2 = 9, W3 = 4, W4 = 2, W5 = 4,
            W6 = 4, W7 = 4, W8 = 4, W9 = 4, W10 = 9;

        int totalScore = W1 + W2 + W3 + W4 + W5 + W6 + W7 + W8 + W9 + W10;
        ViewBag.TotalScore = totalScore;

        if (totalScore >= 80)
        {
            ViewBag.Grade = "A";
        }
        else if (totalScore >= 76)
        {
            ViewBag.Grade = "B+";
        }
        else if (totalScore >= 70)
        {
            ViewBag.Grade = "B";
        }
        else if (totalScore >= 66)
        {
            ViewBag.Grade = "C+";
        }
        else if (totalScore >= 60)
        {
            ViewBag.Grade = "C";
        }
        else if (totalScore >= 56)
        {
            ViewBag.Grade = "D+";
        }
        else if (totalScore >= 50)
        {
            ViewBag.Grade = "D";
        }
        else
        {
            ViewBag.Grade = "F";
        }

        if (ViewBag.Grade == "F")
        {
            // if grade is F, show works score that are less than 5 and show string the work number
            List<string> lowScores = new List<string>();

            if (W1 < 5) lowScores.Add("W1 = " + W1);
            if (W2 < 5) lowScores.Add("W2 = " + W2);
            if (W3 < 5) lowScores.Add("W3 = " + W3);
            if (W4 < 5) lowScores.Add("W4 = " + W4);
            if (W5 < 5) lowScores.Add("W5 = " + W5);
            if (W6 < 5) lowScores.Add("W6 = " + W6);
            if (W7 < 5) lowScores.Add("W7 = " + W7);
            if (W8 < 5) lowScores.Add("W8 = " + W8);
            if (W9 < 5) lowScores.Add("W9 = " + W9);
            if (W10 < 5) lowScores.Add("W10 = " + W10);
            ViewData["LowScores"] = lowScores;
        }
        else
        {
            ViewData["LowScores"] = null;
        }
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
