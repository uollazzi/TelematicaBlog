namespace TelematicaBlog.Models;

// POCO -> Plain Old CLR Object

public class ArticoloDTO
{
    public string? Titolo { get; set; }

    public string? Testo { get; set; }

    public int AutoreId { get; set; }

    public int CategoriaId { get; set; }
}
