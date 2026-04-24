using ToDoList.Models.Entities;

namespace ToDoList.Models.DTOs.UsuarioDto;

public static class UsuarioMapper
{
    public static UsuarioResponseDto ToResponse(this Usuario u) => new()
    {
        Id = u.Id,
        Nome = u.Nome,
        Email = u.Email,
        //Tarefas = u.Tarefas?.Select(t => t.ToResponse()).ToList() ?? []
    };

    public static Usuario ToEntity(this UsuarioCreateDto dto) => new()
    {
        Id = Guid.NewGuid(),
        Nome = dto.Nome.Trim(),
        Email = dto.Email.Trim().ToLower()
    };
}