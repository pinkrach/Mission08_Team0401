using Microsoft.EntityFrameworkCore;
using Mission08.Models;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// DbContext (SQLite)
builder.Services.AddDbContext<TasksContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TasksConnection"))
);

// Repository pattern DI
builder.Services.AddScoped<ITasksRepository, EFTasksRepository>();

var app = builder.Build();

// Seed DB (if your SeedData has this method)
SeedData.EnsurePopulated(app);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default route — send users straight to Quadrants
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Quadrants}/{id?}"
);

app.Run();