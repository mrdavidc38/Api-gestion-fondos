using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElCliente.BLL.Integraciones.servicios.contrato
{
    public interface IServicioMensajeria
    {
        Task enviarCorreo(string toNumber, string message);
    }
}
