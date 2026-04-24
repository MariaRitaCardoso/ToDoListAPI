namespace ToDoList.Models.DTOs.TarefaDto
{
    public class TarefaCreateDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
    }
}
