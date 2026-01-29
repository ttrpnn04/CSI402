using Microsoft.AspNetCore.Mvc;

namespace CSI402.Controllers;

public class ProjectController : Controller
{
    public IActionResult Index()
    {
        // Set title and request the project-specific layout
        ViewData["Title"] = "Home Page";
        ViewData["Layout"] = "_ProjectLayout";

        // Example: cart item count shown in layout
        ViewBag.CartItemCount = 2;

        return View();
    }
}