namespace shiko_instructor_provider_api.Dtos;

public record InstructorDto
(
    Guid Id, 
    //Guid CourseId 
    string FirstName,
    string LastName,
    string Title,
    string? Description
);
