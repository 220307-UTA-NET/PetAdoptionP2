namespace WebData.Models;

public interface IPetRepository
{
    IEnumerable<Pet> Pets { get; }
    void UpdatePet(Pet pet);
    void CreatePet(Pet pet);
    void DeletePet(int petId);
}

public interface IAccountRepository
{
    IEnumerable<Account> Accounts { get; }
    void UpdateAccount(Account account);
    void CreateAccount(Account account);
    void DeleteAccount(int accountId);
}

public interface IMessageRepository
{
    IEnumerable<Message> Messages { get; }
    //void UpdateMessage(Message message);      // once a message is sent, it cannot be updated
    void CreateMessage(Message message);
    //void DeleteMessage(int messageId);    // once a message is sent, it cannot be deleted
}

public interface IPetWaitingListRepository
{
    IEnumerable<PetWaitingList> PetWaitingLists { get; }
    //void UpdatePetWaitingList(PetWaitingList petWaitingList);     // update is not needed, since if you change your mind, you can always delete it
    void CreatePetWaitingList(PetWaitingList petWaitingList);
    void DeletePetWaitingList(int petWaitingListId);
}