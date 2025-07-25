using CrudApiJwt.DTOs;
using FluentValidation;

namespace CrudApiJwt.Validators
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O campo Nome é obrigatório.")
            .MinimumLength(2).WithMessage("O Nome deve ter no mínimo 2 caracteres.")
            .MaximumLength(100).WithMessage("O Nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O campo Email é obrigatório.")
            .EmailAddress().WithMessage("O Email informado não é válido.");
        }
    }
}