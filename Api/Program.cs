using Api.API_s;
using Application.Features.User.Command;
using Application.Features.User.Queries;
using Application.Features.UserActivities.Command;
using Application.Features.UserActivities.Queries;
using Application.Interfaces;
using Application.Interfaces.Common;
using Application.Interfaces.Repository;
using Application.Mapping;
using AutoMapper;
using FluentValidation;
using Infrastructure.ORM;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Common;
using Infrastructure.Repositories.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Reflection;

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

// --------------------------- Infrastructure DI ---------------------------
builder.Services.AddInfrastructure(); // يضيف كل الـRepositories + UnitOfWork + PasswordHasher
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();

// --------------------------- String Localizer ---------------------------
// هذا يحل مشكلة IStringLocalizer في كل Validators و Handlers
builder.Services.AddSingleton(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));

// --------------------------- MediatR ---------------------------
builder.Services.AddMediatR(cfg =>
	cfg.RegisterServicesFromAssembly(typeof(GetAllUsersQuery).Assembly));

// --------------------------- FluentValidation ---------------------------
// يغطي كل Validators في Assembly
builder.Services.AddValidatorsFromAssembly(typeof(BaseUserValidator).Assembly);

// --------------------------- AutoMapper ---------------------------
builder.Services.AddAutoMapper(cfg =>
{
	cfg.AddProfile<MappingProfile>();
});




// تسجيل إعدادات JWT بشكل قياسي في DI container

/*
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JWT"));
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IFileStorageService, FileStorageService>();*/

/*// تفعيل JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		// نقرأ الإعدادات من الـ configuration مباشرة وقت التشغيل

		var jwtOptions = builder.Configuration.GetSection("JWT").Get<JwtOptions>();

		options.SaveToken = true;
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidIssuer = jwtOptions.Issuer,
			ValidateAudience = true,
			ValidAudience = jwtOptions.Audience,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey))
		};
	});
*/
// --------------------------- Build App ---------------------------
ذvar app = builder.Build();
// تسجيل جميع الـ API Endpoints الخاصة بكل كائن
app.MapUserEndpoints();      // تسجيل Endpoints الخاصة بـ User
app.MapEditorEndpoints();    // تسجيل Endpoints الخاصة بـ Editor
app.MapRoleEndpoints();      // تسجيل Endpoints الخاصة بـ Role
app.MapPermissionEndpoints(); // تسجيل Endpoints الخاصة بـ Permission
app.MapUserActivityEndpoints(); // تسجيل Endpoints الخاصة بـ UserActivity
app.MapDocumentEndpoints();  // تسجيل Endpoints الخاصة بـ Document
app.MapContractPartyEndpoints(); // تسجيل Endpoints الخاصة بـ ContractParty
app.MapTemplateEndpoints();  // تسجيل Endpoints الخاصة بـ Template
app.MapAttachmentEndpoints(); // تسجيل Endpoints الخاصة بـ Attachment
app.MapAuditRecordEndpoints(); // تسجيل Endpoints الخاصة بـ AuditRecord
app.MapFinancialTransactionEndpoints(); // تسجيل Endpoints الخاصة بـ FinancialTransaction
app.MapNotificationEndpoints(); // تسجيل Endpoints الخاصة بـ Notification
app.MapContractPartyInDocumentEndpoints(); // تسجيل Endpoints الخاصة بـ ContractPartyInDocument
app.MapTemplateFieldEndpoints(); // تسجيل Endpoints الخاصة بـ TemplateField
app.MapIdentityEndpoints();  // تسجيل Endpoints الخاصة بـ Identity
app.MapCompanyEndpoints();   // تسجيل Endpoints الخاصة بـ Company
app.MapPartyRoleEndpoints(); // تسجيل Endpoints الخاصة بـ PartyRole
app.MapUserRoleEndpoints();  // تسجيل Endpoints الخاصة بـ UserRole
app.MapRolePermissionEndpoints(); // تسجيل Endpoints الخاصة بـ RolePermission
app.MapPersonsInCompanyEndpoints(); // تسجيل Endpoints الخاصة بـ PersonsInCompany

// --------------------------- Localization Configuration ---------------------------
app.UseRequestLocalization(options =>
{
	var supportedCultures = new[] { "en", "ar" };
	options.SetDefaultCulture("en")
		   .AddSupportedCultures(supportedCultures)
		   .AddSupportedUICultures(supportedCultures);
});

// --------------------------- Pipeline Configuration ---------------------------
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
