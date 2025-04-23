using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElCliente.Modelos.modelos.Integraciones
{
    public class configuracionesEnvio
    {
        public string AccountSid { get; set; }  // Tu SID de cuenta Twilio
        public string AuthToken { get; set; }   // Tu token de autenticación
        public string FromNumber { get; set; }
    }
}
