using Application.Modules.Instructors.Inputs;
using Application.Modules.Instructors.Outputs;

namespace Application.Modules.Instructors;

public class InstructorService : IInstructorService
{
    private List<InstructorOutput> _instructors = [];

    public InstructorOutput Create(CreateInstructorInput input)
    {
        var instructor = new InstructorOutput(Guid.NewGuid(), input.FirstName, input.LastName, input.Title, input.Description);
        _instructors.Add(instructor);

        return instructor;
    }

    public IEnumerable<InstructorOutput> GetAll()
    {
        return _instructors;
    }

    public InstructorOutput? GetById(Guid id)
    {
        return _instructors.FirstOrDefault(i => i.Id == id);
    }

    public InstructorOutput? Update(UpdateInstructorInput input)
    {
        var index = _instructors.FindIndex(i => i.Id == input.Id);
        if (index == -1)
        {
            return null;
        }

        var existing = _instructors[index];

        var updated = existing with
        {
            FirstName = input.FirstName,
            LastName = input.LastName,
            Title = input.Title,
            Description = input.Description
        };

        _instructors[index] = updated;
        return updated;
    }

    public bool Delete(Guid id)
    {
        var index = _instructors.FindIndex(i => i.Id == id);
        if (index == -1)
        {
            return false;
        }
        _instructors.RemoveAt(index);
        return true;
    }

}
