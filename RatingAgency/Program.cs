using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RatingAgency.dependencyInjection;
using RatingAgency.Validators.ControllerValidators;
using Repositories.DbContexts.GenericDbContext;
using Repositories.DbContexts.Initializer;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();




builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DbContextConnection"]);
});

builder.Services.AddRazorPages();
builder.Services.AddRazorComponents();
builder.Services.Configure<MvcOptions>(x => x.Conventions.Add(new ModelStateValidatorConvension()));

builder = DependencyInjector.Inject(builder);


var app = builder.Build();

// Adding seed data.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    

    var context = services.GetRequiredService<AppDbContext>();
    DBSeedProvider.Seed(context);
}

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();

}
app.UseStaticFiles();   
// app.UseSession();
app.MapRazorPages();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action}");
});



app.Run();
