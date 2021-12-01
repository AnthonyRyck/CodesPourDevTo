using TutoDynamicComponent.Data;

var builder = WebApplication.CreateBuilder(args);

// Ajout des services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<IDynamicCompoViewModel, DynamicCompoViewModel>();
builder.Services.AddScoped<ITestViewModel, TestViewModel>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
