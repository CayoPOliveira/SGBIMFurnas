using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SGBIMFurnas.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Database
var ConnectionString = builder.Configuration.GetConnectionString("SGBIMConecction");
builder.Services.AddDbContext<DatabaseContext>(opts => opts.UseLazyLoadingProxies().UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)));
// Mapper (DTOs)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Controller
builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema Gestor BIM API", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
