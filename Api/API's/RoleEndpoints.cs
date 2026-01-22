using Application.DTOs.RoleDTO;
using Application.Features.Role.Command;
using Application.Features.Role.Queries;
using MediatR;

namespace Api.API_s
{
	public static class RoleEndpoints
	{
		public static void MapRoleEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/roles", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllRolesQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/roles/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetRoleByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/roles", async (CreateRoleDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateRoleCommand { CreateRoleDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/roles/{id}", async (Guid id, UpdateRoleDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateRoleCommand { UpdateRoleDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/roles/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteRoleCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
