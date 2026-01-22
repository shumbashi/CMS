using Application.DTOs.RolePermissionDTO;
using Application.Features.RolePermissions.Command;
using Application.Features.RolePermissions.Queries;
using MediatR;

namespace Api.API_s
{
	public static class RolePermissionEndpoints
	{
		public static void MapRolePermissionEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/rolepermissions", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllRolePermissionsQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/rolepermissions/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetRolePermissionByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/rolepermissions", async (CreateRolePermissionDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateRolePermissionCommand { CreateRolePermissionDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/rolepermissions/{id}", async (Guid id, UpdateRolePermissionDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateRolePermissionCommand { UpdateRolePermissionDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/rolepermissions/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteRolePermissionCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
