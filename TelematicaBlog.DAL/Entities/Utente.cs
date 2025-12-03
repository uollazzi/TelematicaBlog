using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TelematicaBlog.DAL.Entities;

public class Utente
{
    public int Id { get; set; }

    [Required]
    public string? Nome { get; set; }

    [InverseProperty("Autore")]
    public virtual ICollection<Articolo>? Articoli { get; set; }

    [InverseProperty("Autore")]
    public virtual ICollection<Commento>? Commenti { get; set; }
}
