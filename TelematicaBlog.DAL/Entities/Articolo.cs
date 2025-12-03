using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TelematicaBlog.DAL.Entities;

public class Articolo
{
    // Id = Convenzione Chiave Primaria
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Titolo { get; set; }

    [Required]
    public string? Testo { get; set; }

    [Required]
    public virtual Utente? Autore { get; set; }

    [Required]
    public virtual Categoria? Categoria { get; set; }
}

