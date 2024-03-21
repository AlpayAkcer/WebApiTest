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
    _.Password.RequiredLength = 5; //En az ka� karakterli olmas� gerekti�ini belirtiyoruz.
    _.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunlulu�unu kald�r�yoruz.
    _.Password.RequireLowercase = false; //K���k harf zorunlulu�unu kald�r�yoruz.
    _.Password.RequireUppercase = false; //B�y�k harf zorunlulu�unu kald�r�yoruz.
    _.Password.RequireDigit = false; //0-9 aras� say�sal karakter zorunlulu�unu kald�r�yoruz.

    _.User.RequireUniqueEmail = true; //Email adreslerini tekille�tiriyoruz.
    _.User.AllowedUserNameCharacters = "abc�defghi�jklmno�pqrs�tu�vwxyzABC�DEFGHI�JKLMNO�PQRS�TU�VWXYZ0123456789-._@+";
    //Kullan�c� ad�nda ge�erli olan karakterleri belirtiyoruz.
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
