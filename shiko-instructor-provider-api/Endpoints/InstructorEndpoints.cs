using Application.Modules.Instructors;
using Application.Modules.Instructors.Inputs;
using shiko_instructor_provider_api.Dtos;
using shiko_instructor_provider_api.Mappings;

namespace shiko_instructor_provider_api.Endpoints;

public static class InstructorEndpoints
{
    public static IEndpointRouteBuilder MapInstructorEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/instructors");

        group.MapPost("/", Create);
        group.MapGet("/", GetAll);
        group.MapGet("/{id:guid}", GetById);
        group.MapPut("/{id:guid}", Update);
        group.MapDelete("/{id:guid}", Delete);

        return app;
    }

    private static IResult Create(CreateInstructorRequest request, IInstructorService service)
    {
        var input = new CreateInstructorInput(request.FirstName, request.LastName, request.Title, request.Description);

        var instructor = service.Create(input);
        var dto = instructor.ToDto();

        return Results.Created($"/api/instructors/{dto.Id}", dto);
    }

    private static IResult GetAll(IInstructorService service)
    {
        return Results.Ok(service.GetAll().Select(x => x.ToDto()));
    }

    private static IResult GetById(Guid id, IInstructorService service)
    {
        var instructor = service.GetById(id);
        return instructor is null ? Results.NotFound() : Results.Ok(instructor.ToDto());
    }

    private static IResult Update(Guid id, UpdateInstructorRequest request, IInstructorService service)
    {
        var input = new UpdateInstructorInput(id, request.FirstName, request.LastName, request.Title, request.Description);

        var instructor = service.Update(input);

        return instructor is null ? Results.NotFound() : Results.Ok(instructor.ToDto);
    }

    private static IResult Delete(Guid id, IInstructorService service)
    {
        var deleted = service.Delete(id);
        return deleted ? Results.NoContent() : Results.NotFound();
    }   
}
