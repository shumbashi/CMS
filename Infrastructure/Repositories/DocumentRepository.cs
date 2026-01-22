using Application.DTOs.DocumentDTO;
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
		public class DocumentRepository : Repository<Document>, IDocumentRepository
		{
			private readonly ServiceDbContext _serviceDbContext;

			public DocumentRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
			{
				_serviceDbContext = serviceDbContext;
			}

			public IQueryable<Document> AsQueryable()
			{
				return _dbContext.Set<Document>().AsQueryable();
			}

			// دالة للفلترة حسب معايير معينة
			public async Task<IQueryable<Document>> FilterDocumentsAsync(FilterDocumentDto filterDto)
			{
				var query = _dbContext.Set<Document>().AsQueryable();  // استعلام قابل للتعديل

				// الفلترة حسب TemplateName
				if (!string.IsNullOrEmpty(filterDto.TemplateName))
				{
					query = query.Where(d => d.Template.TemplateName.Contains(filterDto.TemplateName));
				}

				// الفلترة حسب DocumentStatus
				if (!string.IsNullOrEmpty(filterDto.DocumentStatus))
				{
					query = query.Where(d => d.DocumentStatus.Contains(filterDto.DocumentStatus));
				}

				// الفلترة حسب اسم المحرر (Editor)
				if (!string.IsNullOrEmpty(filterDto.EditorName))
				{
					query = query.Where(d => d.Editor.EditorName.Contains(filterDto.EditorName));
				}

				// الفلترة حسب رقم قيد التفتيش للمحرر
				if (!string.IsNullOrEmpty(filterDto.InspectionNumber))
				{
					query = query.Where(d => d.Editor.InspectionNumber.Contains(filterDto.InspectionNumber));
				}

				// الفلترة حسب رقم الختم الإلكتروني للمحرر
				if (!string.IsNullOrEmpty(filterDto.SealNumber))
				{
					query = query.Where(d => d.Editor.SealNumber.Contains(filterDto.SealNumber));
				}

				// الفلترة حسب قرار الرقم للمحرر
				if (!string.IsNullOrEmpty(filterDto.DecisionNumber))
				{
					query = query.Where(d => d.Editor.DecisionNumber.Contains(filterDto.DecisionNumber));
				}

				return query;
			}
		}
	}

}
