using IBERDROLA.TechnicalTest.Helpers.StartConfiguration;
using IBERDROLA.TechnicalTest.Manager.Utils;
using IBERDROLA.TechnicalTest.Persistence.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));

builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddMvc(option =>
{
    option.OutputFormatters.Clear();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInjectionServices(builder.Configuration);



if (!builder.Environment.IsProduction())
{
    builder.Configuration.AddUserSecrets<Program>();
}

var app = builder.Build();

// Add services to the container.
builder.Services.AddControllersWithViews();


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
