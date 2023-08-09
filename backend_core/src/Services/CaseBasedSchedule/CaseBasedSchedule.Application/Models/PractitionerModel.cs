using AutoMapper;

using CaseBasedSchedule.Domain.Entities;


namespace CaseBasedSchedule.Application.Models
{
    public class PractitionerModel
    {
        public string Id { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Discipline { get; set; } =string.Empty;
        private class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Practitioner, PractitionerModel>();
            }
        }
    }
}
