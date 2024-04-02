using System.Transactions;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;

namespace Domain.Models;

public class Libro : Publicacion, ICopiable<Libro>
{
    public string ISBN { get; set; }
    public string Titulo { get; set; }
    
    public void Copy(Libro model)
    {
        ISBN = model.ISBN;
        Titulo = Titulo;
        base.Copy(model);
    }

    public override void Validar()
    {
        base.Validar();
        Util.ThrowExceptionIfEmptyString(ISBN, "El ISBN no puede ser vacío");
        Util.ThrowExceptionIfEmptyString(Titulo, "El título no puede ser vacío");
        
    }
}