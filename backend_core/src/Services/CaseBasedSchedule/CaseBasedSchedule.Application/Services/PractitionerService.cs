

using AutoMapper;
using CaseBasedSchedule.Application.Contracts;
using CaseBasedSchedule.Application.Models;
using CaseBasedSchedule.Domain.Fcatories;

namespace CaseBasedSchedule.Application.Services
{
    public class PractitionerService : IPractitionerService
    {
        private readonly IPartitionerRepository _partitionerRepository;
        private readonly IMapper _mapper;
        private readonly IPractitionerFactory _practitionerFactory;

        public PractitionerService(IPartitionerRepository partitionerRepository, IMapper mapper, IPractitionerFactory practitionerFactory)
        {
            _mapper = mapper;
            _partitionerRepository = partitionerRepository;
            _practitionerFactory = practitionerFactory;
        }

        public async Task<IReadOnlyCollection<PractitionerModel>> GetPractitonerModels()
        { 
            var list = await _partitionerRepository.GetAllPartitionersAsync();
            return list.Select(p => _mapper.Map<PractitionerModel>(p)).ToList();
        
        }
        public async Task<Guid> AddPractitionerAsync(PractionerRequest practionerRequest)
        {
            practionerRequest.IsRequestValid();
            var aPractitioner = _practitionerFactory.CreatePractitioner(practionerRequest.DisplayName, practionerRequest.Discipline);
            var practitionerId = await _partitionerRepository.AddPractitionerAsync(aPractitioner);
            return practitionerId;
        }
        public async Task UpdatePractitionerAsync(string id, PractionerRequest practionerRequest)
        {
            practionerRequest.IsRequestValid();
            await _partitionerRepository.UpdatePractitionerAsync(id, practionerRequest.DisplayName, practionerRequest.Discipline);

          
            
        }
        public async Task DeletePractitionerAsync(string id)
        {
           
            await _partitionerRepository.DeletePractitionerAsync(id);

        }
    }
}
