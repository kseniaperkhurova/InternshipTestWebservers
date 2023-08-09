

using CaseBasedSchedule.Domain.ValueObjects;

namespace CaseBasedSchedule.Domain.Interfaces
{
    public interface IPractitioner
    {
        public Guid Id { get; }
        public string DisplayName { get; }
        public Discipline Discipline { get; }

    }
}
