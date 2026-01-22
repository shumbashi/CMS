using Application.DTOs.PermissionDTO;
using Application.Features.Permissions.Command;
using Application.Features.Permissions.Queries;
using MediatR;

namespace Api.API_s
{
	public static class PermissionEndpoints
	{
		public static void MapPermissionEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/permissions", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllPermissionsQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/permissions/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetPermissionByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/permissions", async (CreatePermissionDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreatePermissionCommand { CreatePermissionDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/permissions/{id}", async (Guid id, UpdatePermissionDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdatePermissionCommand { UpdatePermissionDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/permissions/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeletePermissionCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
