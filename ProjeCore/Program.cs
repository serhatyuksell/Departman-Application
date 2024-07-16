using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(x =>
	{
		x.LoginPath = "/Login/GirisYap/";
	});
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Login}/{action=GirisYap}/{id?}");

app.Run();
