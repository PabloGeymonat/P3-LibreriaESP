using Domain.Dtos;


namespace LibreriaWebApp.Models;

public class EditorialFormViewModel
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public PaisDto PaisOrigenDto { get; set; }
    public int PaisOrigenId { get; set; }

    public IEnumerable<PaisDto> posiblesPaises { get; set; }

    public EditorialFormViewModel()
    {
    }

    public EditorialFormViewModel(EditorialDto EditorialDto)
    {
        Id = EditorialDto.Id;
        Nombre = EditorialDto.Nombre;
        PaisOrigenDto = EditorialDto.PaisOrigenDto;
    }

    public EditorialDto ToEditorialDto()
    {
        EditorialDto EditorialDto = new EditorialDto()
        {
            Id = Id,
            Nombre = Nombre,
            PaisOrigenId = PaisOrigenId,
            PaisOrigenDto = null
        };
        return EditorialDto;
    }
   
}