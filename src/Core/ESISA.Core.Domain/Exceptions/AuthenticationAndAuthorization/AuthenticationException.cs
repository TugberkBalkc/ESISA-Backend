namespace ESISA.Core.Domain.Exceptions.Authorization
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(String title, String message) : base(title + "," + message)
        {
        }
    }
}
