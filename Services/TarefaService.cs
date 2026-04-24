using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models.DTOs.TarefaDto;
using ToDoList.Models.Entities;

namespace ToDoList.Services;

public class TarefaService
{
    private readonly AppDbContext _context;

    public TarefaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TarefaResponseDto>> ListarAsync(Guid usuarioId)
    {
        return await _context.Tarefas
            .Where(t => t.UsuarioId == usuarioId)
            .Select(t => t.ToResponse())
            .ToListAsync();
    }

    public async Task<TarefaResponseDto?> BuscarPorIdAsync(Guid id, Guid usuarioId)
    {
        var tarefa = await _context.Tarefas
            .FirstOrDefaultAsync(t => t.Id == id && t.UsuarioId == usuarioId);

        return tarefa?.ToResponse();
    }

    public async Task<TarefaResponseDto> CriarAsync(TarefaCreateDto dto, Guid usuarioId)
    {
        var tarefa = dto.ToEntity(usuarioId);

        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();

        return tarefa.ToResponse();
    }

    public async Task<TarefaResponseDto?> AtualizarAsync(Guid id, TarefaUpdateDto dto, Guid usuarioId)
    {
        var tarefa = await _context.Tarefas
            .FirstOrDefaultAsync(t => t.Id == id && t.UsuarioId == usuarioId);

        if (tarefa is null) return null;

        tarefa.Titulo = dto.Titulo.Trim();
        tarefa.Descricao = dto.Descricao?.Trim();
        tarefa.Concluida = dto.Concluida;
        tarefa.AtualizadaEm = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return tarefa.ToResponse();
    }

    public async Task<bool> DeletarAsync(Guid id, Guid usuarioId)
    {
        var tarefa = await _context.Tarefas
            .FirstOrDefaultAsync(t => t.Id == id && t.UsuarioId == usuarioId);

        if (tarefa is null) return false;

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();

        return true;
    }
}