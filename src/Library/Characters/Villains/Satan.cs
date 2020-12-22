using System.Collections.Generic;
using Library.CampoDeLosCaidos;
using Library.Items;

namespace Library.Characters.Villains
{
    /// <summary>
    /// Clase que representa a un tipo de villano llamado Satan.
    /// </summary>
    /// <seealso cref="AbstractVillain"/>
    public class Satan : AbstractVillain
    {
                        
        /// <summary>
        /// Crea un nuevo Satan sin items por defecto (los mismos pueden ser agregados con posterioridad),
        /// avisa mediante el Logger que un nuevo Satan ha "despertado"
        /// y subscribe el mismo a la lista de observadores de la <see cref="TorreDeLosCaidos"/>.
        /// En este constructor se aplica el patrón creator, ya que muchas veces buscamos crear un personaje sin
        /// items, y para eso debemos pasar como parámetro una nueva lista de items, de ésto se encarga este constructor.
        /// </summary>
        /// <param name="hp">Los puntos de salud base de este Satan.</param>
        /// <param name="damage">El daño base de este Satan.</param>
        /// <param name="defense">La defensa base de este Satan.</param>
        public Satan(int hp, int damage, int defense) : base(hp, damage*2, defense)
        {
            RpCore.Instance.Logger.Log("Satan has awaken");
        }
        
        /// <summary>
        /// Crea un nuevo Satan con una lista de items agregados desde una primer instancia,
        /// avisa mediante el Logger que un nuevo Satan ha "despertado"
        /// y subscribe el mismo a la lista de observadores de la <see cref="TorreDeLosCaidos"/>.
        /// </summary>
        /// <param name="hp">Los puntos de salud base de este Satan.</param>
        /// <param name="damage">El daño base de este Satan.</param>
        /// <param name="defense">La defensa base de este Satan.</param>
        /// <param name="items">Los items a agregar a este Satan</param>
        public Satan(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage*2, defense, items)
        {
            RpCore.Instance.Logger.Log("Satan has awaken");
        }

        public override string ToString()
        {
            return "Satan";
        }
    }
}