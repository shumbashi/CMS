using Application.DTOs.UserActivityDTO;
using Application.Features.UserActivities.Command;
using Application.Features.UserActivities.Queries;
using MediatR;

namespace Api.API_s
{
	public static class UserActivityEndpoints
	{
		public static void MapUserActivityEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/useractivities", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllUserActivitiesQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/useractivities/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetUserActivityByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/useractivities", async (CreateUserActivityDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateUserActivityCommand { CreateUserActivityDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/useractivities/{id}", async (Guid id, UpdateUserActivityDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateUserActivityCommand { UpdateUserActivityDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/useractivities/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteUserActivityCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}
}
