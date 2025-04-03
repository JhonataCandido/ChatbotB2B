using System.ComponentModel.DataAnnotations;

namespace Domain.CompanyAggregate.Request
{
    public record RegisterCompanyRequest(
    [Required(ErrorMessage = "O nome da empresa é obrigatório")]
    [StringLength(200, MinimumLength = 2, ErrorMessage = "O nome da empresa deve ter entre 2 e 200 caracteres")]
    string CompanyName,

    [Required(ErrorMessage = "O TaxId é obrigatório")]
    string TaxId,

    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
    string Email,

    [Required(ErrorMessage = "A senha é obrigatória")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 100 caracteres")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
        ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, uma minúscula, um número e um caractere especial")]
    string Password);
}