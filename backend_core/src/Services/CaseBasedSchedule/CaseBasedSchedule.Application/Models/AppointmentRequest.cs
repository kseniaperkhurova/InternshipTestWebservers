



namespace CaseBasedSchedule.Application.Models
{
    public class AppointmentRequest
    {
        public string  Id { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;

       

        public void IsRequestValid()
        {
            if (string.IsNullOrEmpty(Id)) throw new ArgumentNullException(Id); 
            if (string.IsNullOrEmpty(StartDate)) throw new ArgumentNullException(StartDate);
            if (string.IsNullOrEmpty(EndDate)) throw new ArgumentNullException(EndDate);
            
        }
    }
}
