var builder = WebApplication.CreateBuilder(args);

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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=MeetingRoomHome}/{id?}")
    .WithStaticAssets();

    
app.MapControllerRoute(
    name: "calendar",
    pattern: "Home/BookMeetingRoom/{year}/{month}",
    defaults: new { controller = "Home", action = "BookMeetingRoom", year = 2025, month = 3 }
);

app.Run();
