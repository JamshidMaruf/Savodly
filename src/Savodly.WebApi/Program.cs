using Microsoft.EntityFrameworkCore;
using Savodly.DataAccess.Context;
using Savodly.DataAccess.Repositories;
using Savodly.DataAccess.UnitOfWorks;
using Savodly.Service.Services.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(option
    => option.UseNpgsql(builder.Configuration.GetConnectionString("PostgresSQLConnection")));

builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddAuthorization();


var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
