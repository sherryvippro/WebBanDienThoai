using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebBanDienThoai.Models;
using WebBanDienThoai.Services;

var builder = WebApplication.CreateBuilder(args);
/*builder.Services.AddDbContext<QLBanDTContext>(options => options.UseSqlServer
                        (builder.Configuration.GetConnectionString("DefaultConnection")));*/
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<QLBanDTContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddTransient<ProductServices>();
builder.Services.AddTransient<ImageServices>();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(30);
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
  
}

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
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
