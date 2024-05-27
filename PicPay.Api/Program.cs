using PicPay.Core.IoC;
using PicPay.Infrasctructure.Extensions;
using PicPay.Infrasctructure.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

InfraModules.AddInfraModules(builder.Services, builder.Configuration);
CoreModules.AddCoreModules(builder.Services);

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
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
