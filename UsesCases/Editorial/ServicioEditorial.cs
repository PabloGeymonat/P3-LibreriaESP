
using AutoMapper;
using DataAccess;
using Domain.Dtos;
using Domain.Models;


namespace UsesCases
{
    public class ServicioEditorial : ServicioCRUD<Editorial, EditorialDto> , IServicioEditorial
    {
        private IRepositoryEditorial _repository;
        public ServicioEditorial(IMapper mapper, IRepositoryEditorial repository) : base(mapper, repository)
        {
            _repository = repository;
        }

        public IEnumerable<EditorialDto> GetByName(string nombre)
        {
            IEnumerable<Editorial> Editorials = _repository.GetByName(nombre);
            IEnumerable<EditorialDto> EditorialsDto = _mapper.Map<IEnumerable<EditorialDto>>(Editorials);;
            return EditorialsDto;
        }
    }
}