using System.Collections.Generic;
using Library.CampoDeLosCaidos;
using Library.Characters.Villains;
using Library.Items;

namespace Library.Characters.Heroes
{
    
    /// <summary>
    /// Clase destinada a ser heredada por clases que representen a héroes que puedan poseer items
    /// de tipo mágico (<see cref="MagicItem"/>).
    /// </summary>
    /// <seealso cref="MagicItem"/>
    /// <seealso cref="AbstractMagicVillain"/>
    public abstract class AbstractMagicHero : AbstractHero
    {
    
        /// <summary>
        /// Crea un nuevo héroe mágico sin items por defecto (los mismos pueden ser agregados con posterioridad)
        /// y subscribe el mismo a la lista de observadores de la  <see cref="TorreDeLosCaidos"/>.
        /// En este constructor se aplica el patrón creator, ya que muchas veces buscamos crear un personaje sin
        /// items, y para eso debemos pasar como parámetro una nueva lista de items, de ésto se encarga este constructor.
        /// </summary>
        /// <param name="hp">Los puntos de salud base de este héroe.</param>
        /// <param name="damage">El daño base de este héroe.</param>
        /// <param name="defense">La defensa base de este héroe.</param>
        protected AbstractMagicHero(int hp, int damage, int defense) : base(hp, damage, defense)
        {
        }
        
        /// <summary>
        /// Crea un nuevo héroe mágico y subscribe el mismo a la lista de observadores de la <see cref="TorreDeLosCaidos"/>.
        /// </summary>
        /// <param name="hp">Los puntos de salud base de este héroe.</param>
        /// <param name="damage">El daño base de este héroe.</param>
        /// <param name="defense">La defensa base de este héroe.</param>
        /// <param name="items">Una lista de items para agregar a este héroe.</param>
        /// <seealso cref="AbstractItem"/>
        protected AbstractMagicHero(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }
    }
}