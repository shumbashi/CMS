using Application.DTOs.PartyRoleDTO;
using Application.Features.PartyRole.Command;
using Application.Features.PartyRole.Queries;
using MediatR;

namespace Api.API_s
{
	public static class PartyRoleEndpoints
	{
		public static void MapPartyRoleEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/partyroles", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllPartyRolesQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/partyroles/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetPartyRoleByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/partyroles", async (CreatePartyRoleDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreatePartyRoleCommand { CreatePartyRoleDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/partyroles/{id}", async (Guid id, UpdatePartyRoleDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdatePartyRoleCommand { UpdatePartyRoleDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/partyroles/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeletePartyRoleCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
