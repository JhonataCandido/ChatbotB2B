using Application.Common.BCryptHasher.Interface;
using Application.CompanyAggregate.Respositories.Interfaces;
using Domain.CompanyAggregate.Entities;
using Domain.CompanyAggregate.Request;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotB2B.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IPasswordHasher _passwordHasher, ICompanyRepository _companyRepository) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCompanyRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var existingCompany = await _companyRepository.GetByEmailAsync(request.Email);

            if (existingCompany != null)
                return Conflict("Email já registrado");

            var hashedPassword = _passwordHasher.HashPassword(request.Password);

            var company = new Company(request, hashedPassword);

            await _companyRepository.CreateAsync(company);

            return Created("", new { company.Id });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = await _authService.AuthenticateAsync(request.Email, request.Password);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid email or password");
            }
        }

    }

}
