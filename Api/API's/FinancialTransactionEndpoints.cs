using Application.DTOs.FinancialTransactionDTO;
using Application.Features.FinancialTransactions.Command;
using Application.Features.FinancialTransactions.Queries;
using MediatR;

namespace Api.API_s
{
	public static class FinancialTransactionEndpoints
	{
		public static void MapFinancialTransactionEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/financialtransactions", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllFinancialTransactionsQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/financialtransactions/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetFinancialTransactionByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/financialtransactions", async (CreateFinancialTransactionDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateFinancialTransactionCommand { CreateFinancialTransactionDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/financialtransactions/{id}", async (Guid id, UpdateFinancialTransactionDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateFinancialTransactionCommand { UpdateFinancialTransactionDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/financialtransactions/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteFinancialTransactionCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
