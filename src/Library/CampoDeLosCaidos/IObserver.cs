using Library.Characters;

namespace Library.CampoDeLosCaidos
{
    public interface IObserver
    {
        void Update(AbstractCharacter killer, AbstractCharacter killed);
    }
}