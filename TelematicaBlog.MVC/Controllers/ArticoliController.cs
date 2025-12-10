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
            .Include(x => x.Categoria)
            .Include(x => x.Autore)
            .ToListAsync();
            
        return View(data.Select(x => x.ToArticoloModel()));
    }

    public async Task<IActionResult> Dettaglio(int id)
    {
        var articolo = await _dc.Articoli
            .Include(x => x.Categoria)
            .Include(x => x.Autore)
            .SingleOrDefaultAsync(x => x.Id == id);

        return View(articolo.ToArticoloModel());
    }
}
