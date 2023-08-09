namespace CaseBasedSchedule.Domain.Entities
{
    public class Client : Entity<Guid>
    {
        internal Client() { }
       
        public string DisplayName { get; set; } = string.Empty;
        
        public IEnumerable<AgendaItem>? Appointments { get; set; }
    }
}
