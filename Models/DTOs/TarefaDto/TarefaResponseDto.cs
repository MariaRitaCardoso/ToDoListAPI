namespace ToDoList.Models.DTOs.TarefaDto
{
    public class TarefaResponseDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public bool Concluida { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? AtualizadaEm { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
