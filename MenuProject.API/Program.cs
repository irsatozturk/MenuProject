using MenuProject.API.Data;
using Microsoft.EntityFrameworkCore;
using MenuProject.API.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IMenuService, MenuService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // sonsuz donguleri (Menu -> Category -> Menu...) görmezden gelmesi icin eklendi
    });

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Bu, url/swagger/index.html adresini olusturur
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
