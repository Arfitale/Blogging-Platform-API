using App.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("NeonConnection"));
    options.UseSnakeCaseNamingConvention();
});

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.Run("http://localhost:5000");
}
else
{
    app.UseHttpsRedirection();
    builder.WebHost.UseUrls("http://0.0.0.0:5000");
    app.Run("http://0.0.0.0:5000");
}
