using Infrastructure.ORM;
using Infrastructure.Repositories.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);
// --------------------------- Localization ---------------------------
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// --------------------------- DbContext ---------------------------
builder.Services.AddDbContext<ServiceDbContext>(options =>
	options.UseMySql(
		builder.Configuration.GetConnectionString("CMS"),
		ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("CMS"))
	)
);

builder.Services.AddScoped(typeof(IPasswordHasher<>), typeof(BCryptPasswordHasher<>));

// --------------------------- Infrastructure DI ---------------------------
builder.Services.AddInfrastructure(); // يضيف كل الـRepositories + UnitOfWork + PasswordHasher

// --------------------------- String Localizer ---------------------------
// هذا يحل مشكلة IStringLocalizer في كل Validators و Handlers
builder.Services.AddSingleton(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));

// --------------------------- MediatR ---------------------------


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseRequestLocalization(options =>
{
	var supportedCultures = new[] { "en", "ar" };
	options.SetDefaultCulture("en")
		   .AddSupportedCultures(supportedCultures)
		   .AddSupportedUICultures(supportedCultures);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
