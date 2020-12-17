namespace Library.Exceptions
{
    public class DoesNotContainItemException : System.Exception
    {
        public DoesNotContainItemException(string message) : base(message)
        {
        }
    }
}