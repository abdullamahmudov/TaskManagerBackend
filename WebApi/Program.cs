using DBLayer.Common;
using TaskManagerBase.Implementations;
using TaskManagerBase.Interfaces;
using TaskManagerBase.Methods;
using WebApi.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InitiolizeSQLiteServices();
builder.Services.AddScoped<ICripto, DefaultCripto>();
builder.Services.AddSingleton<Cache>();
builder.Services.AddScoped<IUserControll, UserControll>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.UseAuthentication();
app.MapControllers();

app.Run();
