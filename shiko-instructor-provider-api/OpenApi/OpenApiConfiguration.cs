using Microsoft.OpenApi;

namespace shiko_instructor_provider_api.OpenApi;

public static class OpenApiConfiguration
{
    public static IServiceCollection AddInstructorProviderOpenApi (this IServiceCollection services)
    {
        services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer<OpenApiDocumentTransformer>();
        });
        return services;
    }
}
