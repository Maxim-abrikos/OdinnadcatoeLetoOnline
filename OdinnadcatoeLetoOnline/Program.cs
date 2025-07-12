var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

//app.UseAuthorization();

//app.MapStaticAssets();

app.MapRazorPages();

app.MapRazorPages().WithStaticAssets();

app.Run();
