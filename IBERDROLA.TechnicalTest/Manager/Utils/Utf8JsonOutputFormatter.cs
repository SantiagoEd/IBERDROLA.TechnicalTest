using Utf8Json;
using Microsoft.AspNetCore.Mvc.Formatters;


namespace IBERDROLA.TechnicalTest.Manager.Utils
{
    /// <summary>
    /// Utf8Json Output Formatter
    /// </summary>
    internal sealed class Utf8JsonOutputFormatter : IOutputFormatter
    {
        private readonly IJsonFormatterResolver _resolver;

        public Utf8JsonOutputFormatter() : this(JsonSerializer.DefaultResolver) { }
        public Utf8JsonOutputFormatter(IJsonFormatterResolver resolver)
        {
            _resolver = resolver ?? JsonSerializer.DefaultResolver;
        }

        public bool CanWriteResult(OutputFormatterCanWriteContext context) => true;


        public async Task WriteAsync(OutputFormatterWriteContext context)
        {
            //if (!context.ContentTypeIsServerDefined)
                context.HttpContext.Response.ContentType = "application/json";

            if (context.ObjectType == typeof(object))
            {
                await JsonSerializer.NonGeneric.SerializeAsync(context.HttpContext.Response.Body,
                    context.Object,
                    _resolver);
            }
            else
            {
                await JsonSerializer.NonGeneric.SerializeAsync(context.ObjectType,
                    context.HttpContext.Response.Body,
                    context.Object,
                    _resolver);
            }
        }
    }
}
