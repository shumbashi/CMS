using Application.DTOs.AttachmentDTO;
using Application.Features.Attachments.Command;
using Application.Features.Attachments.Queries;
using MediatR;

namespace Api.API_s
{
	public static class AttachmentEndpoints
	{
		public static void MapAttachmentEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/attachments", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllAttachmentsQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/attachments/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAttachmentByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/attachments", async (CreateAttachmentDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateAttachmentCommand { CreateAttachmentDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/attachments/{id}", async (Guid id, UpdateAttachmentDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateAttachmentCommand { UpdateAttachmentDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/attachments/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteAttachmentCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
