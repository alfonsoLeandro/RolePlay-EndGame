namespace Library.Exceptions
{
    public class NotEnoughParticipantsInBattleException : System.Exception
    {
        public NotEnoughParticipantsInBattleException(string message) : base(message)
        {
        }
    }
}