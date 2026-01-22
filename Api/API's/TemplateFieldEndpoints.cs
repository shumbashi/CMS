using Application.DTOs.TemplateFieldDTO;
using Application.Features.TemplateField.Command;
using Application.Features.TemplateField.Queries;
using MediatR;

namespace Api.API_s
{
	public static class TemplateFieldEndpoints
	{
		public static void MapTemplateFieldEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/templatefields", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllTemplateFieldsQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/templatefields/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetTemplateFieldByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/templatefields", async (CreateTemplateFieldDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateTemplateFieldCommand { CreateTemplateFieldDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/templatefields/{id}", async (Guid id, UpdateTemplateFieldDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateTemplateFieldCommand { UpdateTemplateFieldDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/templatefields/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteTemplateFieldCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
