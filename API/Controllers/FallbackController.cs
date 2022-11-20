using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class FallbackToController : Controller
{
    public IActionResult Index()
    {
        return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/HTML");
    }
}
