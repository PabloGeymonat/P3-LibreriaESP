
using DataAccess;
using Microsoft.EntityFrameworkCore;
using UsesCases;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

          
            builder.Services.AddDbContext<DbContext, Contexto>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("StringConnection"));
            });

            //inyecta el repositorio de tema
            builder.Services.AddScoped(typeof(IRepositoryTema), typeof(RepositorioTema));
            builder.Services.AddScoped(typeof(IServicioTema), typeof(ServicioTema));

            builder.Services.AddScoped(typeof(IRepositoryAutor), typeof(RepositorioAutor));
            builder.Services.AddScoped(typeof(IServicioAutor), typeof(ServicioAutor));

            builder.Services.AddScoped(typeof(IRepositoryPais), typeof(RepositorioPais));
            builder.Services.AddScoped(typeof(IServicioPais), typeof(ServicioPais));

            builder.Services.AddScoped(typeof(IRepositoryNacionalidad), typeof(RepositorioNacionalidad));
            builder.Services.AddScoped(typeof(IServicioNacionalidad), typeof(ServicioNacionalidad));

            builder.Services.AddScoped(typeof(IRepositoryProveedor), typeof(RepositorioProveedor));
            builder.Services.AddScoped(typeof(IServicioProveedor), typeof(ServicioProveedor));

            builder.Services.AddScoped(typeof(IRepositoryEditorial), typeof(RepositorioEditorial));
            builder.Services.AddScoped(typeof(IServicioEditorial), typeof(ServicioEditorial));

            builder.Services.AddScoped(typeof(IRepositoryRevista), typeof(RepositorioRevista));
            builder.Services.AddScoped(typeof(IServicioRevista), typeof(ServicioRevista));

            builder.Services.AddScoped(typeof(IRepositoryLibro), typeof(RepositorioLibro));
            builder.Services.AddScoped(typeof(IServicioLibro), typeof(ServicioLibro));

            builder.Services.AddScoped(typeof(IRepositoryParametro), typeof(RepositoryParametro));
            builder.Services.AddScoped(typeof(IServicioParametro), typeof(ServicioParametro));

            builder.Services.AddScoped(typeof(IRepositoryFacturaDeCompra), typeof(RepositorioFacturaDeCompra));
            builder.Services.AddScoped(typeof(IServicioFacturaDeCompra), typeof(ServicioFacturaDeCompra));

            builder.Services.AddScoped(typeof(IRepositoryPublicacion), typeof(RepositorioPublicacion));
            builder.Services.AddScoped(typeof(IServicioPublicacion), typeof(ServicioPublicacion));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
