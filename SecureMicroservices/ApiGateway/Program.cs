using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot();
var authenticationProviderkey = "IdentityApiKey";
builder.Services.AddAuthentication()
    .AddJwtBearer(authenticationProviderkey, u =>
    {
        u.Authority = "https://localhost:5005"; // IDENTITY SERVER URL
        //u.RequireHttpsMetadata = false;
        u.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });
var app = builder.Build();
app.MapGet("/", () => "Hello World!");

await app.UseOcelot();

app.Run();
