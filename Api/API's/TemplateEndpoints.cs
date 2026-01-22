using Application.DTOs.TemplateDTO;
using Application.Features.Template.Command;
using Application.Features.Template.Queries;
using MediatR;

namespace Api.API_s
{
	public static class TemplateEndpoints
	{
		public static void MapTemplateEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/templates", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllTemplatesQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/templates/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetTemplateByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/templates", async (CreateTemplateDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateTemplateCommand { CreateTemplateDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/templates/{id}", async (Guid id, UpdateTemplateDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateTemplateCommand { UpdateTemplateDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/templates/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteTemplateCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
