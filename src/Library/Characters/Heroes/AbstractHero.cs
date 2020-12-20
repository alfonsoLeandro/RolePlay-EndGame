using System;
using System.Collections.Generic;
using Library.CampoDeLosCaidos;
using Library.Characters.Villains;
using Library.Exceptions;
using Library.Items;

namespace Library.Characters.Heroes
{
    /// <summary>
    /// Clase abstracta destinada a ser heredada por cada clase que represente a un héroe
    /// que no sea mágico.
    /// </summary>
    /// <seealso cref="AbstractMagicHero"/>
    public abstract class AbstractHero : AbstractCharacter, IObserver
    {
        
        /// <summary>
        /// Registro de la cantidad de villanos derrotados por héroes (Honor & Glory).
        /// </summary>
        /// <see cref="TorreDeLosCaidos"/>
        public static int PiedraEterna { get; protected set; }
        
        /// <summary>
        /// Crea un nuevo héroe sin items por defecto (los mismos pueden ser agregados con posterioridad)
        /// y subscribe el mismo a la lista de observadores de la <see cref="TorreDeLosCaidos"/>.
        /// En este constructor se aplica el patrón creator, ya que muchas veces buscamos crear un personaje sin
        /// items, y para eso debemos pasar como parámetro una nueva lista de items, de ésto se encarga este constructor.
        /// </summary>
        /// <param name="hp">Los puntos de salud base de este héroe.</param>
        /// <param name="damage">El daño base de este héroe.</param>
        /// <param name="defense">La defensa base de este héroe.</param>
        public AbstractHero(int hp, int damage, int defense) : this(hp, damage, defense, new List<AbstractItem>())
        {
        }

        /// <summary>
        /// Crea un nuevo héroe y subscribe el mismo a la lista de observadores de la <see cref="TorreDeLosCaidos"/>.
        /// </summary>
        /// <param name="hp">Los puntos de salud base de este héroe.</param>
        /// <param name="damage">El daño base de este héroe.</param>
        /// <param name="defense">La defensa base de este héroe.</param>
        /// <param name="items">Una lista de items para agregar a este héroe.</param>
        /// <seealso cref="AbstractItem"/>
        public AbstractHero(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
            TorreDeLosCaidos.Instance.Subscribe(this);
        }
        
        /// <summary>
        /// Ejecuta un ataque hacia un villano.
        /// Aquí entran en juego los puntos de salud del villano, el ataque del héroe y los puntos de
        /// defensa del villano. Estos últimos pueden ser nada o muy efectivos, se genera un número random
        /// desde 0 hasta el valor de la defensa del villano, el número resultante se le resta al ataque del héroe
        /// y el valor resultante se le resta a los puntos de salud del villano.
        /// </summary>
        /// <param name="villain">El <see cref="AbstractVillain"/> a atacar.</param>
        /// <exception cref="CannotAttackDeadException">Arrojada cuando cualquiera de los dos personajes se encuentra sin vida.</exception>
        public void Attack(AbstractVillain villain)
        {
            if(!this.IsAlive() || !villain.IsAlive()) 
                throw new CannotAttackDeadException("Uno de los dos caracteres que iba a ser atacado estaba muerto.");
            villain.Hp = Math.Max(0, villain.Hp - Math.Max(0, this.Damage - new Random().Next(villain.Defense)));
            
            if (!villain.IsAlive())
            {
                TorreDeLosCaidos.Instance.Notify(this, villain);
            }
        }

        public virtual void Update(AbstractCharacter killer, AbstractCharacter killed)
        {
            if (killer.Equals(this))
            {
                PiedraEterna += 1;
            }
        }
    }
}