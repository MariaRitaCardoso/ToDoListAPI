using ToDoList.Models.Entities;

namespace ToDoList.Models.DTOs.TarefaDto;

public static class TarefaMapper
{
    public static TarefaResponseDto ToResponse(this Tarefa t) => new()
    {
        Id = t.Id,
        Titulo = t.Titulo,
        Descricao = t.Descricao,
        Concluida = t.Concluida,
        DataCriacao = t.DataCriacao,
        AtualizadaEm = t.AtualizadaEm,
        UsuarioId = t.UsuarioId
    };

    public static Tarefa ToEntity(this TarefaCreateDto dto, Guid usuarioId) => new()
    {
        Id = Guid.NewGuid(),
        Titulo = dto.Titulo.Trim(),
        Descricao = dto.Descricao?.Trim(),
        UsuarioId = usuarioId,
        DataCriacao = DateTime.UtcNow
    };
}