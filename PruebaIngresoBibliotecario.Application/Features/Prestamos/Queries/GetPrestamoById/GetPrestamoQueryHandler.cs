using AutoMapper;
using MediatR;
using PruebaIngresoBibliotecario.Application.Contracts.Persistence;
using PruebaIngresoBibliotecario.Application.Exceptions;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Vm;
using PruebaIngresoBibliotecario.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Application.Features.Prestamos.Queries.GetPrestamoById
{
    public class GetPrestamoQueryHandler : IRequestHandler<GetPrestamoQuery, PrestamoVm>
    {
        private readonly IAsyncRepository<Prestamo> PrestamoRepository;

        private readonly IMapper Mapper;

        public GetPrestamoQueryHandler(IAsyncRepository<Prestamo> prestamoRepository, IMapper mapper)
        {
            PrestamoRepository = prestamoRepository;
            Mapper = mapper;
        }

        public async Task<PrestamoVm> Handle(GetPrestamoQuery request, CancellationToken cancellationToken)
        {
            Prestamo prestamo = await PrestamoRepository.GetByIdAsync(request.Id);

            if (prestamo == null)
                throw new CustomMessageException(404, $"El prestamo con id {request.Id} no existe");

            return Mapper.Map<PrestamoVm>(prestamo);
        }
    }
}
