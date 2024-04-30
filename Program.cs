using Reformation.Database;
using Microsoft.EntityFrameworkCore;
using Reformation.Services.UserService;
using Reformation.Services.AuthService;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Reformation.UnitOfWork;
using FluentValidation;
using Reformation.Validators;
using Reformation.Classes;
using Reformation.Services.RoleService;
using Reformation.Services.PermissionService;
using Reformation.Models;
using Reformation.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(ConfigurationCORS.CallBackMy);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IValidator<ISignUp>, SignUpValidator>();
builder.Services.AddScoped<IValidator<ISignIn>, SignInValidator>();
builder.Services.AddScoped<IValidator<RoleModel>, RoleModelValidator>();
builder.Services.AddScoped<IValidator<PermissionModel>, PermissionModelValidator>();
builder.Services.AddScoped<IValidator<IRefreshToken>, RefreshTokenValidator>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:ACCESS_KEY"] ?? "123456"))
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.Run();