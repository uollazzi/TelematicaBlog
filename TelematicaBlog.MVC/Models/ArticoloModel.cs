namespace TelematicaBlog.MVC.Models;

public class ArticoloModel
{
    public int Id { get; set; }

    public string? Titolo { get; set; }

    public string? Testo { get; set; }

    public CategoriaModel? Categoria { get; set; }

    public string? Auotore { get; set; } // solo il nome
}
