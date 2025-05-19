using Microsoft.EntityFrameworkCore;
using PowerPressSettingsManager.Data;
using Microsoft.OpenApi.Models;
using PowerPressSettingsManager.Validator;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=presssettings.db"));



builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<CreatePressSettingDtoValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Power Press Settings API",
        Description = "An API to manage press and coil settings"
    });
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Power Press Settings API v1");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();