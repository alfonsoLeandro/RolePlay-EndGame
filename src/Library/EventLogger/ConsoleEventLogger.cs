namespace Library.EventLogger
{
    /// <summary>
    /// Logger encargado de enviar todos los mensajes a la consola.
    /// </summary>
    public class ConsoleEventLogger : ILogger
    {
        public void Log(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}