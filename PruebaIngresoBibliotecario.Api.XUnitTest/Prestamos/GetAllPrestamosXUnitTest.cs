using AutoFixture;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Queries.GetAllPrestamos;
using PruebaIngresoBibliotecario.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using AutoMapper;
using Moq;
using PruebaIngresoBibliotecario.Application.Contracts.Persistence;
using PruebaIngresoBibliotecario.Api.XUnitTest.Helper;
using System.Linq;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Vm;
using Shouldly;

namespace PruebaIngresoBibliotecario.Api.XUnitTest.Prestamos
{
    public class GetAllPrestamosXUnitTest
    {
        private GetAllPrestamosQueryHandler handler;
        private readonly Mock<IAsyncRepository<Prestamo>> MockRepository;

        public GetAllPrestamosXUnitTest()
        {
            this.MockRepository = new Mock<IAsyncRepository<Prestamo>>();
            IMapper mapper = new MapperConfiguration(t =>
                t.AddProfile(new MappingTest())
            ).CreateMapper();
            this.handler = new GetAllPrestamosQueryHandler(this.MockRepository.Object, mapper);
        }

        [Fact]
        public async Task ObtenerTodosLosPrestamos()
        {
            GetAllPrestamosQuery query = new GetAllPrestamosQuery();
            Fixture fixture = new Fixture();
            List<Prestamo> prestamosTests = fixture.CreateMany<Prestamo>().ToList();

            this.MockRepository.Setup(x => x.GetAllAsync())
                .ReturnsAsync(prestamosTests);

            var response = await this.handler.Handle(query, new CancellationToken());

            response.ShouldBeOfType<List<PrestamoVm>>();
        }
    }
}
