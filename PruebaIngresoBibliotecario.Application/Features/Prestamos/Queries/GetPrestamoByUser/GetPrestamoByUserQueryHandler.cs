using AutoMapper;
using MediatR;
using PruebaIngresoBibliotecario.Application.Contracts.Persistence;
using PruebaIngresoBibliotecario.Domain;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Vm;
using PruebaIngresoBibliotecario.Application.Exceptions;

namespace PruebaIngresoBibliotecario.Application.Features.Prestamos.Queries.GetPrestamoByUser
{
    public class GetPrestamoByUserQueryHandler : IRequestHandler<GetPrestamoByUserQuery, PrestamoVm>
    {
        private readonly IAsyncRepository<Prestamo> PrestamoRepository;

        private readonly IMapper Mapper;

        public GetPrestamoByUserQueryHandler(IAsyncRepository<Prestamo> prestamoRepository, IMapper mapper)
        {
            PrestamoRepository = prestamoRepository;
            Mapper = mapper;
        }

        public async Task<PrestamoVm> Handle(GetPrestamoByUserQuery request, CancellationToken cancellationToken)
        {
            Prestamo prestamo = (await PrestamoRepository
                .GetAsync(
                    x => x.IdentificacionUsuario.Equals(request.IdUser),
                    true
            ))?.FirstOrDefault();

            if (prestamo != null)
                throw new CustomMessageException(400, $"El usuario con identificacion {prestamo.IdentificacionUsuario} ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo");

            return Mapper.Map<PrestamoVm>(prestamo);
        }
    }
}
