using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
namespace RoutePlanningService.Filters
{
    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                // Clear the default enum representation
                schema.Enum.Clear();

                // Modify the enum names as necessary
                var enumNames = Enum.GetNames(context.Type)
                    .Select(name => new OpenApiString(name))
                    .ToList();

                foreach (var enumName in enumNames)
                {
                    schema.Enum.Add(enumName);
                }

            }
        }
    }
}