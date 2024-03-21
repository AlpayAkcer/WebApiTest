using Microsoft.AspNetCore.Identity;
using System;
using WebApiTest.BusinessLayer.Abstract;
using WebApiTest.BusinessLayer.Concrete;
using WebApiTest.DataAccessLayer;
using WebApiTest.DataAccessLayer.Abstract;
using WebApiTest.DataAccessLayer.Concrete;
using WebApiTest.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HotelDbContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IHotelService, HotelService>();
builder.Services.AddSingleton<IHotelRepository, HotelRepository>();

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<HotelDbContext>();


builder.Services.AddIdentity<AppUser, AppRole>(_ =>
{
    _.Password.RequiredLength = 5; //En az kaç karakterli olmasý gerektiðini belirtiyoruz.
    _.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunluluðunu kaldýrýyoruz.
    _.Password.RequireLowercase = false; //Küçük harf zorunluluðunu kaldýrýyoruz.
    _.Password.RequireUppercase = false; //Büyük harf zorunluluðunu kaldýrýyoruz.
    _.Password.RequireDigit = false; //0-9 arasý sayýsal karakter zorunluluðunu kaldýrýyoruz.

    _.User.RequireUniqueEmail = true; //Email adreslerini tekilleþtiriyoruz.
    _.User.AllowedUserNameCharacters = "abcçdefghiýjklmnoöpqrsþtuüvwxyzABCÇDEFGHIÝJKLMNOÖPQRSÞTUÜVWXYZ0123456789-._@+";
    //Kullanýcý adýnda geçerli olan karakterleri belirtiyoruz.
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
