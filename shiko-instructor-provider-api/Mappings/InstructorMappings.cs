using Application.Modules.Instructors.Outputs;
using shiko_instructor_provider_api.Dtos;

namespace shiko_instructor_provider_api.Mappings;

public static class InstructorMappings
{
    public static InstructorDto ToDto(this InstructorOutput instructor)
    {
        return new InstructorDto(
            instructor.Id,
            instructor.FirstName,
            instructor.LastName,
            instructor.Title,
            instructor.Description
        );
    }
}
