using Project.BLL.ServiceInjections;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<AppUser>(x =>
{
x.Password.RequiredLength = 3;
x.Password.RequireDigit = false;
x.Password.RequireLowercase = false;
x.Password.RequireUppercase = false;
x.Password.RequireNonAlphanumeric = false;
x.Lockout.MaxFailedAccessAttempts = 5;
x.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<MyContext>();

builder.Services.ConfigureApplicationCookie(x =>
{
x.Cookie.HttpOnly = true;
x.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
x.Cookie.Name = "CyberSelf";
x.ExpireTimeSpan = TimeSpan.FromDays(1);
x.Cookie.SameSite = SameSiteMode.Strict;
x.LoginPath = new PathString("/Home/SignIn");
x.AccessDeniedPath = new PathString("/Home/AccessDenied");

});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(10);
    x.Cookie.HttpOnly = true; 
    x.Cookie.IsEssential = true;
});

builder.Services.AddIdentityServices();
builder.Services.AddDbContextService();
builder.Services.AddManagerServices();
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
