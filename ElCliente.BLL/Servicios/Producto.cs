using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ElCliente.BLL.Servicios.Contrato;
using ElCliente.DAL.DBContext;
using ElCliente.DAL.Repositorios.Contrato;

namespace ElCliente.BLL.Servicios
{
    public class ProductoService : IProducto
    {
        private readonly IRepositorioGenerico<Producto> _productoRepositorio;

        public ProductoService(IRepositorioGenerico<Producto> productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        public Task<Producto> crear(Producto modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(Producto modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Producto>> Lista()
        {
            var queryVisitan = await _productoRepositorio.Consultar();
            var listaVisitan = queryVisitan.ToList();

            return listaVisitan;
        }

        public async Task<List<Producto>> obtenerPorId(int id)
        {
        //    var query = await _productoRepositorio.Consultar(
        //    filtro: p => p.IdClientes.Any(c => c.Id == idCliente),
        //    includes: p => p.IdClientes // Asegúrate que el include funcione según tu repositorio
        //);

       var clientesConProductos = await _productoRepositorio.Consultar(filtro: p => p.IdClientes.Any(c => c.Id == id));

            var cliente =  clientesConProductos
                .ToList();

            return cliente;
        }
    }
}
