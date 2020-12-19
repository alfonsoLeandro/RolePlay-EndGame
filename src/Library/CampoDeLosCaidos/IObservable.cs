using Library.Characters;

namespace Library.CampoDeLosCaidos
{
    /// <summary>
    /// 
    /// </summary>
    public interface IObservable
    {
        void Subscribe(IObserver observer);
        void UnSubscribe(IObserver observer);
        void Notify(AbstractCharacter killer, AbstractCharacter killed);
    }
}