using AutoMapper;
using DataAccess;
using Domain.Dtos;
using Domain.Models;
namespace UsesCases {

    public class ServicioAutor : ServicioCRUD<Autor, AutorDto> , IServicioAutor
    {
        private IRepositoryAutor _repository;
        
        public ServicioAutor(IMapper mapper, IRepositoryAutor repository) : base(mapper, repository)
        {
            _repository = repository;
        }

        public IEnumerable<AutorDto> GetByName(string name)
        {
            IEnumerable<Autor> autores = _repository.GetByName(name);
            IEnumerable<AutorDto> autoresDto = _mapper.Map<IEnumerable<AutorDto>>(autores);;
            return autoresDto;
        }

        public IEnumerable<AutorDto> GetFechaDeNacimentoEntreDosFechas(DateTime desde, DateTime hasta)
        {
            IEnumerable<Autor> autores = _repository.GetFechaDeNacimentoEntreDosFechas(desde, hasta);
            IEnumerable<AutorDto> autoresDto = _mapper.Map<IEnumerable<AutorDto>>(autores);;
            return autoresDto;
        }

        public IEnumerable<AutorDto> GetFechaDeFallecimientoEntreDosFechas(DateTime desde, DateTime hasta)
        {
            IEnumerable<Autor> autores = _repository.GetFechaDeFallecimientoEntreDosFechas(desde, hasta);
            IEnumerable<AutorDto> autoresDto = _mapper.Map<IEnumerable<AutorDto>>(autores);;
            return autoresDto;
        }

        public IEnumerable<AutorDto> GetNacionalidad(int nacionalidadId)
        {
            IEnumerable<Autor> autores = _repository.GetNacionalidad(nacionalidadId);
            IEnumerable<AutorDto> autoresDto = _mapper.Map<IEnumerable<AutorDto>>(autores);;
            return autoresDto;
        }
    }
}
