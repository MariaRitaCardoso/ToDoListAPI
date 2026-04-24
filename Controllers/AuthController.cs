using Aula_01.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ToDoList.Data;
using ToDoList.Models.DTOs.UsuarioDto;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly AuthService _authService;
        private readonly UsuarioService _usuarioService;

        public AuthController(AppDbContext context, AuthService authService, UsuarioService usuarioService)
        {
            _context = context;
            _authService = authService;
            _usuarioService = usuarioService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponseDto>> GetById(Guid id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            return usuario is not null ? Ok(usuario) : NotFound();
        }

        [HttpPost("register")]
        public async Task<ActionResult<UsuarioResponseDto>> Post(UsuarioCreateDto dto)
        {
            try
            {
                var novoUsuario = await _usuarioService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = novoUsuario.Id }, novoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
