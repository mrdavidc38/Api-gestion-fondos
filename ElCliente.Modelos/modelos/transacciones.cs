using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElCliente.Modelos.modelos
{
    public class TransaccionInscripcion
    {
        public int Id { get; set; }
        public int Tr_IdCliente { get; set; }
        public int Tr_IdProducto { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }

}
