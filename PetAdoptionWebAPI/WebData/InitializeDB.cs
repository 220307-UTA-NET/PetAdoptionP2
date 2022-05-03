using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
namespace WebData.Models;



public static class InitialDB
{
    public static void SeedDatabase(PetDbContext context)
    {
        List<Account> accounts = new List<Account>();
        List<Pet> pets = new List<Pet>();
        List<Message> messages = new List<Message>();
        List<PetWaitingList> petWaitingLists = new List<PetWaitingList>();
        Account a1 = new Account() {
           // AccountId = 1,
            UserName = "zhixin",
            FirstName = "Zhixin",
            LastName = "H",
            Password = "123456",
            Email = "zhixin@email.com",
            Phone = "123456789",
            Address = "12350 Carmel Mountain Rd, San Diego, CA 92128",
            City = "San Diego",
            State = "CA",
            Zip = "92128",
            Country = "USA",
        };
        accounts.Add(a1);
        Account a2 = new Account() {
           // AccountId = 2,
            UserName = "bruk",
            FirstName = "Bruk",
            LastName = "B",
            Password = "123456",
            Email = "bruk@email.com",
            Phone = "234567891",
            Address = "801 S Pavilion Center Dr, Las Vegas, NV 89144",
            City = "Las Vegas",
            State = "NV",
            Zip = "89144",
            Country = "USA",
        };
        accounts.Add(a2);
        Account a3 = new Account() {
           // AccountId = 3,
            UserName = "tahereh",
            FirstName = "Tahereh",
            LastName = "R",
            Password = "123456",
            Email = "tahereh@email.com",
            Phone = "345678912",
            Address = "2901 Los Feliz Blvd, Los Angeles, CA 90039",
            City = "Los Angeles",
            State = "CA",
            Zip = "90039",
            Country = "USA",
        };
        accounts.Add(a3);
        Account a4 = new Account() {
           // AccountId = 4,
            UserName = "kelly",
            FirstName = "Kelly",
            LastName = "K",
            Password = "123456",
            Email = "kelly@email.com",
            Phone = "456789123",
            Address = "4900 Panama Ln, Bakersfield, CA 93313",
            City = "Bakersfield",
            State = "CA",
            Zip = "93313",
            Country = "USA",
        };
        accounts.Add(a4);
        Account a5 = new Account() {
           // AccountId = 5,
            UserName = "christian",
            FirstName = "Christian",
            LastName = "C",
            Password = "123456",
            Email = "christian@email.com",
            Phone = "678912345",
            Address = "8055 Churchill Way, Dallas, TX 75251",
            City = "Dallas",
            State = "TX",
            Zip = "75251",
            Country = "USA",
        };
        accounts.Add(a5);
        Pet p1 = new Pet() {  Name = "Zion", Type = "Zebra", Age = 1, Breed = "African", AccountId = 1, Description = "Zion is a very good pet.", Image ="https://petadoptionp2.blob.core.windows.net/image/zebra.jpg" };
        pets.Add(p1);
        Pet p2 = new Pet() {  Name = "Bush", Type = "Bunny", Age = 2, Breed = "Dutch Rabbit", AccountId = 2, Description = "Bush is a very good pet.", Image = "https://petadoptionp2.blob.core.windows.net/image/dutch-rabbit.jpg" };
        pets.Add(p2);
        Pet p3 = new Pet() {  Name = "Teddy", Type = "Bear", Age = 3, Breed = "Polar Bear", AccountId = 3, Description = "Teddy is a very good pet.", Image ="not available" };
        pets.Add(p3);
        Pet p4 = new Pet() {  Name = "Kitty", Type = "Cat", Age = 4, Breed = "British Shorthair", AccountId = 4, Description = "Kitty is a very good pet.", Image ="not available" };
        pets.Add(p4);
        Pet p5 = new Pet() {  Name = "Captain", Type = "Crocodile", Age = 5, Breed = "American Alligator", AccountId = 5, Description = "Captain is a very good pet.", Image ="not available" };
        pets.Add(p5);
        Message m1 = new Message() {  MessageTopic = "on Zion", MessageText = "I like Zion. He is cool.", CreatedTime = DateTime.Now, FromAccountId = 4, OnPetId = 1 };
        messages.Add(m1);
        Message m2 = new Message() {  MessageTopic = "on Bush", MessageText = "I like Bush. He is cool.", CreatedTime = DateTime.Now, FromAccountId = 5, ToAccountId = 2, OnPetId = 2 };
        messages.Add(m2);
        
        if (context.Accounts.Count() == 0)
        {
            context.Accounts.AddRange(a1, a2, a3, a4, a5);
            context.SaveChanges();
        }
        
        if (context.Pets.Count() == 0)
        {
            context.Pets.AddRange(p1, p2, p3, p4, p5);
            context.SaveChanges();
        }
        
        if (context.Messages.Count() == 0)
        {
            context.Messages.AddRange(m1, m2);
            context.SaveChanges();
        }
        
        
    }
}

