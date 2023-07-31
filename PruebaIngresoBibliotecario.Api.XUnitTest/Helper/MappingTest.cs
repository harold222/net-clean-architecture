using AutoMapper;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Vm;
using PruebaIngresoBibliotecario.Domain;

namespace PruebaIngresoBibliotecario.Api.XUnitTest.Helper
{
    public class MappingTest : Profile
    {
        public MappingTest() {
            CreateMap<Prestamo, PrestamoVm>();
        }
    }
}
