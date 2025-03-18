using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.Services.UserServices;
using OnlineEdu.WebUI.Validators;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddHttpClient();
builder.Services.AddDbContext<OnlineEduContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<OnlineEduContext>().AddErrorDescriber<CustomErrorDescriber>();
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



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
