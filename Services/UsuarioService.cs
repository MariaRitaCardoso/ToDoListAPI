using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models.DTOs.UsuarioDto;

namespace Aula_01.Api.Services;

public class UsuarioService(AppDbContext context)
{
    public async Task<List<UsuarioResponseDto>> GetAllAsync()
    {
        var usuarios = await context.Usuarios
            .Include(u => u.Tarefas) // Traz as tarefas junto
            .AsNoTracking()
            .ToListAsync();

        return usuarios.Select(u => u.ToResponse()).ToList();
    }

    public async Task<UsuarioResponseDto?> GetByIdAsync(Guid id)
    {
        var usuario = await context.Usuarios
            .Include(u => u.Tarefas)
            .FirstOrDefaultAsync(u => u.Id == id);

        return usuario?.ToResponse();
    }

    public async Task<UsuarioResponseDto> CreateAsync(UsuarioCreateDto dto)
    {
        var emailExiste = await context.Usuarios
            .AnyAsync(u => u.Email == dto.Email);

        if (emailExiste)
        {
            throw new Exception("Este e-mail já está sendo utilizado.");
        }

        var usuario = dto.ToEntity();
        usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

        context.Usuarios.Add(usuario);
        await context.SaveChangesAsync();

        return usuario.ToResponse();
    }
}