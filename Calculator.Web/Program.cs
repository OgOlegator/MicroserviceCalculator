using Calculator.Web;
using Calculator.Web.Services;
using Calculator.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IPlusService, PlusService>();
SD.PlusAPIBase = builder.Configuration["ServiceUrls:PlusAPI"];
builder.Services.AddScoped<IPlusService, PlusService>();

builder.Services.AddHttpClient<IMinusService, MinusService>();
SD.MinusAPIBase = builder.Configuration["ServiceUrls:MinusAPI"];
builder.Services.AddScoped<IMinusService, MinusService>();

builder.Services.AddHttpClient<IMultiplyService, MultiplyService>();
SD.MultiplyAPIBase = builder.Configuration["ServiceUrls:MultiplyAPI"];
builder.Services.AddScoped<IMultiplyService, MultiplyService>();

builder.Services.AddHttpClient<IDivideService, DivideService>();
SD.DivideAPIBase = builder.Configuration["ServiceUrls:DivideAPI"];
builder.Services.AddScoped<IDivideService, DivideService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calculator}/{action=CalculatorIndex}");

app.Run();
