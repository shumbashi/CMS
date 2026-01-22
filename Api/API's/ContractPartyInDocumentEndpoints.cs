using Application.DTOs.ContractPartyInDocumentDTO;
using Application.Features.ContractPartyInDocuments.Command;
using Application.Features.ContractPartyInDocuments.Queries;
using MediatR;

namespace Api.API_s
{
	public static class ContractPartyInDocumentEndpoints
	{
		public static void MapContractPartyInDocumentEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/contractpartyindocuments", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllContractPartyInDocumentsQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/contractpartyindocuments/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetContractPartyInDocumentByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/contractpartyindocuments", async (CreateContractPartyInDocumentDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateContractPartyInDocumentCommand { CreateContractPartyInDocumentDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/contractpartyindocuments/{id}", async (Guid id, UpdateContractPartyInDocumentDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateContractPartyInDocumentCommand { UpdateContractPartyInDocumentDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/contractpartyindocuments/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteContractPartyInDocumentCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
