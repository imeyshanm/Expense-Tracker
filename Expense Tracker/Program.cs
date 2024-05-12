using Expense_Tracker.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Expense_Tracker.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Expense_Tracker.Auth;
using Microsoft.AspNetCore.Identity;
//using Nelibur.ObjectMapper;
using Expense_Tracker.Model;
using Expense_Tracker.DTO;
using Expense_Tracker.Configuration;
using Mapster;
using System.Reflection;
using MapsterMapper;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

// For Entity Framework
builder.Services.AddDbContext<ExpenseContexts>(options => options.UseSqlServer(configuration.GetConnectionString("ProductDB")));

// For Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ExpenseContexts>()
    .AddDefaultTokenProviders();

//builder.Services.AddScoped<IUserService, UserService>();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,

        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IBudgetRepository, BudgetRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
//TinyMapper.Bind<Category, CategoryDto>();
//TinyMapper.Bind<List<Category>, List<CategoryDto>>();
//builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
// Register Mapster
//var config = TypeAdapterConfig.GlobalSettings;
//config.Scan(Assembly.GetExecutingAssembly());
//builder.Services.AddSingleton(config);
//builder.Services.AddScoped<IMapper>();
////builder.Services.AddMapster();
///
var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
// scans the assembly and gets the IRegister, adding the registration to the TypeAdapterConfig
typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());
// register the mapper as Singleton service for my application
var mapperConfig = new Mapper(typeAdapterConfig);
builder.Services.AddSingleton<IMapper>(mapperConfig);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

////

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
////JWT Authentication
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        ValidAudience = builder.Configuration["Jwt:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//    };
//});

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//var config = new ConfigurationBuilder()
//            .AddJsonFile("appsettings.json")
//            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
//            .Build();
//var connectionString = config.GetConnectionString("ProductDB");
//Console.WriteLine($"Default ConnectionString: {connectionString}");
//builder.Services.AddDbContext<ExpenseContexts>(options => options.UseSqlServer(connectionString));

//builder.Services.AddTransient<IBudgetRepository, BudgetRepository>();
//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.UseAuthentication(); //first line should be
//app.UseAuthorization(); //second line should be

//app.MapControllers();

//app.Run();
