using Library.Characters;

namespace Library.CampoDeLosCaidos
{
    /// <summary>
    /// Interfaz utilizada para aplicar patrón observer, esta interfaz se implementaría en
    /// las clases que deberían ser observadas.
    /// </summary>
    /// <seealso cref="IObserver"/>
    public interface IObservable
    {
        /// <summary>
        /// Añade un <see cref="IObserver"/> a la lista de Observers, para notificarlos cuando sea necesario.
        /// </summary>
        /// <param name="observer">El observer a añadir a la lista.</param>
        void Subscribe(IObserver observer);
        
        /// <summary>
        /// Remueve un <see cref="IObserver"/> de la lista de Observers siempre y cuando éste se encuentre en la lista.
        /// </summary>
        /// <param name="observer">El observer a remover de la lista.</param>
        void UnSubscribe(IObserver observer);
        
        /// <summary>
        /// Notifica a todos los Observers en la lista de Observers, en este caso, de que un
        /// personaje ha asesinado a otro.
        /// </summary>
        /// <param name="killer">El personaje que se encargó de atacar.</param>
        /// <param name="killed">El personaje ahora sin vida.</param>
        void Notify(AbstractCharacter killer, AbstractCharacter killed);
    }
}