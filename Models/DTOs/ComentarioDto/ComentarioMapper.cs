using ToDoList.Models.Entities;

namespace ToDoList.Models.DTOs.ComentarioDto
{
    public static class ComentarioMapper
    {
        public static ComentarioResponseDto ToResponse(this Comentario u) => new()
        {
            Id = u.Id,
            Conteudo = u.Conteudo,
            CriadoEm = u.CriadoEm,
            TarefaId = u.TarefaId,
            UsuarioId = u.UsuarioId,
            //Tarefas = u.Tarefas?.Select(t => t.ToResponse()).ToList() ?? []
        };

        public static Comentario ToEntity(this ComentarioCreateDto dto, Guid tarefaId, Guid usuarioId) => new()
        {
            Id = Guid.NewGuid(),
            Conteudo = dto.Conteudo.Trim(),
            TarefaId = tarefaId,
            UsuarioId = usuarioId
        };
    }
}
