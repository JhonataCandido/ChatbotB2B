using Domain.CompanyAggregate.Entities;

namespace Application.CompanyAggregate.Respositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetByIdAsync(Guid id);
        Task<Company> GetByEmailAsync(string email);
        Task<Guid> CreateAsync(Company company);
        Task UpdateAsync(Company company);
        Task DeleteAsync(Guid id);
    }
}