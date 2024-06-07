using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WepApis92.Services;

namespace WepApis92.Controllers
{
    //3. despues de mibracion crear controlador MVC en blanco y a este poner al lado del controller Base
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorServices _autorServices;
        public AutoresController(IAutorServices autorServices)
        {
            _autorServices = autorServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {
            return Ok(await _autorServices.GetAutores());
        }

        [HttpPost]
        public async Task<IActionResult> CrearAutor([FromBody]Autor autor)
            //se le da a crl + . para seleccionar la entidad
        {
            return Ok(await _autorServices.Crear(autor));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarAutor(int id, [FromBody] Autor autor)
        {
            return Ok(await _autorServices.Editar(id, autor));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarAutor(int id)
        {
            return Ok(await _autorServices.Eliminar(id));
        }

    }
}
