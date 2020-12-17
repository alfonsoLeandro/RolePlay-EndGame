namespace Library.EventLogger
{
    public class ConsoleEventLogger : ILogger
    {
        public void Log(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}