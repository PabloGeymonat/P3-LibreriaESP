using Domain.Utils;

namespace Domain.Dtos;

public class RevistaDto : PublicacionDto
{
    public string Nombre { get; set; }
    public int Numero { get; set; }
    public int Anio { get; set; }
    public string TablaContenido { get; set; }
  
    public override void Validar()
    {
        base.Validar();
        Util.ThrowExceptionIfEmptyString(Nombre, "El nombre de la revista no puede ser vacío");
        Util.ThrowExceptionIfNegativeNumber(Numero, "El número de la revista no puede ser negativo");
        Util.ThrowExceptionIfNegativeNumber(Anio, "El anio no puede ser negativo");
        Util.ThrowExceptionIfEmptyString(TablaContenido, "La trabla de contenido no puede estar vacía");
    }
}