using System;
using System.ComponentModel.DataAnnotations;

public class ChatMessage
{
    [Key]
    public int Id { get; set; }
    public string User { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
