using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WepApis92.Services;

namespace WepApis92.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosServices _usuariosServices;
        public UsuariosController(IUsuariosServices usuariosServices) 
        {

            _usuariosServices = usuariosServices;

        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var response = await _usuariosServices.GetUsuarios();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id )
        {
            return Ok(await _usuariosServices.GetByID(id));

        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody]UsuariosResponse request)
        {
            var response = await _usuariosServices.CrearUsuario(request);
            return Ok(response);
            
        }
        [HttpPut("{PkUsuario}")]
        public async Task<IActionResult> Editar(int PkUsuario, [FromBody] UsuariosResponse request)
        {
            var response = await _usuariosServices.EditarUsuario(PkUsuario, request);
            return Ok(response);
        }

        [HttpDelete("{PkUsuario}")]
        public async Task<IActionResult> Eliminar(int PkUsuario)
        {
            var response = await _usuariosServices.EliminarUsuario(PkUsuario);
            return Ok(response);
        }
    }
}
