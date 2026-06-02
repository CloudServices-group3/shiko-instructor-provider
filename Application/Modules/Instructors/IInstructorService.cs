using Application.Modules.Instructors.Inputs;
using Application.Modules.Instructors.Outputs;

namespace Application.Modules.Instructors;

public interface IInstructorService
{
    InstructorOutput Create(CreateInstructorInput input);
    bool Delete(Guid id);
    InstructorOutput? GetById(Guid id);
    IEnumerable<InstructorOutput> GetAll();
    InstructorOutput? Update(UpdateInstructorInput input);
}