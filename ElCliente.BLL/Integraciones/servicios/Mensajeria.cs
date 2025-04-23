using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using ElCliente.BLL.Integraciones.servicios.contrato;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Messaging;
using Twilio.Types;
using Twilio;
using ElCliente.Modelos.modelos.Integraciones;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
namespace ElCliente.BLL.Integraciones.servicios
{
    public class ServicioMensajeria : IServicioMensajeria
    {
        private readonly IConfiguration _configuration;
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _fromNumber;

        public ServicioMensajeria(IConfiguration configuration)
        {
            _configuration = configuration;

            // Obtener valores de configuración
            _accountSid = _configuration["TwilioSettings:AccountSid"] ??
                         throw new ArgumentNullException("TwilioSettings:AccountSid no configurado");

            _authToken = _configuration["TwilioSettings:AuthToken"] ??
                        throw new ArgumentNullException("TwilioSettings:AuthToken no configurado");

            _fromNumber = _configuration["TwilioSettings:FromNumber"] ??
                         throw new ArgumentNullException("TwilioSettings:FromNumber no configurado");

            // Inicializar Twilio
            TwilioClient.Init(_accountSid, _authToken);
        }
        public async Task enviarCorreo(string toNumber, string message)
        {
            await MessageResource.CreateAsync(
                body: message,
                from: new PhoneNumber(_fromNumber),
                to: new PhoneNumber("+573193755888")
         );
        }
    }
}
