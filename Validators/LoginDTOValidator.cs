using CrudApiJwt.DTOs;
using FluentValidation;

namespace CrudApiJwt.Validators
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O campo Email é obrigatório.")
                .EmailAddress().WithMessage("O Email informado não é válido.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("O campo Senha é obrigatório.")
                .MinimumLength(8).WithMessage("A senha deve ter no mínimo 8 caracteres.")
                .Matches(@"[A-Z]").WithMessage("A senha deve conter ao menos uma letra maiúscula.")
                .Matches(@"[a-z]").WithMessage("A senha deve conter ao menos uma letra minúscula.")
                .Matches(@"\d").WithMessage("A senha deve conter ao menos um número.")
                .Matches(@"[!@#\$%\^&\*\?_~\-£\(\)]").WithMessage("A senha deve conter ao menos um caractere especial.");
        }
    }
}
