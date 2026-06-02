namespace shiko_instructor_provider_api.Dtos;

public record UpdateInstructorRequest
(
    //Guid CourseId,
    Guid Id,
    string FirstName,
    string LastName,
    string Title,
    string? Description
);