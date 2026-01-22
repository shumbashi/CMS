using Application.DTOs.UserRoleDTO;
using Application.Features.UserRole.Command;
using Application.Features.UserRole.Queries;
using MediatR;

namespace Api.API_s
{
	public static class UserRoleEndpoints
	{
		public static void MapUserRoleEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/userroles", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllUserRolesQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/userroles/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetUserRoleByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/userroles", async (CreateUserRoleDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateUserRoleCommand { CreateUserRoleDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/userroles/{id}", async (Guid id, UpdateUserRoleDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateUserRoleCommand { UpdateUserRoleDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/userroles/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteUserRoleCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
