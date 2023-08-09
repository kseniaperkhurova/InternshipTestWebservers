


namespace CaseBasedSchedule.Domain.Entities
{
    public class AgendaItem : Entity<Guid>
    {
        internal AgendaItem() { }
        public DateTime Date { get; set; }// start date of the therapie
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public Client Client { get; set; }
        public Practitioner Practitioner { get; set; }
       
    }
}