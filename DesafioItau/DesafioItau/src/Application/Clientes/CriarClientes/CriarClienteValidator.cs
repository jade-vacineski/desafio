using DesafioItau.src.Application.Clientes.CriarClientes;
using FluentValidation;

namespace DesafioItau.src.Application.Clientes.CriarClientes
{
    public class CriarClienteValidator : AbstractValidator<CriarClienteRequest>
    {
        public CriarClienteValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .Length(11)
                .WithMessage("CPF deve ter 11 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email inválido");

            RuleFor(x => x.ValorMensal)
                .GreaterThan(0)
                .WithMessage("Valor mensal deve ser maior que zero");
        }
    }
}