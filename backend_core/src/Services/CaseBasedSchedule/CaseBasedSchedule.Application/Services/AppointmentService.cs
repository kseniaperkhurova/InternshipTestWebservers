

using AutoMapper;
using CaseBasedSchedule.Api.Converters;
using CaseBasedSchedule.Application.Contracts;
using CaseBasedSchedule.Application.Models;

namespace CaseBasedSchedule.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IPartitionerRepository _partitionerRepository;
        private readonly AppointmentModel _appointmentModel;

        public AppointmentService(IAppointmentRepository appointmentRepository, AppointmentModel appointmentModel, IClientRepository clientRepository, IPartitionerRepository partitionerRepository)
        {
            _appointmentRepository = appointmentRepository;
            _appointmentModel = appointmentModel;
            _clientRepository = clientRepository;
            _partitionerRepository = partitionerRepository;
        }

        public async Task<IReadOnlyCollection<AppointmentModel>> GetClientAppointmentForTimeRangeAsync(AppointmentRequest appointmentRequest)
        {

           
            var client = await _clientRepository.GetClientByIdAsync(appointmentRequest.Id.ToString());
            var id = new Guid(appointmentRequest.Id);
            var startDate = DateConverter.ConvertStringToDate(appointmentRequest.StartDate);
            var endDate = DateConverter.ConvertStringToDate(appointmentRequest.EndDate);
            var list =
                await _appointmentRepository
                .GetAllClientsAppointmentsForTimeRangeAsync(id, startDate, endDate);
            return list
                .Select(a => _appointmentModel
                .CreateAppointmentForClient(a.Id, a.Date, a.StartTime, a.EndTime, a.Practitioner.DisplayName, a.Practitioner.Discipline)).ToList();



        }
        public async Task<IReadOnlyCollection<AppointmentModel>> GetPractitionerAppointmentForTimeRangeAsync(AppointmentRequest appointmentRequest)
        {


            
            var practitioner = await _partitionerRepository.GetPartitionerByIdAsync(appointmentRequest.Id.ToString());
            var id = new Guid(appointmentRequest.Id);
            var startDate = DateConverter.ConvertStringToDate(appointmentRequest.StartDate);
            var endDate = DateConverter.ConvertStringToDate(appointmentRequest.EndDate);
            var list =
                await _appointmentRepository
                .GetAllPractitionersAppointmentsForTimeRangeAsync(id, startDate, endDate);
            return list
                .Select(a => _appointmentModel
                .CreateAppointmentForPractioner(a.Id, a.Date, a.StartTime, a.EndTime, a.Client.DisplayName, a.Practitioner.Discipline)).ToList();



        }

        public AppointmentRequest CreateAppointmentRequest(string id, string startDate,string endDate)
        {
            AppointmentRequest appointmentRequest = new AppointmentRequest
            {
                Id = id,
                StartDate = startDate,
                EndDate = endDate
            };
            appointmentRequest.IsRequestValid();
            return appointmentRequest;
        }




    }
}
