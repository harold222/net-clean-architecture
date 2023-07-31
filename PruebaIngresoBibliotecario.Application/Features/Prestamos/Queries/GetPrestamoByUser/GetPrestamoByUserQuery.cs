using MediatR;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Vm;

namespace PruebaIngresoBibliotecario.Application.Features.Prestamos.Queries.GetPrestamoByUser
{
    public class GetPrestamoByUserQuery : IRequest<PrestamoVm>
    {
        public string IdUser { get; set; }

        public GetPrestamoByUserQuery(string idUser)
        {
            this.IdUser = idUser;
        }
    }
}
