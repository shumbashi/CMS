using Api.API_s;
using Api.API_s.Common;
using Application.DTOs.UserActivityDTO;
using Application.DTOs.UserRoleDTO;
using Application.Features.ContractPartyInDocuments.Command;
using Application.Features.Template.Command;
using Application.Features.User.Command;
using Application.Features.User.Queries;
using Application.Features.UserActivities.Command;
using Application.Features.UserActivities.Queries;
using Application.Interfaces;
using Application.Interfaces.Common;
using Application.Interfaces.Helper;
using Application.Interfaces.Repository;
using Application.Mapping;
using AutoMapper;
using FluentValidation;
using Infrastructure.ORM;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Common;
using Infrastructure.Repositories.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// --------------------------- Controllers & Swagger ---------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();
// --------------------------- Localization ---------------------------
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// --------------------------- DbContext ---------------------------
builder.Services.AddDbContext<ServiceDbContext>(options =>
	options.UseMySql(builder.Configuration.GetConnectionString("CMS"),
		ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("CMS")))
);
// --------------------------- Infrastructure DI ---------------------------
builder.Services.AddInfrastructure(); // Adds all Repositories + UnitOfWork + PasswordHasher
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();

// --------------------------- String Localizer ---------------------------
builder.Services.AddSingleton(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));

// --------------------------- MediatR ---------------------------
builder.Services.AddMediatR(cfg =>
	cfg.RegisterServicesFromAssembly(typeof(GetAllUsersQuery).Assembly));

// --------------------------- FluentValidation ---------------------------
builder.Services.AddValidatorsFromAssembly(typeof(CreateUserValidator).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<UpdateContractPartyInDocumentValidator>();

// --------------------------- AutoMapper ---------------------------
builder.Services.AddAutoMapper(cfg =>
{
	cfg.AddProfile<MappingProfile>();
});

// --------------------------- Repositories ---------------------------
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEditorRepository, EditorRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IContractPartyRepository, ContractPartyRepository>();
builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();
builder.Services.AddScoped<IAttachmentRepository, AttachmentRepository>();
builder.Services.AddScoped<IAuditRecordRepository, AuditRecordRepository>();
builder.Services.AddScoped<IFinancialTransactionRepository, FinancialTransactionRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IContractPartyInDocumentRepository, ContractPartyInDocumentRepository>();
builder.Services.AddScoped<ITemplateFieldRepository, TemplateFieldRepository>();
builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IPartyRoleRepository, PartyRoleRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IUserActivityRepository, UserActivityRepository>();
builder.Services.AddScoped<IPersonsInCompanyRepository, PersonsInCompanyRepository>();

// --------------------------- Authentication Configuration ---------------------------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Auth:Authority"];
        options.Audience = builder.Configuration["Auth:Audience"];
        // configure token validation as needed
    });

// --------------------------- Build App ---------------------------
var app = builder.Build();

// --------------------------- API Endpoints ---------------------------
app.MapUserEndpoints(); // Register User Endpoints
app.MapEditorEndpoints(); // Register Editor Endpoints
app.MapRoleEndpoints(); // Register Role Endpoints
app.MapPermissionEndpoints(); // Register Permission Endpoints
app.MapUserActivityEndpoints(); // Register UserActivity Endpoints
app.MapDocumentEndpoints(); // Register Document Endpoints
app.MapContractPartyEndpoints(); // Register ContractParty Endpoints
app.MapTemplateEndpoints(); // Register Template Endpoints
app.MapAttachmentEndpoints(); // Register Attachment Endpoints
app.MapAuditRecordEndpoints(); // Register AuditRecord Endpoints
app.MapFinancialTransactionEndpoints(); // Register FinancialTransaction Endpoints
app.MapNotificationEndpoints(); // Register Notification Endpoints
app.MapContractPartyInDocumentEndpoints(); // Register ContractPartyInDocument Endpoints
app.MapTemplateFieldEndpoints(); // Register TemplateField Endpoints
app.MapIdentityEndpoints(); // Register Identity Endpoints
app.MapCompanyEndpoints(); // Register Company Endpoints
app.MapPartyRoleEndpoints(); // Register PartyRole Endpoints
app.MapUserRoleEndpoints(); // Register UserRole Endpoints
app.MapRolePermissionEndpoints(); // Register RolePermission Endpoints
app.MapPersonsInCompanyEndpoints(); // Register PersonsInCompany Endpoints

// --------------------------- Localization Configuration ---------------------------
app.UseRequestLocalization(options =>
{
	var supportedCultures = new[] { "en", "ar" };
	options.SetDefaultCulture("en")
		   .AddSupportedCultures(supportedCultures)
		   .AddSupportedUICultures(supportedCultures);
});

// --------------------------- Swagger UI ---------------------------
app.UseSwagger();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// --------------------------- Authentication/Authorization ---------------------------
app.UseAuthentication();


app.MapControllers();

app.Run();
