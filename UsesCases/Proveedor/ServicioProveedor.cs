
using AutoMapper;
using DataAccess;
using Domain.Dtos;
using Domain.Models;


namespace UsesCases
{
    public class ServicioProveedor : ServicioCRUD<Proveedor, ProveedorDto> , IServicioProveedor
    {
        private IRepositoryProveedor _repository;
        public ServicioProveedor(IMapper mapper, IRepositoryProveedor repository) : base(mapper, repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProveedorDto> GetByName(string nombre)
        {
            IEnumerable<Proveedor> Proveedors = _repository.GetByName(nombre);
            IEnumerable<ProveedorDto> ProveedorsDto = _mapper.Map<IEnumerable<ProveedorDto>>(Proveedors);;
            return ProveedorsDto;
        }
    }
}