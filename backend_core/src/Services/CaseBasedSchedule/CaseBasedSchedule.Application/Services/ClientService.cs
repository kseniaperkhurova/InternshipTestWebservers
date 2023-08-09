

using AutoMapper;
using CaseBasedSchedule.Api.Models;
using CaseBasedSchedule.Application.Contracts;
using System.Collections;

namespace CaseBasedSchedule.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<ClientModel>> GetClientModels()
        {
            var clients = await _clientRepository.GetAllClientsAsync();
            return clients.Select(c=> _mapper.Map<ClientModel>(c)).ToList();
          
        }
       

    }
}
