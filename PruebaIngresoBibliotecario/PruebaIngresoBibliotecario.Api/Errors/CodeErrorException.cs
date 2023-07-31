namespace PruebaIngresoBibliotecario.Api.Errors
{
    public class CodeErrorException : CodeErrorResponse
    {
        public CodeErrorException(int code, string message = "") : base(code, message)
        {
        }
    }
}
