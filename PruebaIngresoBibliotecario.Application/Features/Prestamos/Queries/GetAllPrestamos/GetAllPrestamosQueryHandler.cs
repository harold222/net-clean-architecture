using AutoMapper;
using MediatR;
using PruebaIngresoBibliotecario.Application.Contracts.Persistence;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Vm;
using PruebaIngresoBibliotecario.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Application.Features.Prestamos.Queries.GetAllPrestamos
{
    public class GetAllPrestamosQueryHandler : IRequestHandler<GetAllPrestamosQuery, IReadOnlyList<PrestamoVm>>
    {
        private readonly IAsyncRepository<Prestamo> PrestamoRepository;

        private readonly IMapper Mapper;

        public GetAllPrestamosQueryHandler(IAsyncRepository<Prestamo> prestamoRepository, IMapper mapper)
        {
            this.PrestamoRepository = prestamoRepository;
            this.Mapper = mapper;
        }

        public async Task<IReadOnlyList<PrestamoVm>> Handle(GetAllPrestamosQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Prestamo> allPrestamos = await this.PrestamoRepository.GetAllAsync();

            return Mapper.Map<IReadOnlyList<PrestamoVm>>(allPrestamos);
        }
    }
}
