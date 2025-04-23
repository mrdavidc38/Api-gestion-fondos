using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElCliente.BLL.Integraciones.servicios;
using ElCliente.BLL.Integraciones.servicios.contrato;
using ElCliente.BLL.Servicios;
using ElCliente.BLL.Servicios.Contrato;
using ElCliente.DAL.DBContext;
using ElCliente.DAL.Repositorios;
using ElCliente.DAL.Repositorios.Contrato;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dependencias
{
    public static class Dependencias
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ElClienteContext>(options =>
            {
                var con = configuration.GetConnectionString("cadenaSQL");
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });
            services.AddTransient(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
            services.AddScoped<IProducto, ProductoService>();
            services.AddScoped<ICliente, ClienteService>();
            services.AddScoped<IServicioMensajeria, ServicioMensajeria>();

        }

    }
}
