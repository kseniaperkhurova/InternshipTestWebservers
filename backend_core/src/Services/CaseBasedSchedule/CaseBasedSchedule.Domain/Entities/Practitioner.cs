
using CaseBasedSchedule.Domain.Fcatories;
using CaseBasedSchedule.Domain.Interfaces;
using CaseBasedSchedule.Domain.ValueObjects;

namespace CaseBasedSchedule.Domain.Entities
{
   
    public class Practitioner :Entity<Guid>, IPractitioner
    {
        internal Practitioner() { }
        public string DisplayName { get; set; } = string.Empty;
       
        public Discipline Discipline { get;  set; }
        public IEnumerable<AgendaItem>? Appointments { get; set; }

        public class PractitionerFactory : IPractitionerFactory
        {
            public IPractitioner CreatePractitioner(string displayName, string discipline)
            {
                if(string.IsNullOrEmpty(displayName)) throw new ArgumentNullException(nameof(displayName));
                if (string.IsNullOrEmpty(discipline)) throw new ArgumentNullException(nameof(discipline));
                var aPractitioner = new Practitioner
                {
                    DisplayName = displayName,
                    Discipline = new Discipline(discipline)
                };
                return (IPractitioner)aPractitioner;
            }

            
        }

    }
}
