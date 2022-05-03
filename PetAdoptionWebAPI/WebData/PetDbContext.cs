using Microsoft.EntityFrameworkCore;


namespace WebData.Models;

public class PetDbContext : DbContext
{
    public DbSet<Pet> Pets => Set<Pet>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<PetWaitingList> PetWaitingLists => Set<PetWaitingList>();

    public PetDbContext(DbContextOptions<PetDbContext> options)
        : base(options)
    {
    }
    //public PetDbContext()
    //    : base()
    //{
    //}
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(@"Server=Thinker\\MSSQLSERVER,1433;Database=LocalDB;Trusted_Connection=True;MultipleActiveResultSets=true");
    //}
}