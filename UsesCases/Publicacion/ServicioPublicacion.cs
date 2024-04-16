
using AutoMapper;
using DataAccess;
using Domain.Dtos;
using Domain.Models;


namespace UsesCases
{
    public class ServicioPublicacion: IServicioPublicacion
    {
        private IRepositoryPublicacion _repository;
        private IMapper _mapper;
        public ServicioPublicacion(IMapper mapper, IRepositoryPublicacion repository) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<PublicacionDto> GetAll()
        {
            IEnumerable<Publicacion> publicaciones = _repository.GetAll();
            IEnumerable<PublicacionDto> publicacionDtos = _mapper.Map<IEnumerable<PublicacionDto>>(publicaciones);;
            return publicacionDtos;
        }
    }
}