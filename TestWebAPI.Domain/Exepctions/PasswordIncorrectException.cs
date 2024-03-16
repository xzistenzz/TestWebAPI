namespace TestWebAPI.Domain.Exepctions
{
    public class PasswordIncorrectException : Exception
    {
        public PasswordIncorrectException(string message) : base(message) { }
    }
}
