using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TelematicaBlog.DAL;
using TelematicaBlog.DAL.Entities;
using TelematicaBlog.MVC.Extensions;
using TelematicaBlog.MVC.Models;

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

        return View("Dettaglio", articolo.ToArticoloModel());
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var categorie = await _dc.Categorie.ToListAsync();
        var listItems = new SelectList(categorie, "Id", "Nome").ToList();

        ViewData["categorie"] = listItems; // passo alla view la lista di categorie

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ArticoloDTO item)
    {
        try
        {
            var art = new Articolo
            {
                Titolo = item.Titolo,
                Testo = item.Testo,
                Categoria = await _dc.Categorie.FindAsync(item.CategoriaId),
                Autore = await _dc.Utenti.FindAsync(1) // 1 => simulazione!, normalmente si legge da un cookie o JWT                
            };

            _dc.Add(art);

            await _dc.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return View(item);
        }
    }
}
