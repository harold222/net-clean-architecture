using FluentValidation;

namespace PruebaIngresoBibliotecario.Application.Features.Prestamos.Queries.GetPrestamoByUser
{
    public class GetPrestamoByUserValidator : AbstractValidator<GetPrestamoByUserQuery>
    {
        public GetPrestamoByUserValidator()
        {
            RuleFor(p => p.IdUser)
                .NotEmpty().WithMessage("Debe de tener valor")
                .MaximumLength(10).WithMessage("No debe ser mayor a 10 caracteres");
        }
    }
}
