using Project.BLL.ServiceInjections;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddIdentityServices();
builder.Services.AddDbContextService();
;builder.Services.AddManagerServices();
builder.Services.AddRepServices();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Manager",
    pattern: "{area}/{controller=Home}/{action=Register}/{id?}"
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=ListOrders}/{id?}");

app.Run();
