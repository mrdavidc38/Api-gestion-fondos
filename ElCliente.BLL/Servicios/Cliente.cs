using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElCliente.BLL.Integraciones.servicios.contrato;
using ElCliente.BLL.Servicios.Contrato;
using ElCliente.DAL.DBContext;
using ElCliente.DAL.Repositorios.Contrato;
using ElCliente.Modelos.modelos;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ElCliente.BLL.Servicios
{
    public class ClienteService : ICliente
    {
        private readonly IRepositorioGenerico<Cliente> _clienteRepositorio;
        private readonly IRepositorioGenerico<TransaccionInscripcion> _transaccioneRepositorio;
        private readonly IRepositorioGenerico<Producto> _productoRepositorio;
        private readonly IServicioMensajeria _mensajeria;
        public ClienteService(IRepositorioGenerico<Cliente> clienteRepositorio, IRepositorioGenerico<Producto> productoRepositorio,
            IRepositorioGenerico<TransaccionInscripcion> transaccioneRepositorio
            , IServicioMensajeria mensajeria)
        {
            _clienteRepositorio = clienteRepositorio;
            _productoRepositorio = productoRepositorio;
             _transaccioneRepositorio = transaccioneRepositorio;
            _mensajeria = mensajeria;

        }

        public async Task<List<TransaccionInscripcion>> ConsulaConTransacciones(int id)
        {
            try
            {
                var trasaccionesQuery = await _transaccioneRepositorio.Consultar(f => f.Tr_IdCliente == id);
                var resultado = trasaccionesQuery.ToList(); 
                return resultado;
            }
            catch (Exception ex)
            {

                throw new TaskCanceledException(ex.Message);
            }

        }

        public Task<Cliente> crear(Cliente modelo)
        {
            try
            {
                var clienteCreado = _clienteRepositorio.Crear(modelo);

                if (clienteCreado.Id == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el producto");
                }

                return clienteCreado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> Editar(Cliente modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cliente>> Lista()
        {
            var queryCliente = await _clienteRepositorio.Consultar();
            var listaCliente = queryCliente.ToList();

            return listaCliente;
        }

        public async Task<Cliente> SalirFondo(Cliente modelo)
        {
            try
            {
                var clientesConProductos = await _clienteRepositorio.Consultar();
                var cliente = await clientesConProductos
                    .Where(c => c.Id == modelo.Id)
                    .Include(c => c.IdProductos)
                    .FirstOrDefaultAsync();

                if (cliente == null)
                    throw new TaskCanceledException("El cliente no existe");

                var productoId = modelo.IdProductos.FirstOrDefault()?.Id;
                if (productoId == null)
                    throw new TaskCanceledException("Producto no especificado");

                var producto = cliente.IdProductos.FirstOrDefault(p => p.Id == productoId.Value);
                if (producto == null)
                    throw new TaskCanceledException("El producto no está vinculado al cliente");

   
                cliente.IdProductos.Remove(producto);

            
                if (producto.ProdMontoMinimo != null)
                {
                    cliente.CliMonto = (cliente.CliMonto ?? 0) + producto.ProdMontoMinimo;
                }

                TransaccionInscripcion tr = new TransaccionInscripcion()
                {
                    Tr_IdCliente = cliente.Id,
                    Tr_IdProducto = producto.Id,
                    Accion = "Desvinculado",
                    Fecha = DateTime.Now 
                };

                await _transaccioneRepositorio.Crear(tr);


                await _clienteRepositorio.Editar(cliente);


                var clienteConProductosActualizados = await (await _clienteRepositorio.Consultar())
                .Where(j => j.Id == modelo.Id)
                .Select(c => new Cliente
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    CliMonto = c.CliMonto,
                    IdProductos = c.IdProductos.Select(p => new Producto
                    {
                        Id = p.Id,
                        Nombre = p.Nombre,
                        ProdMontoMinimo = p.ProdMontoMinimo
                    }).ToList()
                })
                .FirstOrDefaultAsync();
                return clienteConProductosActualizados;

          

                
            }
            catch (Exception ex)
            {
                throw new TaskCanceledException($"Error al salir del fondo: {ex.Message}");
            }




        }

        public async Task<Cliente> VinculacionFondo(Cliente modelo)
        {
            try
            {
                var clienteConProductos = await (await _clienteRepositorio.Consultar())
                    .Where(j => j.Id == modelo.Id)
                    .Include(c => c.IdProductos)
                    .FirstOrDefaultAsync();

                if (clienteConProductos == null)
                    throw new TaskCanceledException("Cliente no encontrado");

                var productoId = modelo.IdProductos.FirstOrDefault()?.Id;

                if (productoId == null)
                    throw new TaskCanceledException("Producto no especificado");

                var producto = await _productoRepositorio.Obtener(p => p.Id == productoId.Value);

                if (producto == null)
                    throw new TaskCanceledException("Producto no encontrado");


                if (clienteConProductos.IdProductos.Any(p => p.Id == producto.Id))
                    throw new TaskCanceledException("El usuario ya está en el fondo");

                // 3. Validar si el cliente tiene suficiente saldo
                if (clienteConProductos.CliMonto == null || clienteConProductos.CliMonto < producto.ProdMontoMinimo)
                {
                    throw new TaskCanceledException($"No tiene saldo disponible para vincularse al fondo {producto.Nombre}");
                }


                clienteConProductos.IdProductos.Add(producto);


                clienteConProductos.CliMonto -= producto.ProdMontoMinimo;


                TransaccionInscripcion tr = new TransaccionInscripcion()
                {
                    Tr_IdCliente = clienteConProductos.Id,
                    Tr_IdProducto = producto.Id,
                    Accion = "Vinculado", // "Insertar" porque está agregando
                    Fecha = DateTime.Now // Si no tienes default en DB
                };

        
                await _transaccioneRepositorio.Crear(tr);
                var cliente = await _clienteRepositorio.Editar(clienteConProductos);
 

                var clienteConProductosActualizados = await (await _clienteRepositorio.Consultar())
           .Where(j => j.Id == modelo.Id)
           .Select(c => new Cliente           {
               Id = c.Id,
               Nombre = c.Nombre,
               CliMonto = c.CliMonto,
               IdProductos = c.IdProductos.Select(p => new Producto
               {
                   Id = p.Id,
                   Nombre = p.Nombre,
                   ProdMontoMinimo = p.ProdMontoMinimo
               }).ToList()
           })
           .FirstOrDefaultAsync();
                return clienteConProductosActualizados;
            }
            catch (Exception ex)
            {

                throw new TaskCanceledException($"Error en la operación: {ex.Message}");
            }


        }
    }
}
