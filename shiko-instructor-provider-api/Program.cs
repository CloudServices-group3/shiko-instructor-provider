using Application.Modules.Instructors;
using shiko_instructor_provider_api.Endpoints;
using shiko_instructor_provider_api.Security;
using shiko_instructor_provider_api.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCorsConfiguration();

builder.Services.AddSingleton<IInstructorService, InstructorService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("All");
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapOpenApiEndpoints();
app.MapInstructorEndpoints();

app.Run();

