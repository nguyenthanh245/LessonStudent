var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

var app = builder.Build();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=HocSinh}/{action=Index}/{id?}"
    );

app.UseStaticFiles();

app.MapRazorPages();

app.Run();