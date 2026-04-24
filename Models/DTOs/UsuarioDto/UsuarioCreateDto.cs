using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.DTOs.UsuarioDto
{
    public class UsuarioCreateDto
    {
        [Required, MinLength(3), MaxLength(50)]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6), MaxLength(16)]
        public string Senha { get; set; }
    }
}
