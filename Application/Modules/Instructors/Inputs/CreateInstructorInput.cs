namespace Application.Modules.Instructors.Inputs;

public record CreateInstructorInput
(
    string FirstName,
    string LastName,
    string Title,
    string? Description
);
