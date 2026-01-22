using Application.DTOs.CompanyDTO;
using Application.Features.Company.Command;
using Application.Features.Company.Queries;
using MediatR;

namespace Api.API_s
{
	public static class CompanyEndpoints
	{
		public static void MapCompanyEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/companies", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllCompaniesQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/companies/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetCompanyByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/companies", async (CreateCompanyDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateCompanyCommand { CreateCompanyDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/companies/{id}", async (Guid id, UpdateCompanyDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateCompanyCommand { UpdateCompanyDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/companies/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteCompanyCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
