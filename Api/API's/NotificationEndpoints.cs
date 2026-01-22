using Application.DTOs.NotificationDTO;
using Application.Features.Notifications.Command;
using Application.Features.Notifications.Queries;
using MediatR;

namespace Api.API_s
{
	public static class NotificationEndpoints
	{
		public static void MapNotificationEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/notifications", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllNotificationsQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/notifications/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetNotificationByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/notifications", async (CreateNotificationDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateNotificationCommand { CreateNotificationDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/notifications/{id}", async (Guid id, UpdateNotificationDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateNotificationCommand { UpdateNotificationDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/notifications/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteNotificationCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
