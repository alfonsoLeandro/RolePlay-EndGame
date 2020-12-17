namespace Library.Exceptions
{
    public class CannotAddItemException : System.Exception
    {
        public CannotAddItemException(string message) : base(message)
        {
        }
    }
}