using MenuProject.API.Data;
using Microsoft.EntityFrameworkCore;
using MenuProject.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IMenuService, MenuService>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();  //builder.Services.AddOpenApi();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Bu, /swagger/index.html adresini oluþturur
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
