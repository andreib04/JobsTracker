using JobsTracker.API.Extensions;
using JobsTracker.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddSwaggerWithAuth();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


var app = builder.Build();

//app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Swagger"));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
