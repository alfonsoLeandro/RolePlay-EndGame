using Library.Characters;
using Library.Characters.Heroes;
using Library.Characters.Villains;

namespace Library.CampoDeLosCaidos
{
    /// <summary>
    /// Interfaz utilizada para aplicar patrón observer, esta interfaz se implementaría en
    /// las clases que deberían observar, es decir, suscribirse al ovserbable.
    /// </summary>
    /// <seealso cref="IObservable"/>
    public interface IObserver
    {
        /// <summary>
        /// Avisa al Observable cuando un personaje acaba con la vida de otro para que luego éste
        /// notifique a todos los Observers del hecho.
        /// Debido a cómo están implementados los métodos de ataque en heroes y villanos,
        /// sabiendo si uno de los dos personajes que atacó es de uno de los dos bandos
        /// podemos afirmar que el otro personaje es del bando opuesto.
        /// </summary>
        /// <param name="killer">El personaje que atacó.</param>
        /// <param name="killed">El personaje que fue atacado.</param>
        /// <seealso cref="AbstractHero"/>
        /// <seealso cref="AbstractVillain"/>
        void Update(AbstractCharacter killer, AbstractCharacter killed);
    }
}