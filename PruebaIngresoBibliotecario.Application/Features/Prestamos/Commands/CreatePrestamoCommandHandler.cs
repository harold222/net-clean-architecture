using AutoMapper;
using MediatR;
using PruebaIngresoBibliotecario.Application.Contracts.Persistence;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Vm;
using PruebaIngresoBibliotecario.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Application.Features.Prestamos.Commands
{
    public class CreatePrestamoCommandHandler : IRequestHandler<CreatePrestamoCommand, CreatePrestamoVm>
    {

        private readonly IAsyncRepository<Prestamo> PrestamoRepository;
        private readonly IMapper Mapper;

        public CreatePrestamoCommandHandler(IAsyncRepository<Prestamo> prestamoRepository, IMapper mapper)
        {
            this.PrestamoRepository = prestamoRepository;
            this.Mapper = mapper;
        }

        public async Task<CreatePrestamoVm> Handle(CreatePrestamoCommand request, CancellationToken cancellationToken)
        {
            Prestamo prestamo = await this.PrestamoRepository.AddAsync(this.Mapper.Map<Prestamo>(request));
            return this.Mapper.Map<CreatePrestamoVm>(prestamo);
        }
    }
}
