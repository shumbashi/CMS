using Application.DTOs.PersonsInCompanyDTO;
using Application.Features.PersonsInCompanies.Command;
using Application.Features.PersonsInCompanies.Queries;
using MediatR;

namespace Api.API_s
{
	public static class PersonsInCompanyEndpoints
	{
		public static void MapPersonsInCompanyEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/personsincompany", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllPersonsInCompanyQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/personsincompany/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetPersonsInCompanyByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/personsincompany", async (CreatePersonsInCompanyDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreatePersonsInCompanyCommand { CreatePersonsInCompanyDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/personsincompany/{id}", async (Guid id, UpdatePersonsInCompanyDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdatePersonsInCompanyCommand { UpdatePersonsInCompanyDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/personsincompany/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeletePersonsInCompanyCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
