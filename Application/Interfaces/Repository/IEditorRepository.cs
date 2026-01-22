using Application.DTOs.EditorDTO;
using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	public interface IEditorRepository : IRepository<Editor>
	{
		IQueryable<Editor> AsQueryable();
		Task<IQueryable<Editor>> FilterEditorsAsync(FilterEditorDto filterDto);

	}
}
