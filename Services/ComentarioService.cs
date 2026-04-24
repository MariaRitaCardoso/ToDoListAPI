using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models.DTOs.ComentarioDto;
using ToDoList.Models.Entities;

namespace ToDoList.Services;

public class ComentarioService
{
    private readonly AppDbContext _context;

    public ComentarioService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ComentarioResponseDto>> ListarPorTarefaAsync(Guid tarefaId)
    {
        return await _context.Comentarios
            .Include(c => c.Usuario)
            .Where(c => c.TarefaId == tarefaId)
            .OrderBy(c => c.CriadoEm)
            .Select(c => c.ToResponse())
            .ToListAsync();
    }

    public async Task<ComentarioResponseDto?> CriarAsync(ComentarioCreateDto dto, Guid tarefaId, Guid usuarioId)
    {
        var tarefaExiste = await _context.Tarefas.AnyAsync(t => t.Id == tarefaId);
        if (!tarefaExiste) return null;

        var comentario = dto.ToEntity(tarefaId, usuarioId);

        _context.Comentarios.Add(comentario);
        await _context.SaveChangesAsync();

        await _context.Entry(comentario)
            .Reference(c => c.Usuario)
            .LoadAsync();

        return comentario.ToResponse();
    }

    public async Task<bool?> DeletarAsync(Guid id, Guid usuarioId)
    {
        var comentario = await _context.Comentarios
            .FirstOrDefaultAsync(c => c.Id == id);

        if (comentario is null) return null;
        if (comentario.UsuarioId != usuarioId) return false;

        _context.Comentarios.Remove(comentario);
        await _context.SaveChangesAsync();

        return true;
    }
}