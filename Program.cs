using ApiNet6.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
