using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using UrlShortener.Application.Interfaces;
using UrlShortener.Application.PasswordHasher;
using UrlShortener.Application.Services;
using UrlShortener.Infrastructure;
using UrlShortener.Infrastructure.Configuration;
using UrlShortener.Infrastructure.Repositories;
using UrlShortener.Infrastructure.Repositories.Interfaces;
using UrlShortener.Infrastructure.Services.JwtTokenService;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();



var key = Encoding.ASCII.GetBytes(JwtSettings.SecretKey);

builder.Services.AddAuthentication("OAuth")
    .AddJwtBearer("OAuth", cfg =>
    {
        var secret = JwtSettings.SecretKey;
        var myIssuer = JwtSettings.Issuer;
        var myAudience = JwtSettings.Audience;
        var secretBytes = Encoding.UTF8.GetBytes(secret);
        var key = new SymmetricSecurityKey(secretBytes);

        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = myIssuer,
            ValidAudience = myAudience,
            IssuerSigningKey = key
        };

        cfg.Events = new JwtBearerEvents
        {
            OnChallenge = async context =>
            {
                context.HandleResponse();
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
            }
        };

        cfg.Events = new JwtBearerEvents
        {
            OnForbidden = async context =>
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("You don't have permissions for this action");
            }
        };
    });

builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement 
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddScoped<IShortenedUrlService, ShortenedUrlService>();
builder.Services.AddScoped<IShortenedUrlRepository, ShortenedUrlRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<UrlShortener.API.Middlewares.ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();
app.Run();