using Application.Modules.Instructors;
using Application.Modules.Instructors.Inputs;
using Microsoft.AspNetCore.Mvc;
using shiko_instructor_provider_api.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCors();

builder.Services.AddSingleton<IInstructorService, InstructorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// CREATE
app.MapPost("/api/instructors", (CreateInstructorRequest request, IInstructorService service) =>
{
    var instructorInput = new CreateInstructorInput(request.FirstName, request.LastName, request.Title, request.Description);
    var instructor = service.Create(instructorInput);

    return Results.Created($"/api/instructors/{instructor.Id}", instructor);
});

// GET ALL
app.MapGet("/api/instructors", (IInstructorService service) =>
{
    var instructors = service.GetAll();
    return Results.Ok(instructors);
});

// GET BY ID
app.MapGet("/api/instructors/{id:guid}", (Guid id, IInstructorService service) =>
{
    var instructor = service.GetById(id);
    return instructor is null ? Results.NotFound() : Results.Ok(instructor);
});

// UPDATE
app.MapPut("/api/instructors/{id:guid}", (Guid id, [FromBody] UpdateInstructorRequest request, IInstructorService service) =>
{
    var instructorInput = new UpdateInstructorInput(request.Id, request.FirstName, request.LastName, request.Title, request.Description);
    var instructor = service.Update(instructorInput);
    
    return Results.Ok(instructor);
});

// DELETE
app.MapDelete("/api/instructors/{id:guid}", (Guid id, IInstructorService service) =>
{
    var result = service.Delete(id);
    return result ? Results.NoContent() : Results.BadRequest();
});

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.Run();

