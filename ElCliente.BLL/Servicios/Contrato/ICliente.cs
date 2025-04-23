using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElCliente.DAL.DBContext;
using ElCliente.Modelos.modelos;

namespace ElCliente.BLL.Servicios.Contrato
{
    public interface ICliente
    {
        Task<List<Cliente>> Lista();
        Task<Cliente> crear(Cliente modelo);
        Task<bool> Editar(Cliente modelo);
        Task<bool> Eliminar(int id);

        Task<Cliente> VinculacionFondo(Cliente modelo);
        Task<Cliente> SalirFondo(Cliente modelo);

        Task<List<TransaccionInscripcion>> ConsulaConTransacciones(int id);

    }
}
