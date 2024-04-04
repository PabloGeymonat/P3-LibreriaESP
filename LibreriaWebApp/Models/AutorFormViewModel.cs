using Domain.Dtos;


namespace LibreriaWebApp.Models;

public class AutorFormViewModel
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public DateTime? FechaDefuncion { get; set; } // Nullable porque es opcional
    public NacionalidadDto NacionalidadDto { get; set; }

    public int NacionalidadId { get; set; }

    public IEnumerable<NacionalidadDto> posiblesNacionalidades { get; set; }

    public AutorFormViewModel()
    {
    }

    public AutorFormViewModel(AutorDto autorDto)
    {
        Id = autorDto.Id;
        Nombre = autorDto.Nombre;
        FechaNacimiento = autorDto.FechaNacimiento;
        FechaDefuncion = autorDto.FechaDefuncion;
        NacionalidadDto = autorDto.NacionalidadDto;
        NacionalidadId = NacionalidadDto.Id;
    }

    public AutorDto ToAutorDto()
    {
        AutorDto autorDto = new AutorDto()
        {
            Id = Id,
            Nombre = Nombre,
            FechaNacimiento = FechaNacimiento,
            FechaDefuncion = FechaDefuncion,
            NacionalidadId = NacionalidadId,
            NacionalidadDto = null
        };
        return autorDto;
    }
   
}