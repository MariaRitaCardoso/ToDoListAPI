// Controllers/TarefaController.cs
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.DTOs.TarefaDto;
using ToDoList.Services;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] // 👈 Todos os endpoints exigem token
public class TarefaController : ControllerBase
{
    private readonly TarefaService _service;

    public TarefaController(TarefaService service)
    {
        _service = service;
    }

    // Pega o ID do usuário logado direto do token
    private Guid GetUsuarioId() =>
        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var tarefas = await _service.ListarAsync(GetUsuarioId());
        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(Guid id)
    {
        var tarefa = await _service.BuscarPorIdAsync(id, GetUsuarioId());
        return tarefa is null ? NotFound() : Ok(tarefa);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(TarefaCreateDto dto)
    {
        var tarefa = await _service.CriarAsync(dto, GetUsuarioId());
        return CreatedAtAction(nameof(BuscarPorId), new { id = tarefa.Id }, tarefa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(Guid id, TarefaUpdateDto dto)
    {
        var tarefa = await _service.AtualizarAsync(id, dto, GetUsuarioId());
        return tarefa is null ? NotFound() : Ok(tarefa);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(Guid id)
    {
        var deletado = await _service.DeletarAsync(id, GetUsuarioId());
        return deletado ? NoContent() : NotFound();
    }
}