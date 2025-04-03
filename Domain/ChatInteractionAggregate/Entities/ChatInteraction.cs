using Domain.ChatBotAggregate.Entities;
using Domain.MessageAggregate.Entities;

namespace Domain.ChatInteractionAggregate.Entities
{
    public class ChatInteraction
    {
        public Guid Id { get; set; }
        public Guid ChatbotId { get; set; }
        public required string SessionId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? UserLanguage { get; set; }
        public int? SatisfactionRating { get; set; }

        public Chatbot Chatbot { get; set; } = null!;
        public List<Message> Messages { get; set; } = [];
    }
}