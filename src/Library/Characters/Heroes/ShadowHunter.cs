using System.Collections.Generic;
using Library.CampoDeLosCaidos;
using Library.Items;

namespace Library.Characters.Heroes
{
    /// <summary>
    /// Clase que representa a un tipo de héroe llamado ShadowHunter.
    /// </summary>
    /// <seealso cref="AbstractHero"/>
    public class ShadowHunter : AbstractHero
    {
                
        /// <summary>
        /// Crea un nuevo ShadowHunter sin items por defecto (los mismos pueden ser agregados con posterioridad)
        /// y subscribe el mismo a la lista de observadores de la <see cref="TorreDeLosCaidos"/>.
        /// En este constructor se aplica el patrón creator, ya que muchas veces buscamos crear un personaje sin
        /// items, y para eso debemos pasar como parámetro una nueva lista de items, de ésto se encarga este constructor.
        /// </summary>
        /// <param name="hp">Los puntos de salud base de este ShadowHunter.</param>
        /// <param name="damage">El daño base de este ShadowHunter.</param>
        /// <param name="defense">La defensa base de este ShadowHunter.</param>
        public ShadowHunter(int hp, int damage, int defense) : base(hp, damage, defense)
        {
        }
        
        /// <summary>
        /// Crea un nuevo ShadowHunter con una lista de items agregados desde una primer instancia.
        /// y subscribe el mismo a la lista de observadores de la <see cref="TorreDeLosCaidos"/>.
        /// </summary>
        /// <param name="hp">Los puntos de salud base de este ShadowHunter.</param>
        /// <param name="damage">El daño base de este ShadowHunter.</param>
        /// <param name="defense">La defensa base de este ShadowHunter.</param>
        /// <param name="items">Los items a agregar a este ShadowHunter</param>
        public ShadowHunter(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }

        public override string ToString()
        {
            return "Brave shadow hunter";
        }
    }
}