using System;
using System.Collections.Generic;
using Library.CampoDeLosCaidos;
using Library.Characters.Heroes;
using Library.Exceptions;
using Library.Items;

namespace Library.Characters.Villains
{
    /// <summary>
    /// Clase abstracta destinada a ser heredada por cada clase que represente a un villano
    /// que no sea mágico.
    /// </summary>
    /// <seealso cref="AbstractMagicVillain"/>
    public abstract class AbstractVillain : AbstractCharacter, IObserver
    {
                
        /// <summary>
        /// Registro de los nombres de cada héroe asesinado por un villano (Honor & Glory).
        /// </summary>
        /// <see cref="TorreDeLosCaidos"/>
        public static List<string> ArbolDeLosMilDias { get; } = new List<string>();

        /// <summary>
        /// Crea un nuevo villano sin items por defecto (los mismos pueden ser agregados con posterioridad)
        /// y subscribe el mismo a la lista de observadores de la <see cref="TorreDeLosCaidos"/>.
        /// En este constructor se aplica el patrón creator, ya que muchas veces buscamos crear un personaje sin
        /// items, y para eso debemos pasar como parámetro una nueva lista de items, de ésto se encarga este constructor.
        /// </summary>
        /// <param name="hp">Los puntos de salud base de este villano.</param>
        /// <param name="damage">El daño base de este villano.</param>
        /// <param name="defense">La defensa base de este villano.</param>
        public AbstractVillain(int hp, int damage, int defense) : this(hp, damage, defense, new List<AbstractItem>())
        {
        }
        
        /// <summary>
        /// Crea un nuevo villano y subscribe el mismo a la lista de observadores de la <see cref="TorreDeLosCaidos"/>.
        /// </summary>
        /// <param name="hp">Los puntos de salud base de este villano.</param>
        /// <param name="damage">El daño base de este villano.</param>
        /// <param name="defense">La defensa base de este villano.</param>
        /// <param name="items">Una lista de items para agregar a este villano.</param>
        /// <seealso cref="AbstractItem"/>
        public AbstractVillain(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
            TorreDeLosCaidos.Instance.Subscribe(this);
        }
        
        /// <summary>
        /// Ejecuta un ataque hacia un héroe.
        /// Aquí entran en juego los puntos de salud del héroe, el ataque del villano y los puntos de
        /// defensa del héroe. Estos últimos pueden ser nada o muy efectivos, se genera un número random
        /// desde 0 hasta el valor de la defensa del héroe, el número resultante se le resta al ataque del villano
        /// y el valor resultante se le resta a los puntos de salud del héroe.
        /// </summary>
        /// <param name="hero">El <see cref="AbstractHero"/> a atacar.</param>
        /// <exception cref="CannotAttackDeadException">Arrojada cuando cualquiera de los dos personajes se encuentra sin vida.</exception>
        public void Attack(AbstractHero hero)
        {
            if (!this.IsAlive() || !hero.IsAlive())
                throw new CannotAttackDeadException("Uno de los dos caracteres que iba a ser atacado estaba muerto.");
            hero.Hp = Math.Max(0, hero.Hp - Math.Max(0, this.Damage - new Random().Next(hero.Defense)));

            if (!hero.IsAlive())
            {
                TorreDeLosCaidos.Instance.Notify(this, hero);
            }
        }

        public virtual void Update(AbstractCharacter killer, AbstractCharacter killed)
        {
            if (killer.Equals(this))
            {
                ArbolDeLosMilDias.Add(killed.ToString());
            }
        }
    }
}