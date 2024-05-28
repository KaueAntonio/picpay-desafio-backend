using PicPay.Core.IoC;
using PicPay.Infrasctructure.IoC;
using PicPay.Infrasctructure.Extensions;
using PicPay.Infrasctructure.Database.Models;
using PicPay.Api.Docs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocs();

builder.Services.AddInfraModules();
builder.Services.AddCoreModules();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();

    await app.ApplyUserRoles();
}

app.AddSwaggerEndpoints();

app.UseHttpsRedirection();

app.MapControllers();

app.MapIdentityApi<User>();

app.Run();
