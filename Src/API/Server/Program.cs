using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
var app = builder.Build();
app.UseInfrastructure(builder.Configuration);
app.MapEndpoints();
app.Run();