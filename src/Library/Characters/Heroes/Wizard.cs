using System.Collections.Generic;
using Library.CampoDeLosCaidos;
using Library.Items;

namespace Library.Characters.Heroes
{
    /// <summary>
    /// Clase que representa a un tipo de héroe mágico llamado Wizard.
    /// </summary>
    /// <seealso cref="AbstractMagicHero"/>
    public class Wizard : AbstractMagicHero
    {
        
        /// <summary>
        /// Registro de los nombres de cada personaje que ha asesinado por lo menos otro personaje
        /// con sus correspondientes personajes asesinados.
        /// </summary>
        /// <seealso cref="TorreDeLosCaidos"/>
        public static Dictionary<string,List<string>> LibroDeLaSabiduria { get; } = new Dictionary<string, List<string>>();
        
                
        /// <summary>
        /// Crea un nuevo Wizard sin items por defecto (los mismos pueden ser agregados con posterioridad)
        /// y subscribe el mismo a la lista de observadores de la <see cref="TorreDeLosCaidos"/>.
        /// En este constructor se aplica el patrón creator, ya que muchas veces buscamos crear un personaje sin
        /// items, y para eso debemos pasar como parámetro una nueva lista de items, de ésto se encarga este constructor.
        /// </summary>
        /// <param name="hp">Los puntos de salud base de este Wizard.</param>
        /// <param name="damage">El daño base de este Wizard.</param>
        /// <param name="defense">La defensa base de este Wizard.</param>
        public Wizard(int hp, int damage, int defense) : base(hp, damage, defense)
        {
        }
        
        /// <summary>
        /// Crea un nuevo Wizard con una lista de items agregados desde una primer instancia.
        /// y subscribe el mismo a la lista de observadores de la <see cref="TorreDeLosCaidos"/>.
        /// </summary>
        /// <param name="hp">Los puntos de salud base de este Wizard.</param>
        /// <param name="damage">El daño base de este Wizard.</param>
        /// <param name="defense">La defensa base de este Wizard.</param>
        /// <param name="items">Los items a agregar a este Wizard</param>
        public Wizard(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }
        
        
        public override string ToString()
        {
            return "Wizard";
        }

        public override void Update(AbstractCharacter killer, AbstractCharacter killed)
        {
            base.Update(killer, killed);
            string killerName = killer.ToString() + $"({killer.Id})";
            if (LibroDeLaSabiduria.ContainsKey(killerName))
            {
                LibroDeLaSabiduria[killerName].Add(killed.ToString());
            }
            else
            { 
                LibroDeLaSabiduria.Add(killerName, new List<string>(){killed.ToString()});
            }
        }
    }
}