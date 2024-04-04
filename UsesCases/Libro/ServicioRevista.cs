
using AutoMapper;
using DataAccess;
using Domain.Dtos;
using Domain.Models;


namespace UsesCases
{
    public class ServicioLibro : ServicioCRUD<Libro, LibroDto> , IServicioLibro
    {
        private IRepositoryLibro _repository;
        public ServicioLibro(IMapper mapper, IRepositoryLibro repository) : base(mapper, repository)
        {
            _repository = repository;
        }

        public IEnumerable<LibroDto> GetByISBN(string nombre)
        {
            IEnumerable<Libro> Libros = _repository.GetByISBN(nombre);
            IEnumerable<LibroDto> LibrosDto = _mapper.Map<IEnumerable<LibroDto>>(Libros);;
            return LibrosDto;
        }
    }
}