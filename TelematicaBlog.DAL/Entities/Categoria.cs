using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TelematicaBlog.DAL.Entities;

public class Categoria
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Nome { get; set; }

    [InverseProperty("Categoria")]
    public virtual ICollection<Articolo>? Articoli { get; set; }
}
