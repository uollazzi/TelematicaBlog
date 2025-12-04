using TelematicaBlog.DAL.Entities;
using TelematicaBlog.Models;

namespace TelematicaBlog.Extensions;

public static class ModelsExtensions
{
    public static CategoriaModel ToCategoriaModel(this Categoria item)
    {
        return new CategoriaModel() { 
            Id = item.Id, 
            Nome = item.Nome 
        };
    }

    public static UtenteModel ToUtenteModel(this Utente item)
    {
        return new UtenteModel()
        {
            Id = item.Id,
            Nome = item.Nome
        };
    }
}
