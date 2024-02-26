using Microsoft.EntityFrameworkCore;
using SMS.webapp;
using SMS.webapp.DatabaseContext;
using SMS.webapp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

builder.Services.AddAutoMapper(typeof(ICore).Assembly);

builder.Services.Scan(x=>x.FromAssemblyOf<ICore>()
.AddClasses(x=>x.AssignableTo<ICore>())
.AddClasses(x => x.AssignableTo(typeof(IRepositoryService<,>)))
.AsSelfWithInterfaces()
.WithScopedLifetime());

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
