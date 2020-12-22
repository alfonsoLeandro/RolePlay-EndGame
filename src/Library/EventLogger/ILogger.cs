namespace Library.EventLogger
{
    /// <summary>
    /// Interfaz destinada a ser implementada por clases dedicadas a enviar mensajes de log.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Envía un mensaje para ser logeado por el ILogger seleccionado previamente.
        /// </summary>
        /// <param name="message">El mensaje a enviar.</param>
        public void Log(string message);
    }
}