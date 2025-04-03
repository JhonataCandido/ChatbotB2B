using Domain.CompanyAggregate.Entities;

namespace Domain.SubscriptionPlanAggregate.Entities
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal MonthlyPrice { get; set; }
        public int MaxChatbots { get; set; }
        public int MonthlyMessageLimit { get; set; }
        public int MaxFileSizeMB { get; set; }
        public int MaxFileUploads { get; set; }
        public int MaxLinks { get; set; }
        public bool SupportMultiLanguage { get; set; }
        public required string SLA { get; set; }

        public List<Company> Companies { get; set; } = [];
    }
}