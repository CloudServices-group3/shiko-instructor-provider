using Scalar.AspNetCore;

namespace shiko_instructor_provider_api.OpenApi;

public static class OpenApiEndpointsExtensions
{
    public static WebApplication MapOpenApiEndpoints(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            return app;
        }

        app.MapOpenApi();
        app.MapScalarApiReference("/scalar", options =>
        {
            options.Title = "Instuctor API";
            options.Theme = ScalarTheme.BluePlanet;
            options.DefaultHttpClient = new(ScalarTarget.CSharp, ScalarClient.HttpClient);
        });
        app.MapGet("/", () => Results.Redirect("/scalar"));

        return app;
    }
}
