namespace Domain.MessageAggregate.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid InteractionId { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsUserMessage { get; set; }
        public DateTime Timestamp { get; set; }
    }
}