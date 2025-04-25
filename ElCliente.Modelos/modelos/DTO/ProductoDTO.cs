using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElCliente.Modelos.modelos.DTO
{
    public class ProductoDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; } = null!;

        public string? TipoProducto { get; set; } = null!;
        public decimal? ProdMontoMinimo { get; set; }
    }
}
