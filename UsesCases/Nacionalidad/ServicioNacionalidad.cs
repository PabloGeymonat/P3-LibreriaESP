
using AutoMapper;
using DataAccess;
using Domain.Dtos;
using Domain.Models;


namespace UsesCases
{
    public class ServicioNacionalidad : ServicioCRUD<Nacionalidad, NacionalidadDto> , IServicioNacionalidad
    {
        private IRepositoryNacionalidad _repository;
        public ServicioNacionalidad(IMapper mapper, IRepositoryNacionalidad repository) : base(mapper, repository)
        {
            _repository = repository;
        }

        public IEnumerable<NacionalidadDto> GetByName(string nombre)
        {
            IEnumerable<Nacionalidad> Nacionalidads = _repository.GetByName(nombre);
            IEnumerable<NacionalidadDto> NacionalidadsDto = _mapper.Map<IEnumerable<NacionalidadDto>>(Nacionalidads);;
            return NacionalidadsDto;
        }
    }
}