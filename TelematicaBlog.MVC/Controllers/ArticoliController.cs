using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TelematicaBlog.DAL;
using TelematicaBlog.MVC.Extensions;

namespace TelematicaBlog.MVC.Controllers;

public class ArticoliController(BlogContext dc) : Controller
{
    private readonly BlogContext _dc = dc;

    public async Task<IActionResult> Index()
    {
        var data = await _dc.Articoli
            .ToListAsync();
            
        return View(data.Select(x => x.ToArticoloModel()));
    }
}
