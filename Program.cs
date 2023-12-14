using Microsoft.EntityFrameworkCore;
using SGBIMFurnas.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configs do banco
var ConnectionString = builder.Configuration.GetConnectionString("SGBIMConecction");
builder.Services.AddDbContext<EtapaContext>(opts => opts.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)));
// Configs do mapper (DTOs)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Configs de Json

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

app.Run();
