using Domain.Interfaces;
using Domain.Utils;

namespace Domain.Models;

public class Revista : Publicacion,  ICopiable<Revista>
{
    public string Nombre { get; set; }
    public int Numero { get; set; }
    public int Anio { get; set; }
    public string TablaContenido { get; set; }
    // Validaciones adicionales para nombre y contenido
    public void Copy(Revista model)
    {
        Nombre = model.Nombre;
        Numero = model.Numero;
        Anio = model.Anio;
        TablaContenido = model.TablaContenido;
        base.Copy(model);
    
        
    }

    public override void Validar()
    {
        base.Validar();
        Util.ThrowExceptionIfEmptyString(Nombre, "El nombre de la revista no puede ser vacío");
        Util.ThrowExceptionIfNegativeNumber(Numero, "El número de la revista no puede ser negativo");
        Util.ThrowExceptionIfNegativeNumber(Numero, "El anio no puede ser negativo");
        Util.ThrowExceptionIfEmptyString(TablaContenido, "La trabla de contenido no puede estar vacía");
    }
}