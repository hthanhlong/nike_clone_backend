using Nike_clone_Backend;
using Serilog;
using FluentValidation;
using System.Text;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Nike_clone_Backend.Database;
using Nike_clone_Backend.Services;
using Nike_clone_Backend.Repositories;
using Nike_clone_Backend.Validators;
using Nike_clone_Backend.Models.DTOs;
using Nike_clone_Backend.Shared;
using nike_clone_backend.Validators;
using nike_clone_backend.Models.DTOs;
using nike_clone_backend.Middlewares;
using Nike_clone_Backend.Utils.Configs;

var builder = WebApplication.CreateBuilder(args);

// configure logging
Log.Logger = (Serilog.ILogger)ConfigLogger.ConfigureLogger();
builder.Host.UseSerilog();
//end logging configuration

// connect database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//end connect database

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddCors(ConfigurationCors.CallBack);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Validators
builder.Services.AddScoped<IValidator<SignUpDto>, SignUpDtoValidator>();
builder.Services.AddScoped<IValidator<SignInDto>, SignInDtoValidator>();
builder.Services.AddScoped<IValidator<CreateRoleDto>, RoleModelValidator>();
builder.Services.AddScoped<IValidator<CreatePermissionDto>, PermissionModelValidator>();
builder.Services.AddScoped<IValidator<RefreshTokenDto>, RefreshTokenDtoValidator>();
builder.Services.AddScoped<IValidator<CreateCategoryDto>, CreateCategoryDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateUserDto>, UpdateUserDtoValidator>();


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
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseMiddleware<SerilogMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.Run();