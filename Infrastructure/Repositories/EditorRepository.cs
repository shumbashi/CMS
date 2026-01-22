using Application.DTOs.EditorDTO;
using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.ORM;
using Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
	namespace Infrastructure.Repositories
	{
		public class EditorRepository : Repository<Editor>, IEditorRepository
		{
			private readonly ServiceDbContext _serviceDbContext;

			public EditorRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
			{
				_serviceDbContext = serviceDbContext;
			}

			public IQueryable<Editor> AsQueryable()
			{
				return _dbContext.Set<Editor>().AsQueryable();
			}
			public async Task<IQueryable<Editor>> FilterEditorsAsync(FilterEditorDto filterDto)
			{
				var query = _dbContext.Set<Editor>().AsQueryable();  // استعلام قابل للتعديل

				// الفلترة حسب اسم المحرر
				if (!string.IsNullOrEmpty(filterDto.EditorName))
				{
					query = query.Where(e => e.EditorName.Contains(filterDto.EditorName));
				}

				// الفلترة حسب رقم قيد التفتيش
				if (!string.IsNullOrEmpty(filterDto.InspectionNumber))
				{
					query = query.Where(e => e.InspectionNumber.Contains(filterDto.InspectionNumber));
				}

				// الفلترة حسب رقم الختم الإلكتروني
				if (!string.IsNullOrEmpty(filterDto.SealNumber))
				{
					query = query.Where(e => e.SealNumber.Contains(filterDto.SealNumber));
				}

				// الفلترة حسب قرار الرقم
				if (!string.IsNullOrEmpty(filterDto.DecisionNumber))
				{
					query = query.Where(e => e.DecisionNumber.Contains(filterDto.DecisionNumber));
				}

				return query;
			}
		}
	}

}
