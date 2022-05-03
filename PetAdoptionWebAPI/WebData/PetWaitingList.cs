namespace WebData.Models;

public class PetWaitingList
{
    public int PetWaitingListId { get; set; }
    public int PetId { get; set; }
    public int WaitFor { get; set; } //1-adoption, 2-sitting
    public int AccountId { get; set; }
}