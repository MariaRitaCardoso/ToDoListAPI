namespace ToDoList.Models.Entities
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; } = string.Empty;
        public bool Concluida { get; set; } = false;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? AtualizadaEm { get; set; } = DateTime.UtcNow;

        //Relação com o usuário
        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
