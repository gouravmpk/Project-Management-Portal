using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjectManagementPortal.API.Auth;
using ProjectManagementPortal.BL.Implementation;
using ProjectManagementPortal.BL.Interface;
using ProjectManagementPortal.DL;
using ProjectManagementPortal.DL.Repositories.IRepo;
using ProjectManagementPortal.DL.Repositories.Repo;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ITaskRepo, TaskRepo>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IProjectServices, ProjectServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ITaskServices, TaskServices>();
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("Jwt"));




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
IServiceCollection serviceCollection = builder.Services.AddSwaggerGen((config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1.0.0",
        Title = "ProjectManagementPortal",
        Description = "Manage your Projects and Tasks",
        TermsOfService = new Uri("https://github.com/"),
        License = new OpenApiLicense
        {
            Name = "MIT"
        },
        Contact = new OpenApiContact
        {
            Email = "xyz@gmail.com",
            Name = "Project Management Portal",
            Url = new Uri("https://www.linkedin.com/in/752365169/")
        }
    });

    config.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header
    });

    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    var req = new OpenApiSecurityRequirement();
    req.Add(scheme, new List<string>());
    config.AddSecurityRequirement(req);

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var path = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    config.IncludeXmlComments(path);
}));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
          {
              var secret = builder.Configuration.GetSection("Jwt").GetValue<string>("Secret");
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                  ValidateAudience = false,
                  ValidateIssuer = false,
              };
              options.RequireHttpsMetadata = false;
          });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseStaticFiles();

app.UseRouting();

app.UseCors(options =>
{
    options.AllowAnyMethod();
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
