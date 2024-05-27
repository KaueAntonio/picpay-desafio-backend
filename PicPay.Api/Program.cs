using PicPay.Core.IoC;
using PicPay.Infrasctructure.IoC;
using PicPay.Infrasctructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

InfraModules.AddInfraModules(builder.Services);
CoreModules.AddCoreModules(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();

    await app.ApplyUserRoles();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
