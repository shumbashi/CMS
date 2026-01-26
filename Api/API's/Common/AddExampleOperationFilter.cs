using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.API_s.Common
{
	public class AddExampleOperationFilter : IOperationFilter
	{
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			if (operation.RequestBody != null && operation.RequestBody.Content.ContainsKey("application/json"))
			{
				// أضف المثال هنا
				operation.RequestBody.Content["application/json"].Example = new OpenApiObject
				{
					["name"] = new OpenApiString("John Doe"),
					["age"] = new OpenApiInteger(30)
				};
			}
		}
	}
}
