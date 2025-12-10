using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TelematicaBlog.DAL;
using TelematicaBlog.DAL.Entities;
using TelematicaBlog.Extensions;
using TelematicaBlog.Models;

namespace TelematicaBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticoliController(BlogContext dc) : ControllerBaseConDataContext(dc)
    {
        [HttpGet] // => GET /api/articoli/
        public async Task<ActionResult<IEnumerable<CategoriaModel>>> GetAll()
        {
            var datiDelDB = await _dc.Articoli
                .Include(a => a.Categoria)
                .Include(a => a.Autore)
                .ToListAsync();

            var datiPerIlClient = datiDelDB.Select(x => x.ToArticoloModel());
           
            return Ok(datiPerIlClient);
        }

        [HttpPost] // => POST /api/articoli/
        public async Task<ActionResult<ArticoloModel>> Add(ArticoloDTO item)
        {
            var categoria = await _dc.Categorie.FindAsync(item.CategoriaId);

            if (categoria == null) {
                return BadRequest("Categoria non trovata");
            }

            var utente = await _dc.Utenti.FindAsync(item.AutoreId);

            if (utente == null) {
                return BadRequest("Autore non trovato");
            }

            var art = new Articolo
            {                
                Titolo = item.Titolo,
                Testo = item.Testo,      
                Autore = utente,
                Categoria = categoria
            };

            _dc.Add(art);

            try
            {
                await _dc.SaveChangesAsync();

                return Ok(art.ToArticoloModel());
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

        [HttpDelete("{id}")] // => DELETE /api/articoli/2
        public async Task<ActionResult> Delete(int id)
        {            
            var art = await _dc.Articoli.FindAsync(id);

            if (art == null)
            {
                return NotFound();
            }

            _dc.Articoli.Remove(art);

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
}
