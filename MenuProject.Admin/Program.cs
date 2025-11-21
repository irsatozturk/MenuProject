using MenuProject.Admin.Components; // Veya sizde 'Routes' olabilir

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); 

builder.Services.AddHttpClient("MenuAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7239");
    

});

// Çeviri servisini Scoped (her kullanýcý için ayrý) olarak ekliyoruz
builder.Services.AddScoped<MenuProject.Admin.Services.ClientTranslationService>();
builder.Services.AddScoped<MenuProject.Admin.Services.ToastService>();
builder.Services.AddScoped<MenuProject.Admin.Services.NotifierService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();