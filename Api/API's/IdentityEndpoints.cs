using Application.DTOs.IdentityDTO;
using Application.Features.Identity.Command;
using Application.Features.Identity.Queries;
using MediatR;

namespace Api.API_s
{
	public static class IdentityEndpoints
	{
		public static void MapIdentityEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/identities", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllIdentitiesQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/identities/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetIdentityByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/identities", async (CreateIdentityDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateIdentityCommand { CreateIdentityDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/identities/{id}", async (Guid id, UpdateIdentityDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateIdentityCommand { UpdateIdentityDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/identities/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteIdentityCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
