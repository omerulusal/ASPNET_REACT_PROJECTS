using Management_Backend.Core.AutoMapperConfig;
using Management_Backend.Core.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDBContext>(options =>
{
    //VeriTabaný Baglanti ayari
    options.UseSqlServer(builder.Configuration.GetConnectionString("local"));
    //local = AppSetting.jsondaki ConnectionStringsin adýdýr.
});

//Automapper Config
builder.Services.AddAutoMapper(typeof(AutoMCProfile));

builder.Services
    .AddControllers()
    .AddJsonOptions(option =>
    {
        option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    //Cors kullanmasaydim clientla iletisim saglayamazdim
    options
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();//uygulama baþlatilir
