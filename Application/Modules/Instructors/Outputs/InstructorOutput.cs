namespace Application.Modules.Instructors.Outputs;

public record InstructorOutput
(
    Guid Id,
    string FirstName,
    string LastName,
    string Title,
    string? Description
);
