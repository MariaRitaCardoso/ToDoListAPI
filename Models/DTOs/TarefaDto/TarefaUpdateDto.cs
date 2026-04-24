namespace ToDoList.Models.DTOs.TarefaDto
{
    public class TarefaUpdateDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public bool Concluida { get; set; }
    }
}
