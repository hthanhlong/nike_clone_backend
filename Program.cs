using FluentValidation;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Nike_clone_Backend.Database;
using Nike_clone_Backend.Services.AuthService;
using Nike_clone_Backend.Services.UserService;
using Nike_clone_Backend.UnitOfWork;
using Nike_clone_Backend.Validators;
using Nike_clone_Backend.Classes;
using Nike_clone_Backend.Services.RoleService;
using Nike_clone_Backend.Services.PermissionService;
using Nike_clone_Backend.Models;
using Nike_clone_Backend.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(ConfigurationCors.CallBackMy);
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