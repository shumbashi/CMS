using Application.DTOs.EditorDTO;
using Application.Features.Editors.Command;
using Application.Features.Editors.Queries;
using MediatR;

namespace Api.API_s
{
	public static class EditorEndpoints
	{
		public static void MapEditorEndpoints(this IEndpointRouteBuilder app)
		{
			// GET: api/editors
			app.MapGet("/editors", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllEditorsQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			// GET: api/editors/{id}
			app.MapGet("/editors/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetEditorByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			// POST: api/editors
			app.MapPost("/editors", async (CreateEditorDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateEditorCommand { CreateEditorDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			// PUT: api/editors/{id}
			app.MapPut("/editors/{id}", async (Guid id, UpdateEditorDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateEditorCommand { UpdateEditorDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			// DELETE: api/editors/{id}
			app.MapDelete("/editors/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteEditorCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}
}
