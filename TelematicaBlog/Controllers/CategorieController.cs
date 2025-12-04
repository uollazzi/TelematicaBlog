using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TelematicaBlog.DAL;
using TelematicaBlog.DAL.Entities;
using TelematicaBlog.Extensions;
using TelematicaBlog.Models;

namespace TelematicaBlog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategorieController : ControllerBase
{    
    private readonly BlogContext _dc;

    public CategorieController(BlogContext dc)
    {
        _dc = dc;
    }

    [HttpGet] // => GET /api/categorie/
    public async Task<ActionResult<IEnumerable<CategoriaModel>>> GetAll()
    {
        var data = await _dc.Categorie
            .Select(x => x.ToCategoriaModel())
            .ToListAsync();

        return Ok(data);
    }

    [HttpGet("{id}")] // => GET /api/categorie/2
    public async Task<ActionResult<CategoriaModel>> GetById(int id)
    {
        var cat = await _dc.Categorie.SingleOrDefaultAsync(x => x.Id == id);

        if (cat == null)
        {
            return NotFound();
        }

        return Ok(cat.ToCategoriaModel());
    }

    [HttpPost] // => POST /api/categorie/
    public async Task<ActionResult<CategoriaModel>> Add(CategoriaDTO item)
    {
        var cat = new Categoria
        {
            Id = item.Id,
            Nome = item.Nome
        };

        _dc.Add(cat);

        try
        {
            await _dc.SaveChangesAsync();

            return Ok(cat.ToCategoriaModel());
        }
        catch(DbUpdateException ex)
        {
            return BadRequest(ex.InnerException?.Message);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut("{id}")] // => PUT /api/categorie/2
    public async Task<ActionResult<CategoriaModel>> Update(int id, CategoriaDTO item)
    {
        // var cat = await _dc.Categorie.SingleOrDefaultAsync(x => x.Id == id); // alternativa 1
        var cat = await _dc.Categorie.FindAsync(id); // alternativa 2

        if (cat == null)
        {
            return NotFound();
        }

        cat.Id = item.Id;
        cat.Nome = item.Nome;

        try
        {
            await _dc.SaveChangesAsync();

            return Ok(cat.ToCategoriaModel());
        }
        catch (DbUpdateException ex)
        {
            return BadRequest(ex.InnerException?.Message);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpDelete("{id}")] // => DELETE /api/categorie/2
    public async Task<ActionResult> Delete(int id)
    {
        // var cat = await _dc.Categorie.SingleOrDefaultAsync(x => x.Id == id); // alternativa 1
        var cat = await _dc.Categorie.FindAsync(id); // alternativa 2

        if (cat == null)
        {
            return NotFound();
        }

        _dc.Categorie.Remove(cat);

        try
        {
            await _dc.SaveChangesAsync();

            return NoContent();
        }
        catch (DbUpdateException ex)
        {
            return BadRequest(ex.InnerException?.Message);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
