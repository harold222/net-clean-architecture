using AutoFixture;
using AutoMapper;
using Moq;
using PruebaIngresoBibliotecario.Api.XUnitTest.Helper;
using PruebaIngresoBibliotecario.Application.Contracts.Persistence;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Queries.GetPrestamoByUser;
using PruebaIngresoBibliotecario.Domain;
using PruebaIngresoBibliotecario.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PruebaIngresoBibliotecario.Api.XUnitTest.Prestamos
{
    public class GetPrestamoByUserXUnitTest
    {
        private GetPrestamoByUserQueryHandler handler;
        private readonly Mock<IAsyncRepository<Prestamo>> MockRepository;

        public GetPrestamoByUserXUnitTest()
        {
            this.MockRepository = new Mock<IAsyncRepository<Prestamo>>();
            IMapper mapper = new MapperConfiguration(t =>
                t.AddProfile(new MappingTest())
            ).CreateMapper();
            this.handler = new GetPrestamoByUserQueryHandler(this.MockRepository.Object, mapper);
        }

        [Theory]
        [InlineData("123456789")]
        public async Task ObtenerPrestamoUsuarioInvitado(string idUser)
        {
            Prestamo prestamo = new Prestamo()
            {
                FechaMaximaDevolucion = DateTime.Now.AddDays(7),
                Id = Guid.NewGuid(),
                IdentificacionUsuario = idUser,
                Isbn = Guid.NewGuid(),
                TipoUsuario = UserType.INVITADO
            };

            GetPrestamoByUserQuery query = new GetPrestamoByUserQuery(idUser);

            Fixture fixture = new Fixture();
            List<Prestamo> prestamosTests = fixture.CreateMany<Prestamo>().ToList();

            prestamosTests.Add(prestamo);

            try
            {
                this.MockRepository.Setup(x => x.GetAsync(It.IsAny<Func<Prestamo, bool>>(), true))
                .ReturnsAsync((Func<Prestamo, bool> predicate, bool disableTracking) =>
                    prestamosTests.Where(predicate).ToList().AsReadOnly()
                );

                await this.handler.Handle(query, new CancellationToken());
                Assert.True(false, "No existe la identificacion del usuario - error");
            }
            catch (Exception ex)
            {
                Assert.Contains(idUser, ex.Message);
            }
        }
    }
}
