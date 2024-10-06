using System.Text;
using API.Data;
using API.Services;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authentication.JwtBearer;
=======
>>>>>>> d5ea07bfc100eb86231620888662a553ad4d7b2d
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();
builder.Services.AddScoped<ITokenService, TokenService>();
<<<<<<< HEAD
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => 
    {
        var tokenKey = builder.Configuration["TokenKey"] 
            ?? throw new ArgumentNullException("TokenKey");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    } );
=======
>>>>>>> d5ea07bfc100eb86231620888662a553ad4d7b2d

var app = builder.Build(); 

app.UseCors(c => c
.AllowAnyHeader()
.AllowAnyMethod()
.WithOrigins(
    "http://localhost:4200",
    "https://localhost:4200"));

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
