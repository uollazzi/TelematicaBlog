using System.ComponentModel.DataAnnotations;

namespace TelematicaBlog.MVC.Models;

// POCO -> Plain Old CLR Object

public class ArticoloDTO
{
    [Required]
    public string? Titolo { get; set; }

    public string? Testo { get; set; }

    public int AutoreId { get; set; }

    public int CategoriaId { get; set; }
}
