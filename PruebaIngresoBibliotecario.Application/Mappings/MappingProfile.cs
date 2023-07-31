using AutoMapper;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Commands;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Vm;
using PruebaIngresoBibliotecario.Domain;

namespace PruebaIngresoBibliotecario.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Prestamo, PrestamoVm>();

            CreateMap<CreatePrestamoCommand, Prestamo>()
                .ForMember(prop => prop.Id, prop => prop.Ignore())
                .ForMember(prop => prop.FechaMaximaDevolucion, prop => prop.Ignore());

            CreateMap<CreatePrestamoVm, Prestamo>()
                .ForMember(prop => prop.TipoUsuario, prop => prop.Ignore())
                .ForMember(prop => prop.IdentificacionUsuario, prop => prop.Ignore())
                .ForMember(prop => prop.Isbn, prop => prop.Ignore());
        }
    }
}
