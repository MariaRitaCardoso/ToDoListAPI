namespace ToDoList.Models.DTOs.UsuarioDto
{
    public class UsuarioResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = "";
        public string Email { get; set; } = "";
        //public List<TarefaResponseDto> Tarefas { get; set; } = [];
    }
}
