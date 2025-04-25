using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElCliente.Modelos.modelos.DTO
{
    public class ClienteDTO
    {
        

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Ciudad { get; set; } = null!;
        public decimal? CliMonto { get; set; }



    }
}
