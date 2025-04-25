using ElCliente.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElCliente.Modelos.modelos.DTO
{
    public class ClienteProductoDTO
    {
        public int? Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Ciudad { get; set; } = null!;
        public decimal? CliMonto { get; set; }

        public virtual ICollection<ProductoDTO>? IdProductos { get; set; } = new List<ProductoDTO>();
    }
}
