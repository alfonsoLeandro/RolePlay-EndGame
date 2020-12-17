namespace Library.Exceptions
{
    public class CannotAttackDeadException : System.Exception
    {

        public CannotAttackDeadException(string message) : base(message)
        {
        }

    }
}