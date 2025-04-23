using ElCliente.API.General;
using ElCliente.BLL.Servicios.Contrato;
using ElCliente.DAL.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElCliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProducto _productoService;

        public ProductoController(IProducto productoService)
        {
            _productoService = productoService;
        }
        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> lista()
        {

            var rsp = new Respuesta<List<Producto>>();
            try
            {
                rsp.status = true;
                rsp.value = await _productoService.Lista();


            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }

            return Ok(rsp);
        }

        [HttpGet]
        [Route("lista/{id:int}")]
        public async Task<IActionResult> lista(int id)
        {

            var rsp = new Respuesta<List<Producto>>();
            try
            {
                rsp.status = true;
                rsp.value = await _productoService.obtenerPorId(id);


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
