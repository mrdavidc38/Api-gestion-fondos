using ElCliente.API.General;
using ElCliente.BLL.Servicios.Contrato;
using ElCliente.DAL.DBContext;
using ElCliente.Modelos.modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElCliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _clienteService;

        public ClienteController(ICliente clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("listaTransacciones/{id:int}")]
        public async Task<IActionResult> consultaTransacciones(int id)
        {

            var rsp = new Respuesta<List<TransaccionInscripcion>>();
            try
            {
                rsp.status = true;
                rsp.value = await _clienteService.ConsulaConTransacciones(id);


            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }

            return Ok(rsp);
        }
        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> lista()
        {

            var rsp = new Respuesta<List<Cliente>>();
            try
            {
                rsp.status = true;
                rsp.value = await _clienteService.Lista();


            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }

            return Ok(rsp);
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> crear([FromBody] Cliente cliente )
        {

            var rsp = new Respuesta<Cliente>();
            try
            {
                rsp.status = true;
                rsp.value = await _clienteService.crear(cliente);


            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }

            return Ok(rsp);
        }

        [HttpPost]
        [Route("vincular")]
        public async Task<IActionResult> vinculacion([FromBody] Cliente modelo)
        {

            var rsp = new Respuesta<Cliente>();
            try
            {
                rsp.status = true;
                rsp.value = await _clienteService.VinculacionFondo(modelo);


            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }

            return Ok(rsp);
        }


        [HttpPost]
        [Route("desvinvcular")]
        public async Task<IActionResult> Desvinculacion([FromBody] Cliente modelo)
        {

            var rsp = new Respuesta<Cliente>();
            try
            {
                rsp.status = true;
                rsp.value = await _clienteService.SalirFondo(modelo);


            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }

            return Ok(rsp);
        }
    }
}
