using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRental.Web.Models.DTO;

namespace VideoRental.Web.Validators
{
    public class FilmeValidator : AbstractValidator<FilmeDTO>
    {
        public FilmeValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Informe o nome do filme")
                .Length(3, 100).WithMessage("O nome deve ter no mínimo 3 caracteres e no máximo 100 caracteres");

            RuleFor(x => x.Ano)
                .NotNull().WithMessage("Informe o ano do filme")
                .GreaterThan(1887).WithMessage("O ano de lançamento deve ser a partir de 1888");

            RuleFor(x => x.GeneroId)
                .NotNull().WithMessage("Campo obrigatório");

            RuleFor(x => x.Classificacao)
                .NotEmpty().WithMessage("Informe a classificação do filme")
                .Length(3, 100).WithMessage("A classificação deve ter no mínimo 3 caracteres e no máximo 100 caracteres");

            RuleFor(x => x.Duracao)
                .NotEmpty().WithMessage("Informe a duração do filme")
                .Length(3, 100).WithMessage("A duração deve ter no mínimo 3 caracteres e no máximo 100 caracteres");
        }
    }
}
