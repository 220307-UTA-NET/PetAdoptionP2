using Microsoft.EntityFrameworkCore;
using WebData.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PetDbContext>(opts =>
{
    //opts.UseSqlServer(builder.Configuration["ConnectionStrings:DevelopmentConnection"]);
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:ProductConnection"]);
});
builder.Services.AddScoped<IAccountRepository, EFAccountRepository>();
builder.Services.AddScoped<IPetRepository, EFPetRepository>();
builder.Services.AddScoped<IMessageRepository, EFMessageRepository>();
builder.Services.AddScoped<IPetWaitingListRepository, EFPetWaitingListRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<PetDbContext>();
InitialDB.SeedDatabase(context);

app.Run();
