using AutoMapper;
using CaseBasedSchedule.Domain.Entities;

namespace CaseBasedSchedule.Api.Models
{
    public class ClientModel
    {
        public string Id { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;

        private class MappingProfile: Profile
        {
            public MappingProfile()
            {
                CreateMap<Client, ClientModel>();
            }
        }
        
    }
}
