using Application.DTOs.AuditRecordDTO;
using Application.Features.AuditRecords.Command;
using Application.Features.AuditRecords.Queries;
using MediatR;

namespace Api.API_s
{
	public static class AuditRecordEndpoints
	{
		public static void MapAuditRecordEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/auditrecords", async (IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAllAuditRecordsQuery());
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapGet("/auditrecords/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new GetAuditRecordByIdQuery { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});

			app.MapPost("/auditrecords", async (CreateAuditRecordDto dto, IMediator mediator) =>
			{
				var result = await mediator.Send(new CreateAuditRecordCommand { CreateAuditRecordDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapPut("/auditrecords/{id}", async (Guid id, UpdateAuditRecordDto dto, IMediator mediator) =>
			{
				dto.Id = id;
				var result = await mediator.Send(new UpdateAuditRecordCommand { UpdateAuditRecordDTO = dto });
				return result.Success ? Results.Ok(result) : Results.BadRequest(result);
			});

			app.MapDelete("/auditrecords/{id}", async (Guid id, IMediator mediator) =>
			{
				var result = await mediator.Send(new DeleteAuditRecordCommand { Id = id });
				return result.Success ? Results.Ok(result) : Results.NotFound(result);
			});
		}
	}

}
