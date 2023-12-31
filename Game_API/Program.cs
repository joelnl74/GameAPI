using API.Data;
using Game_API;
using Game_API.Mapper.Content;
using Game_API.Mapper.Content.Interfaces;
using Game_API.Repository.Character;
using Game_API.Repository.Character.IRepository;
using Game_API.Repository.Content;
using Game_API.Repository.Content.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("log/info", rollingInterval:RollingInterval.Day).CreateLogger();
builder.Host.UseSerilog();

// Db context.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

// Services.
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddControllers().AddNewtonsoftJson();

// Repositories
builder.Services.AddScoped<IBaseCharacterRepository, BaseCharacterRepository>();
builder.Services.AddScoped<IContentCharacterTypeRepository, ContentCharacterTypeRepository>();

// Mappers
builder.Services.AddScoped<IContentCharacterTypeMapper, ContentCharacterTypeMapper>();

// Swagger.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
