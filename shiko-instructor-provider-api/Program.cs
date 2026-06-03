using Application.Modules.Instructors;
using Application.Modules.Instructors.Inputs;
using Application.Modules.Instructors.Outputs;
using shiko_instructor_provider_api.Dtos;

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

// CREATE
app.MapPost("/api/instructors", (CreateInstructorRequest request, IInstructorService service) =>
{
    var input = new CreateInstructorInput(request.FirstName, request.LastName, request.Title, request.Description);
    
    var instructor = service.Create(input);
    var dto = ToDto(instructor);

    return Results.Created($"/api/instructors/{dto.Id}", dto);
});

// GET ALL
app.MapGet("/api/instructors", (IInstructorService service) =>
{
    var instructors = service.GetAll()
        .Select(ToDto);
    
    return Results.Ok(instructors);
});

// GET BY ID
app.MapGet("/api/instructors/{id:guid}", (Guid id, IInstructorService service) =>
{
    var instructor = service.GetById(id);
    return instructor is null ? Results.NotFound() : Results.Ok(ToDto(instructor));
});

// UPDATE
app.MapPut("/api/instructors/{id:guid}", (Guid id, UpdateInstructorRequest request, IInstructorService service) =>
{
    var input = new UpdateInstructorInput(id, request.FirstName, request.LastName, request.Title, request.Description);
    var instructor = service.Update(input);
    
    return instructor is null ? Results.NotFound() : Results.Ok(ToDto(instructor));
});

// DELETE
app.MapDelete("/api/instructors/{id:guid}", (Guid id, IInstructorService service) =>
{
    var result = service.Delete(id);
    return result ? Results.NoContent() : Results.NotFound();
});

static InstructorDto ToDto(InstructorOutput instructor)
{
    return new InstructorDto(
        instructor.Id,
        instructor.FirstName,
        instructor.LastName,
        instructor.Title,
        instructor.Description
        );
}

app.Run();

