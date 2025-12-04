using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TelematicaBlog.DAL;
using TelematicaBlog.Extensions;
using TelematicaBlog.Models;

namespace TelematicaBlog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UtentiController : ControllerBase
{
    private readonly BlogContext _dc;

    public UtentiController(BlogContext dc)
    {
        _dc = dc;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UtenteModel>>> GetAll()
    {
        var data = (await _dc.Utenti
            .ToListAsync())
            .Select(item => new UtenteModel()
            {
                Id = item.Id,
                Nome = item.Nome
            });

        return Ok(data);
    }
}
