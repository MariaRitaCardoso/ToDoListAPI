using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.DTOs.ComentarioDto;
using ToDoList.Services;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/tarefas/{tarefaId}/comentarios")]
[Authorize]
public class ComentarioController : ControllerBase
{
    private readonly ComentarioService _service;

    public ComentarioController(ComentarioService service)
    {
        _service = service;
    }

    private Guid GetUsuarioId() =>
        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    [HttpGet]
    public async Task<IActionResult> Listar(Guid tarefaId)
    {
        var comentarios = await _service.ListarPorTarefaAsync(tarefaId);
        return Ok(comentarios);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(Guid tarefaId, ComentarioCreateDto dto)
    {
        var comentario = await _service.CriarAsync(dto, tarefaId, GetUsuarioId());

        if (comentario is null)
            return NotFound(new { mensagem = "Tarefa não encontrada." });

        return CreatedAtAction(nameof(Listar), new { tarefaId }, comentario);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(Guid tarefaId, Guid id)
    {
        var resultado = await _service.DeletarAsync(id, GetUsuarioId());

        return resultado switch
        {
            null => NotFound(new { mensagem = "Comentário não encontrado." }),
            false => Forbid(),
            true => NoContent()
        };
    }
}