namespace Application.Modules.Instructors.Inputs;

public record UpdateInstructorInput
(
    Guid Id,
    string FirstName,
    string LastName,
    string Title,
    string? Description
);
