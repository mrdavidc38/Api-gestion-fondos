using AutoMapper;
using ElCliente.API.General;
using ElCliente.BLL.Servicios.Contrato;
using ElCliente.DAL.DBContext;
using ElCliente.Modelos.modelos;
using ElCliente.Modelos.modelos.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElCliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _clienteService;
        private readonly IMapper _mapper;
        public ClienteController(ICliente clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
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
        public async Task<IActionResult> crear([FromBody] ClienteDTO cliente )
        {

            var rsp = new Respuesta<Cliente>();
            try
            {
                rsp.status = true;
                var clientex= _mapper.Map<Cliente>(cliente);
                rsp.value = await _clienteService.crear(clientex);


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
        public async Task<IActionResult> vinculacion([FromBody] ClienteProductoDTO cliente)
        {

            var rsp = new Respuesta<Cliente>();
            try
            {
                rsp.status = true;
                var clienteProd = _mapper.Map<Cliente>(cliente);
                rsp.value = await _clienteService.VinculacionFondo(clienteProd);


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
        public async Task<IActionResult> Desvinculacion([FromBody] ClienteProductoDTO cliente)
        {

            var rsp = new Respuesta<Cliente>();
            try
            {
                rsp.status = true;
                var clienteProd = _mapper.Map<Cliente>(cliente);
                rsp.value = await _clienteService.SalirFondo(clienteProd);


            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }

            return Ok(rsp);
        }

        [HttpPost]
        [Route("eliminar")]
        public async Task<IActionResult> aliminar([FromBody]int id)
        {

            var rsp = new Respuesta<bool>();
            try
            {
                rsp.status = true;
                //var clientex = _mapper.Map<Cliente>(cliente);
                rsp.value = await _clienteService.Eliminar(id);


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
