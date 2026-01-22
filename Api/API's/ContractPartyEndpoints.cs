using Application.DTOs.ContractPartyDTO;
using Application.Features.ContractParties.Command;
using Application.Features.ContractParties.Queries;
using MediatR;

namespace Api.API_s
{
	public static class ContractPartyEndpoints
	{
		public static void MapContractPartyEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/contractparties", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllContractPartiesQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/contractparties/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetContractPartyByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/contractparties", async (CreateContractPartyDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateContractPartyCommand { CreateContractPartyDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/contractparties/{id}", async (Guid id, UpdateContractPartyDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateContractPartyCommand { UpdateContractPartyDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/contractparties/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteContractPartyCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
