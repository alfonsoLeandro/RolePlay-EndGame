using System.Collections.Generic;
using Library.Characters;

namespace Library.CampoDeLosCaidos
{
    public class TorreDeLosCaidos : IObservable
    {
        public static TorreDeLosCaidos Instance { get; } = new TorreDeLosCaidos();
        private List<IObserver> Observers { get; }

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