namespace TelematicaBlog.Models;

public class ArticoloModel
{
    public int Id { get; set; }

    public string? Titolo { get; set; }

    public string? Testo { get; set; }

    public CategoriaModel? Categoria { get; set; }

    public string? Autore { get; set; } // solo il nome
}
