using Domain.ChatInteractionAggregate.Entities;
using Domain.CompanyAggregate.Entities;
using Domain.TrainingDataAggregate.Entities;

namespace Domain.ChatBotAggregate.Entities
{
    public class Chatbot
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public required string Name { get; set; }
        public required string BaseModel { get; set; }
        public string? WelcomeMessage { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public Company Company { get; set; } = null!;
        public List<TrainingData> TrainingData { get; set; } = [];
        public List<ChatInteraction> ChatInteractions { get; set; } = [];
    }
}