using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RatingAgency.dependencyInjection;
using RatingAgency.Validators.ControllerValidators;
using Data.DbContexts.AppDbContext;
using Data.DataBase.Initializer;
using Data.DataBase.Identity;
using Microsoft.AspNetCore.Identity;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection");

if (connectionString is null) {
    throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");
};

builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DbContextConnection"]);
});

builder.Services.AddDefaultIdentity<CustomIdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;

    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.User.RequireUniqueEmail = true;


    })
    .AddRoles<CustomIdentityRole>()
    .AddRoleValidator<CustomRoleValidator>()
    .AddRoleManager<CustomRoleManager>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSession();

builder.Services.AddRazorPages();

builder.Services.AddRazorComponents();

builder.Services.Configure<MvcOptions>(x => x.Conventions.Add(new ModelStateValidatorConvension()));

builder = DependencyInjector.Inject(builder);


var app = builder.Build();

// Through this scope, we can access the services that were inserted into the builder prior to
// the application being effectively run

var dbServiceProvider = new DBSeedProvider(app);

await dbServiceProvider.Seed();


if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();

}
/*This middleware allows the solution to automatically include the static files like the bootstrap and css files.*/
app.UseStaticFiles();
// app.MapDefaultControllerRoute();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.UseHttpsRedirection();

app.UseRouting();


app.UseAuthentication();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();

    endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action}");
});



app.Run();
