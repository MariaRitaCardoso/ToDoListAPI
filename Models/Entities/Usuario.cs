namespace ToDoList.Models.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
    }
}
