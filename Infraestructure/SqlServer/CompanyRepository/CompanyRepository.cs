using Application.CompanyAggregate.Respositories.Interfaces;
using Dapper;
using Domain.CompanyAggregate.Entities;
using Infraestructure.Common.Entities;
using Microsoft.Data.SqlClient;

namespace Infraestructure.SqlServer.CompanyRepository
{
    public class CompanyRepository(SqlSettings sqlSettings) : ICompanyRepository
    {
        public async Task<Company> GetByIdAsync(Guid id)
        {
            using var connection = new SqlConnection(sqlSettings.ConnectionString);
            const string sql = @"
            SELECT Id, Name, TaxId, Email, PasswordHash, SubscriptionPlanId, Active, CreatedAt, LastRenewalDate 
            FROM Companies 
            WHERE Id = @Id";

            return await connection.QuerySingleOrDefaultAsync<Company>(sql, new { Id = id });
        }

        public async Task<Company> GetByEmailAsync(string email)
        {
            using var connection = new SqlConnection(sqlSettings.ConnectionString);
            const string sql = @"
                SELECT Id, Name, TaxId, Email, PasswordHash, SubscriptionPlanId, 
                       Active, CreatedAt, LastRenewalDate 
                FROM Companies 
                WHERE Email = @Email";

            return await connection.QuerySingleOrDefaultAsync<Company>(sql, new { Email = email });
        }

        public async Task<Guid> CreateAsync(Company company)
        {
            using var connection = new SqlConnection(sqlSettings.ConnectionString);
            const string sql = @"
            INSERT INTO Companies (Id, Name, TaxId, Email, PasswordHash, SubscriptionPlanId, Active, CreatedAt, LastRenewalDate)
            VALUES (@Id, @Name, @TaxId, @Email, @PasswordHash, @SubscriptionPlanId, @Active, @CreatedAt, @LastRenewalDate);
            SELECT @Id";

            company.Id = Guid.NewGuid();
            return await connection.ExecuteScalarAsync<Guid>(sql, company);
        }

        public async Task UpdateAsync(Company company)
        {
            using var connection = new SqlConnection(sqlSettings.ConnectionString);
            const string sql = @"
                UPDATE Companies 
                SET Name = @Name, 
                    TaxId = @TaxId, 
                    Email = @Email, 
                    PasswordHash = @PasswordHash, 
                    SubscriptionPlanId = @SubscriptionPlanId, 
                    Active = @Active, 
                    LastRenewalDate = @LastRenewalDate
                WHERE Id = @Id";

            await connection.ExecuteAsync(sql, company);
        }

        public async Task DeleteAsync(Guid id)
        {
            using var connection = new SqlConnection(sqlSettings.ConnectionString);
            const string sql = "DELETE FROM Companies WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}