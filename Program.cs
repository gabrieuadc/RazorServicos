using Microsoft.EntityFrameworkCore;
using razorApp.data;
using razorApp.repositories;
using razorApp.repositories.interfaces;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();


var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("https://localhost:7003")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                      });
});

builder.Services.AddHttpClient();

// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ServiceDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();

// builder.Services.AddRazorPages().AddRazorPagesOptions(o =>
// {
//     o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
// });

// app.MapGet("/", () => "Hello World!");
// app.MapControllers();
// app.UseEndpoints(endpoints =>
// {
//         endpoints.MapControllerRoute(
//         name: "cadService",
//         pattern: "{controller=ServiceController}/{action=cadService}/{id?}");
        
//         endpoints.MapControllerRoute(
//         name: "cadServiceAdd",
//         pattern: "ServiceController/cadServiceAdd",
//         defaults: new { controller = "ServiceController", action = "cadServiceAdd" }
//         );

//     endpoints.MapControllerRoute(
//         name: "default",
//         pattern: "{controller=ServiceController}/{action=Index}/{id?}");


// });