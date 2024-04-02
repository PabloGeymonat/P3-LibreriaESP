
using AutoMapper;
using DataAccess;
using Domain.Dtos;
using Domain.Models;


namespace UsesCases
{
    public class ServicioTema : ServicioCRUD<Tema, TemaDto> , IServicioTema
    {
        private IRepositoryTema _repository;
        public ServicioTema(IMapper mapper, IRepositoryTema repository) : base(mapper, repository)
        {
            _repository = repository;
        }

        public IEnumerable<TemaDto> GetByName(string nombre)
        {
            IEnumerable<Tema> temas = _repository.GetByName(nombre);
            IEnumerable<TemaDto> temasDto = _mapper.Map<IEnumerable<TemaDto>>(temas);;
            return temasDto;
        }
    }
}