using DataAccess;
using Domain.Dtos;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using UsesCases;
using UsesCases.AutoMapper;

namespace LibreriaWebApp
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
            /*
                Al pasar AppDomain.CurrentDomain.GetAssemblies() a AddAutoMapper, le estás diciendo a AutoMapper que busque 
                en todos los ensamblados cargados en el dominio de aplicación por clases que heredan de Profile, las cuales contienen 
                configuraciones de mapeo entre tipos. AutoMapper utiliza estas configuraciones para realizar las operaciones de mapeo.
            */
            
            /*
             * AddScoped (Scoped):
               
               builder.Services.AddScoped registra un servicio con un tiempo de vida de ámbito (scoped). Un servicio registrado 
               como Scoped es creado una vez por solicitud dentro de la aplicación. Esto significa que, en una aplicación web, 
               una nueva instancia del servicio será creada para cada solicitud HTTP y todos los componentes que procesan esa 
               solicitud compartirán la misma instancia del servicio. Este tiempo de vida es útil para servicios que deben mantener 
               un estado consistente dentro de una solicitud, pero no se deben compartir entre diferentes solicitudes.
               AddDbContext (Scoped por defecto):
               
               AddDbContext 
               
               es un método específico para registrar un contexto de base de datos de Entity Framework Core en el 
               contenedor de DI. Por defecto, los contextos de base de datos registrados con AddDbContext tienen un tiempo de 
               vida Scoped, lo que significa que se comportan de la misma manera que los servicios registrados con AddScoped. 
               Sin embargo, puedes cambiar el tiempo de vida al registrar el contexto si es necesario. Registrar un contexto 
               de base de datos como Scoped asegura que las operaciones realizadas en una sola solicitud compartan el mismo contexto y, 
               por tanto, puedan participar en la misma transacción de base de datos.
               AddSingleton (Singleton):
               
               AddSingleton 
               
               registra un servicio con un tiempo de vida de singleton. Un servicio registrado 
               como Singleton se crea solo una vez durante el ciclo de vida de la aplicación y esa misma instancia se reutiliza en 
               todas las solicitudes y componentes que necesiten ese servicio. Esto es útil para servicios que mantienen un estado 
               global o que son costosos de crear y se pueden compartir de forma segura entre diferentes solicitudes. Sin embargo, 
               debes tener cuidado con los servicios singleton para evitar problemas de concurrencia y asegurarte de que el servicio 
               pueda funcionar de manera segura en un entorno multi-hilo.
             */
            /***/
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "parametro",
                pattern: "{controller=Home}/{action=Index}/{clave?}");
            app.UseSession();
            app.Run();
        }
    }
}
