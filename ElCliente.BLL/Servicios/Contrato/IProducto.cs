using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElCliente.DAL.DBContext;

namespace ElCliente.BLL.Servicios.Contrato
{
    public interface IProducto
    {
        Task<List<Producto>> Lista();
        Task<Producto> crear(Producto modelo);
        Task<bool> Editar(Producto modelo);
        Task<bool> Eliminar(int id);
        Task<List<Producto>> obtenerPorId(int id);
    }
}
