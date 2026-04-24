namespace ToDoList.Models.Entities;

public class Comentario
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Conteudo { get; set; } = string.Empty;

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    // FK - tarefa que recebeu o comentario
    public Guid TarefaId { get; set; }

    // Propriedade de navegacao
    public Tarefa? Tarefa { get; set; }

    // FK - usuario que fez o comentario
    public Guid UsuarioId { get; set; }

    // Propriedade de navegacao
    public Usuario? Usuario { get; set; }
}