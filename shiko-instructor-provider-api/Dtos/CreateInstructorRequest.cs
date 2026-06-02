namespace shiko_instructor_provider_api.Dtos;

public record CreateInstructorRequest
(
    //Guid CourseId,
    string FirstName,
    string LastName,
    string Title,
    string? Description
);
