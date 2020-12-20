using System.Collections.Generic;
using Library.Characters;

namespace Library.CampoDeLosCaidos
{
    /// <summary>
    /// Clase encargada de implementar la interfaz <see cref="IObservable"/> y así implementar el patrón Observer.
    /// </summary>
    public class TorreDeLosCaidos : IObservable
    {
        /// <summary>
        /// Única instancia de esta clase. Aplicamos Singleton para asegurarnos
        /// que haya una sola instancia de la misma.
        /// Es necesario que haya una sola instancia de esta clase para así no registrar una misma instancia
        /// de muerte más de una vez.
        /// </summary>
        public static TorreDeLosCaidos Instance { get; } = new TorreDeLosCaidos();
        
        /// <summary>
        /// Lista de <see cref="IObserver"/> que se encuentran suscritos a las notificaciones de este
        /// Observable.
        /// </summary>
        private List<IObserver> Observers { get; }

        /// <summary>
        /// Constructor privado para facilitar la aplicación del patrón Singleton.
        /// </summary>
        private TorreDeLosCaidos()
        {
            Observers = new List<IObserver>();
        }
        
        
        public void Subscribe(IObserver observer)
        {
            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);
            }
        }

        public void UnSubscribe(IObserver observer)
        {
            if (Observers.Contains(observer))
            {
                Observers.Remove(observer);
            }
        }
        
        public void Notify(AbstractCharacter killer, AbstractCharacter killed)
        {
            foreach (var observer in Observers)
            {
                observer.Update(killer, killed);
            }
        }
    }
}