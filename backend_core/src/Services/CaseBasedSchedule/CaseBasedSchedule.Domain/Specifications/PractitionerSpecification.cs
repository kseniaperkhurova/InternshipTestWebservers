using CaseBasedSchedule.Domain.Entities;
using CaseBasedSchedule.Domain.Enums;
using CaseBasedSchedule.Domain.ValueObjects;
using System.Linq.Expressions;


namespace CaseBasedSchedule.Domain.Specifications
{


    public class PractitionerSpecification : Specification<Practitioner>
    {
        private readonly Discipline _discipline;
        public PractitionerSpecification(Discipline discipline)
        {
            _discipline = discipline;
        }
        public override Expression<Func<Practitioner, bool>> ToExpression()
        {
            return practitioner => practitioner.Discipline == _discipline;
        }
    }
}
