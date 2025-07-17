using Microsoft.EntityFrameworkCore;
using sic.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<SicDbContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("SicConnection");
    options.UseMySQL(cs);
});


//Creacion de la app
var app = builder.Build();

//Creacion de la base de datos
await using (var scope = app.Services.CreateAsyncScope())
await using (var dbContext = scope.ServiceProvider.GetRequiredService<SicDbContext>())
{
    
    await dbContext.Database.EnsureCreatedAsync();
}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Shared/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=LogIn}/{id?}")
    .WithStaticAssets();

app.Run();
