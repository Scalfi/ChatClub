using ChatClub.Web.Extensions;
using ChatClub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ChatClub.Domain.Mapper;
using ChatClub.Web.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddAutoMapper(typeof(AutoMapperSetup));
builder.Services.AddServiceInterfaces();
builder.Services.AddRepositoryInterfaces();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.ConfigureAuth(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.Migrate();
}

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

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHubMessage>("/chathub");

app.Run();
