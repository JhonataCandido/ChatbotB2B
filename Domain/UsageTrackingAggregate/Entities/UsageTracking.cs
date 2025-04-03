using Domain.CompanyAggregate.Entities;

namespace Domain.UsageTrackingAggregate.Entities
{
    public class UsageTracking
    {
        public int Id { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime TrackingDate { get; set; }
        public int MessageCount { get; set; }
        public int FileUploadCount { get; set; }
        public int LinkUsageCount { get; set; }

        public Company Company { get; set; } = null!;
    }
}