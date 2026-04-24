namespace ToDoList.Models.DTOs.ComentarioDto
{
    public class ComentarioResponseDto
    {
        public Guid Id { get; set; }
        public string Conteudo { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public Guid TarefaId { get; set; }
        public Guid UsuarioId { get; set; }
        public string NomeUsuario { get; set; } = string.Empty;
    }
}
