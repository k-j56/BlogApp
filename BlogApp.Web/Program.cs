using BlogApp.Web.Data;
using BlogApp.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();
builder.Services.AddControllers();

builder.Services.AddDbContext<BlogDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));

builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddIdentityCore<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<BlogDbContext>();

var app = builder.Build();


// using (var scope = app.Services.CreateScope())
// {
//     try
//     {
//         var services = scope.ServiceProvider;
//         var context = services.GetRequiredService<BlogDbContext>();
//         context.Database.Migrate();
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"Migration failed: {ex.Message}");
//     }
// }

app.UseRouting();
// app.UseEndpoints(endpoints => endpoints.MapControllers());
app.MapControllers();
app.Run();
