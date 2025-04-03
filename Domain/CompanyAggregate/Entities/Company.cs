using Domain.ChatBotAggregate.Entities;
using Domain.CompanyAggregate.Request;
using Domain.SubscriptionPlanAggregate.Entities;
using Domain.UsageTrackingAggregate.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Domain.CompanyAggregate.Entities
{
    public class Company
    {
        public Company() { }

        [SetsRequiredMembers]
        public Company(RegisterCompanyRequest registerCompany, string hashedPassword)
        {
            Name = registerCompany.CompanyName;
            TaxId = registerCompany.TaxId;
            Email = registerCompany.Email;
            PasswordHash = hashedPassword;
            CreatedAt = DateTime.UtcNow;
            LastRenewalDate = DateTime.UtcNow;
            SubscriptionPlanId = 1;
        }

        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string TaxId { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public int SubscriptionPlanId { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastRenewalDate { get; set; }

        public SubscriptionPlan SubscriptionPlan { get; set; } = null!;
        public List<Chatbot> Chatbots { get; set; } = [];
        public List<UsageTracking> UsageTrackings { get; set; } = [];
    }
}