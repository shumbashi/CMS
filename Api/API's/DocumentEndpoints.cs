using Application.DTOs.DocumentDTO;
using Application.Features.Documents.Command;
using Application.Features.Documents.Queries;
using MediatR;

namespace Api.API_s
{
	public static class DocumentEndpoints
	{
		public static void MapDocumentEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/documents", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllDocumentsQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/documents/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetDocumentByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/documents", async (CreateDocumentDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateDocumentCommand { CreateDocumentDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/documents/{id}", async (Guid id, UpdateDocumentDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateDocumentCommand { UpdateDocumentDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/documents/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteDocumentCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
