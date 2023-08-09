

using CaseBasedSchedule.Domain.Interfaces;

namespace CaseBasedSchedule.Domain.Fcatories
{
    public interface IPractitionerFactory
    {
        IPractitioner CreatePractitioner(string displayName, string discipline);
       
    }
}
