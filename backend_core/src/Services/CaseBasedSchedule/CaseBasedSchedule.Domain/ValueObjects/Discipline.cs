

using CaseBasedSchedule.Domain.Enums;
using CleanArchitecture.Core.Domain.ValueObjects;

namespace CaseBasedSchedule.Domain.ValueObjects
{
    public class Discipline : ValueObject
    {
        public Speciality Speciality { get; set; }
        public Department Department { get; set; }

        public Discipline(Speciality speciality, Department department)
        {
            Speciality = speciality;
            Department = department;

        }
        public Discipline(Speciality speciality)
        {
            Speciality = speciality;
        }
        public Discipline(string value)
        {
            if (value.Contains("(") && value.Contains(")"))
            {
                string valueReplace = value.Replace("(", "-").Replace(")", "-");
                string[] valueArray = valueReplace.Split("-");
                var speciality = EnumValueConverter.GetEnumValue<Speciality>(valueArray[0]);
                var department = EnumValueConverter.GetEnumValue<Department>(valueArray[1]);
                Speciality = speciality;
                Department = department;
            }
            else
            {
                var speciality = EnumValueConverter.GetEnumValue<Speciality>(value);
                Speciality = speciality;
                Department = Department.None;
            }
        }

        public override string ToString()
        {
            if (Department == Department.None)
            {
                   return Speciality.ToString();
            }
            else
            {
                return Speciality + "(" + Department + ")";
             
            }

        }
        public static implicit operator string?(Discipline discipline) {  return discipline.ToString();}
        public static implicit operator Discipline(string value) => new Discipline(value);
        
      
    }
}
