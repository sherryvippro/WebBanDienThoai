using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebBanDienThoai.Models;



var builder = WebApplication.CreateBuilder(args);
/*builder.Services.AddDbContext<QLBanDTContext>(options => options.UseSqlServer
                        (builder.Configuration.GetConnectionString("DefaultConnection")));*/
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<QLBanDTContext>(x => x.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
