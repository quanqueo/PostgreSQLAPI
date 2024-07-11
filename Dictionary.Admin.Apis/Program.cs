using DictionaryMng.Business.Implementation;
using DictionaryMng.Db;
using Microsoft.EntityFrameworkCore;
using SERP.Framework.ApiUtils;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});
builder.Services.RegisterCommonServiceComponents(builder.Configuration);


var connectionString = "Host=192.168.1.12; Port=5430; Database=quanqueo; Username=quanqueo; Password=quanqueo1309";
builder.Services.AddDbContext<CityDbContext>(x => x.UseNpgsql(connectionString));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICityRepository, CityRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
