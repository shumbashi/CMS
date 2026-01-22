using Application.DTOs.UserDTO;
using Application.Features.User.Command;
using Application.Features.User.Queries;
using MediatR;

namespace Api.API_s
{
	public static class UserEndpoints
	{
		public static void MapUserEndpoints(this IEndpointRouteBuilder app)
		{
			// GET: api/users
			app.MapGet("/users", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllUsersQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			// GET: api/users/{id}
			app.MapGet("/users/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetUserByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			// POST: api/users
			app.MapPost("/users", async (CreateUserDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateUserCommand { CreateUserDto = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			// PUT: api/users/{id}
			app.MapPut("/users/{id}", async (Guid id, UpdateUserDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateUserCommand { UpdateUserDto = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			// DELETE: api/users/{id}
			app.MapDelete("/users/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteUserCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}
}
