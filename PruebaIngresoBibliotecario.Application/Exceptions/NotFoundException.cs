using System;

namespace PruebaIngresoBibliotecario.Application.Exceptions
{
    public class NotFoundException : ApplicationException 
    {
        public NotFoundException(string name, object key): base($"No fue encontrado {key} en {name}")
        { }
    }
}
