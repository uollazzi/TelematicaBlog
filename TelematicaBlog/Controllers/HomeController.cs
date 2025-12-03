using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelematicaBlog.Models;

namespace TelematicaBlog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("saluta")] // /api/home/saluta
    public ActionResult Saluta()
    {
        return Ok("Ciao");
    }

    [HttpGet("salta")] // /api/home/salta

    public ActionResult Salta()
    {
        return Ok("Quanto in alto?");
    }

    [HttpPost("salva")]
    public ActionResult SalvaArticolo()
    {
        return Ok("Salvato");
    }

    [HttpGet("zoo")] // /api/home/zoo

    public ActionResult Zoo()
    {
        var fufi = new Animale()
        {
            Nome = "Fufi",
            Tipo = "Cane"
        };

        var fiocco = new Animale()
        {
            Nome = "Fiocco",
            Tipo = "Gatto"

        };
        List<Animale> zoo = [fufi, fiocco];

        return Ok(zoo);
    }
}
