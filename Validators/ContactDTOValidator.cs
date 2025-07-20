using CrudApiJwt.DTOs;
using FluentValidation;

namespace CrudApiJwt.Validators
{
    public class ContactDTOValidator : AbstractValidator<ContactDTO>
    {
        public ContactDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é obrigatório")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("O telefone é obrigatório")
                .Matches(@"^\(?\d{2,3}\)? ?\d{4,5}-?\d{4}$")
                .WithMessage("O telefone deve estar em um formato válido (ex: 99999-9999)");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório")
                .EmailAddress().WithMessage("O e-mail deve estar em um formato válido");
        }
    }
}
