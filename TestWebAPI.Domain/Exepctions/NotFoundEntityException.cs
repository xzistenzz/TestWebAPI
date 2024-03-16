namespace TestWebAPI.Domain.Exepctions
{
    public class NotFoundEntityException : Exception
    {
        public NotFoundEntityException(string message) : base(message) { }
    }
}
