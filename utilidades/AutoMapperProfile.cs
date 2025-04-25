using AutoMapper;
using ElCliente.DAL.DBContext;
using ElCliente.Modelos.modelos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ForMember(destino =>
            destino.Nombre,
            opt => opt.MapFrom(origen => origen.Nombre)
            ).ForMember(destino => destino.Apellidos,
            opt => opt.MapFrom(origen => origen.Apellidos))
            .ForMember(destino => destino.Ciudad,
            opt => opt.MapFrom(origen => origen.Ciudad))
                        .ForMember(destino => destino.CliMonto,
            opt => opt.MapFrom(origen => origen.CliMonto))
            .ReverseMap();

            CreateMap<Cliente, ClienteProductoDTO>().ForMember(destino =>
            destino.Nombre,
            opt => opt.MapFrom(origen => origen.Nombre)
            ).ForMember(destino => destino.Apellidos,
            opt => opt.MapFrom(origen => origen.Apellidos))
            .ForMember(destino => destino.Ciudad,
            opt => opt.MapFrom(origen => origen.Ciudad))
                        .ForMember(destino => destino.IdProductos,
            opt => opt.MapFrom(origen => origen.IdProductos))
                                       .ForMember(destino => destino.CliMonto,
            opt => opt.MapFrom(origen => origen.CliMonto))
            .ReverseMap();

            CreateMap<Producto, ProductoDTO>().ForMember(destino =>
            destino.Nombre,
            opt => opt.MapFrom(origen => origen.Nombre)
            ).ForMember(destino => destino.TipoProducto,
            opt => opt.MapFrom(origen => origen.TipoProducto))
            .ForMember(destino => destino.ProdMontoMinimo,
            opt => opt.MapFrom(origen => origen.ProdMontoMinimo))

            .ReverseMap();
        }
    }
}
