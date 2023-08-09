





using CaseBasedSchedule.Api.Converters;

namespace CaseBasedSchedule.Application.Models
{
    public class AppointmentModel
    {
        //private string [] description = { "Behandelaar", "Cliënt" };
        public string Id { get; set; } = string.Empty;
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; }= string.Empty;
        public string Name { get; set; } = string.Empty;
        //public string Description { get; set; } = string.Empty;
        public string Discipline { get; set; } = string.Empty;


        public AppointmentModel CreateAppointmentForClient(Guid clientId, DateTime date, TimeSpan startTime, TimeSpan endTime, string name, string discipline)
        {
            return CreateModel(clientId, date, startTime, endTime, name, discipline);
        }
        public AppointmentModel CreateAppointmentForPractioner(Guid practitionerId, DateTime date, TimeSpan startTime, TimeSpan endTime, string name, string discipline)
        {
            return CreateModel(practitionerId, date, startTime, endTime, name, discipline);
        }


        private AppointmentModel CreateModel(Guid id, DateTime date, TimeSpan startTime, TimeSpan endTime, string name, string discipline)
        {
            if (id == Guid.Empty) throw new ArgumentNullException("Id is empty");
            if (object.Equals(date, null)) throw new ArgumentNullException("Date is empty");
            if (object.Equals(startTime, null)) throw new ArgumentNullException("Start Date is empty");
            if (object.Equals(endTime, null)) throw new ArgumentNullException("End Date is empty");
            if (object.Equals(name, null)) throw new ArgumentNullException("DisplayName is empty");
            if (object.Equals(discipline, null)) throw new ArgumentNullException("Speciality is empty");
            try
            {
                var listOfDates = DateConverter.CovertDateToString(date, startTime, endTime);
                if (listOfDates == null)
                {
                    throw new ArgumentNullException("Time is not defined");
                   
                }
                return new AppointmentModel
                {
                    Id = id.ToString(),
                    StartTime = listOfDates["startTime"],
                    EndTime = listOfDates["endTime"],
                    Name = name,
                    Discipline = discipline

                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
