using AutoMapper;
using CatolicoCantorAPI.Data;
using CatolicoCantorAPI.Implementation;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Mapping;
using CatolicoCantorAPI.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(o => o.AddPolicy("MyPolicy", b =>
{
    b.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

// Add services to the container.


builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 
builder.Services.AddDbContext<AppDbContext>();


builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetConnectionString("DefaultConnection") });

builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();
builder.Services.AddScoped<IMusicManager, MusicManager>();
builder.Services.AddScoped<IMusicRepository, MusicRepository>();

builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
builder.Services.AddScoped<IPlaylistManager, PlaylistManager>();
builder.Services.AddAutoMapper(typeof(CategoryMap),typeof(MusicMap),typeof(PlaylistMap));



builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddSingleton<ICategoryManager, CategoryManager>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.GetService<IDatabaseBootstrap>().Setup();

app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
