namespace WebData.Models;
public class Message
{
    public int MessageId { get; set; }
    public string MessageTopic { get; set; }
    public string MessageText { get; set; }
    public DateTime CreatedTime { get; set; }
    public int FromAccountId { get; set; }
    public int ToAccountId { get; set; }
    public int OnPetId { get; set; }
}