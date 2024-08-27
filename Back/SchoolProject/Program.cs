using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Application.Interfaces;
using SchoolProject.Application.Middleware;
using SchoolProject.Application.Service;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.Repositories.Implemetantion;
using SchoolProject.Infrastructure.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Context create
builder.Services.AddDbContext<MyContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
        new MySqlServerVersion("10.4.32")));





builder.Services.AddScoped<IUserRepository, UserReposiotry>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthenticate, AuthenticateService>();



// Configura o JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("a_secure_key_with_32_bytes_minimum")),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



// Add cors especify
builder.Services.AddCors(op => {op.AddPolicy(
    "AllowSpecifyOrigin", builder => {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
    });

var app = builder.Build();  
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<ExceptionHandlingMiddleware>();
// Ensure CORS is enabled before routing
app.UseCors("AllowSpecifyOrigin");
app.UseHttpsRedirection();
// Use authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();
// Map controllers and endpoints
app.MapControllers();

app.Run();


