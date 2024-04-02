using Domain.Utils;

namespace Domain.Dtos;

public class LibroDto : PublicacionDto
{
    public string ISBN { get; set; }
    public string Titulo { get; set; }
    

    public override void Validar()
    {
        base.Validar();
        Util.ThrowExceptionIfEmptyString(ISBN, "El ISBN no puede ser vacío");
        Util.ThrowExceptionIfEmptyString(Titulo, "El título no puede ser vacío");
        
    }
}