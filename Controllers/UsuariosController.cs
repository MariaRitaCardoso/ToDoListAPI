using Aula_01.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.DTOs.UsuarioDto;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController(UsuarioService usuarioService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<UsuarioResponseDto>>> Get() =>
            Ok(await usuarioService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponseDto>> GetById(Guid id)
        {
            var usuario = await usuarioService.GetByIdAsync(id);
            return usuario is not null ? Ok(usuario) : NotFound();
        }

    }
}
