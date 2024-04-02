using Domain.Dtos;


namespace LibreriaWebApp.Models;

public class EditorialIndexViewModel
{

    public string Nombre { get; set; }
    public IEnumerable<EditorialDto> EditorialesDto { get; set; }
}