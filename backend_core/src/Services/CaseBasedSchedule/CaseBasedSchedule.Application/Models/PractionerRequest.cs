

namespace CaseBasedSchedule.Application.Models
{
    public class PractionerRequest
    {
        public string DisplayName { get; set; } = string.Empty;
        public string Discipline { get; set; }= string.Empty;
        public void IsRequestValid()
        {
            if (string.IsNullOrEmpty(DisplayName)) throw new ArgumentNullException(DisplayName);
            if (string.IsNullOrEmpty(Discipline)) throw new ArgumentNullException(Discipline);
         

        }
    }
}
