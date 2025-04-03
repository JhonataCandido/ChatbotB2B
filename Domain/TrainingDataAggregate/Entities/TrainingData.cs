using Domain.ChatBotAggregate.Entities;

namespace Domain.TrainingDataAggregate.Entities
{
    public class TrainingData
    {
        public Guid Id { get; set; }
        public Guid ChatbotId { get; set; }
        public required string SourceType { get; set; }
        public string? FileName { get; set; }
        public decimal? FileSizeMB { get; set; }
        public string? OriginalURL { get; set; }
        public required string ProcessedContent { get; set; }
        public DateTime UploadDate { get; set; }
        public required string Status { get; set; }

        public Chatbot Chatbot { get; set; } = null!;
    }
}
