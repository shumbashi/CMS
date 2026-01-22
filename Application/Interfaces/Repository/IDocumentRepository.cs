using Application.DTOs.DocumentDTO;
using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	
		public interface IDocumentRepository : IRepository<Document>
		{
		IQueryable<Document> AsQueryable();
		Task<IQueryable<Document>> FilterDocumentsAsync(FilterDocumentDto filterDto);
		}
	

}
