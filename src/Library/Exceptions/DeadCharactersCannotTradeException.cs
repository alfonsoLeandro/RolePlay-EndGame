namespace Library.Exceptions
{
    public class DeadCharactersCannotTradeException : System.Exception
    {
        public DeadCharactersCannotTradeException(string message) : base(message)
        {
        }
    }
}