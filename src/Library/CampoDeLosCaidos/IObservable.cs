using Library.Characters;

namespace Library.CampoDeLosCaidos
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);
        void UnSubscribe(IObserver observer);
        void Notify(AbstractCharacter killer, AbstractCharacter killed);
    }
}