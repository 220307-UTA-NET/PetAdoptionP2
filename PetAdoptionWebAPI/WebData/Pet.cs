namespace WebData.Models;

public class Pet
{
    public int PetId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Type { get; set; }    //pet category, dog, cat, bird, fish etc.
    public string Breed { get; set; }
    public int AccountId { get; set; }
    public DateTime DateAdded { get; set; } = DateTime.Now;
    public bool NeedBeAdopted { get; set; } = false;
    public bool NeedPetSitted { get; set; } = false;
    public string Description { get; set; }
    public string Image { get; set; }
    
}