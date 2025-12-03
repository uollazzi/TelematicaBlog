using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TelematicaBlog.DAL.Entities;

public class Commento
{
    public int Id { get; set; }

    [Required]
    [MaxLength(250)]
    public string? Testo { get; set; }

    [Required]
    public virtual Utente? Autore { get; set; }
}

