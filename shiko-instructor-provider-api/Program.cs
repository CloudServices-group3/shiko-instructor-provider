using Application.Modules.Instructors;
using shiko_instructor_provider_api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCors();

builder.Services.AddSingleton<IInstructorService, InstructorService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapInstructorEndpoints();

app.Run();

