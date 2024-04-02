
using AutoMapper;
using DataAccess;
using Domain.Dtos;
using Domain.Models;


namespace UsesCases
{
    public class ServicioRevista : ServicioCRUD<Revista, RevistaDto> , IServicioRevista
    {
        private IRepositoryRevista _repository;
        public ServicioRevista(IMapper mapper, IRepositoryRevista repository) : base(mapper, repository)
        {
            _repository = repository;
        }

        public IEnumerable<RevistaDto> GetByName(string nombre)
        {
            IEnumerable<Revista> Revistas = _repository.GetByName(nombre);
            IEnumerable<RevistaDto> RevistasDto = _mapper.Map<IEnumerable<RevistaDto>>(Revistas);;
            return RevistasDto;
        }
    }
}