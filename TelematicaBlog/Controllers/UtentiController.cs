using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TelematicaBlog.DAL;
using TelematicaBlog.Extensions;
using TelematicaBlog.Models;

namespace TelematicaBlog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UtentiController(BlogContext dc) : ControllerBaseConDataContext(dc)
{  
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UtenteModel>>> GetAll()
    {
        var data = (await _dc.Utenti
            .ToListAsync())
            .Select(x => x.ToUtenteModel());

        return Ok(data);
    }
}
