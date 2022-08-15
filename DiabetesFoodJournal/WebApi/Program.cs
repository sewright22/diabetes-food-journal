global using FastEndpoints;
global using FastEndpoints.Security;
using DataLayer.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.EfCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddAuthenticationJWTBearer("TokenSigningKey");

builder.Services.AddDbContext<sewright22_foodjournalContext>(optionsBuilder =>
{
    optionsBuilder.UseMySql(builder.Configuration["ConnectionStrings:foodJournal"], Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.6.44-mysql"));
});

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
app.Run();