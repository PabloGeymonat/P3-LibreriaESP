
using AutoMapper;
using DataAccess;
using Domain.Dtos;
using Domain.Models;


namespace UsesCases
{
    public class ServicioPais : ServicioCRUD<Pais, PaisDto> , IServicioPais
    {
        private IRepositoryPais _repository;
        public ServicioPais(IMapper mapper, IRepositoryPais repository) : base(mapper, repository)
        {
            _repository = repository;
        }

        public IEnumerable<PaisDto> GetByName(string nombre)
        {
            IEnumerable<Pais> Paiss = _repository.GetByName(nombre);
            IEnumerable<PaisDto> PaissDto = _mapper.Map<IEnumerable<PaisDto>>(Paiss);;
            return PaissDto;
        }
    }
}