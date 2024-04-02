using Domain.Interfaces;
using Domain.Utils;

namespace Domain.Models{

    public class Autor: IValidable, IIdentityById, ICopiable<Autor>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime? FechaDefuncion { get; set; } // Nullable porque es opcional
        public Nacionalidad Nacionalidad { get; set; }
        
        // Clave foránea para Nacionalidad es necesaria para cuando se graba no tener que pasar el objeto Nacionalidad!!!!
        
        public int NacionalidadId { get; set; } 
        public IList<PublicacionAutor> Publicaciones { get; set; } = new List<PublicacionAutor>();
       
        public void Copy(Autor model)
        {
            Nombre = model.Nombre;
            FechaNacimiento = model.FechaNacimiento;
            FechaDefuncion = model.FechaDefuncion;
            Nacionalidad = model.Nacionalidad;
            NacionalidadId = model.NacionalidadId;
        }

        public void Validar()
        {
            Util.ThrowExceptionIfEmptyString(Nombre, "El nombre del autor no debe ser vacío");
            Util.ThrowExceptionIfZero(NacionalidadId, "El autor debe tener nacionalidad cargada");
            
        }

        
    }
}
