using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMVC.Data;
var builder = WebApplication.CreateBuilder(args);
string conn = @"Server=Silas-pc\SQLEXPRESS;Database=SalesWebMVC;Integrated Security=False;User Id=sa;Password=102030;TrustServerCertificate=True" ;
builder.Services.AddDbContext<SalesWebMVCContext>(options =>
    options.UseSqlServer((conn) ?? throw new InvalidOperationException("Connection string 'SalesWebMVCContext' not found.")));

// Add services to the container.
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
