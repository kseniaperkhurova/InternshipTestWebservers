using CaseBasedSchedule.Api.Converters;
using CaseBasedSchedule.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseBasedSchedule.Application.Contracts
{
    public interface IAppointmentService
    {
        Task<IReadOnlyCollection<AppointmentModel>> GetClientAppointmentForTimeRangeAsync(AppointmentRequest appointmentRequest);

        Task<IReadOnlyCollection<AppointmentModel>> GetPractitionerAppointmentForTimeRangeAsync(AppointmentRequest appointmentRequest);
        AppointmentRequest CreateAppointmentRequest(string id, string startDate, string endDate);





    }
}
