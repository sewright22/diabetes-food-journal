global using FastEndpoints;
global using FastEndpoints.Security;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddAuthenticationJWTBearer("TokenSigningKey");

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
app.Run();