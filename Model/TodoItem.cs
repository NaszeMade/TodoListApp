namespace TodoListApp.Model
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool IsCompleted { get; set; }
        public string Category { get; set; } // e.g., Work, Personal
    }
}