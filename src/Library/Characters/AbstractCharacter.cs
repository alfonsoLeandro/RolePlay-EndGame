using System;
using System.Collections.Generic;
using Library.CampoDeLosCaidos;
using Library.Characters.Heroes;
using Library.Characters.Villains;
using Library.Encounters;
using Library.Exceptions;
using Library.Items;
using Library.Items.ExceptionalItems;

namespace Library.Characters
{
    /// <summary>
    /// Clase abstracta destinada a ser heredada por cada otras clases abstractas que representen
    /// héroes o villanos.
    /// </summary>
    /// <seealso cref="AbstractHero"/>
    /// <seealso cref="AbstractVillain"/>
    public abstract class AbstractCharacter
    {
        /// <summary>
        /// Puntos de salud de este personaje.
        /// </summary>
        public int Hp { get; set; }
        /// <summary>
        /// Estadísticas por defecto de este personaje.
        /// Éstas son determinadas en el constructor.
        /// </summary>
        private int[] DefaultStats { get; } = new int[3];
        /// <summary>
        /// Puntos de ataque de este personaje.
        /// </summary>
        public int Damage { get; private set; }
        /// <summary>
        /// Puntos de defensa de este personaje.
        /// </summary>
        public int Defense { get; private set; }
        /// <summary>
        /// Puntos de VP de este personaje.
        /// Éstos son agregados en combate y al obtener 5, el personaje se cura.
        /// </summary>
        public int Vp { get; set; }
        /// <summary>
        /// Lista de items de este personaje.
        /// </summary>
        public List<AbstractItem> Items { get; }
        /// <summary>
        /// ID única de este personaje, para ser utilizada en registros de Honor & Glory.
        /// </summary>
        public int Id {get;} = new Random().Next(9999);

        /// <summary>
        /// Constructor necesario para cada personaje. Establece e inicializa las estadísticas.
        /// </summary>
        /// <param name="hp">Los puntos de salud del personaje.</param>
        /// <param name="damage">Los puntos de ataque del personaje.</param>
        /// <param name="defense">Los puntos de defensa del personaje.</param>
        /// <param name="items">Los items a agregar al personaje.</param>
        protected AbstractCharacter(int hp, int damage, int defense, List<AbstractItem> items)
        {
            this.Hp = hp;
            this.Damage = damage;
            this.Defense = defense;
            this.DefaultStats[0] = hp;
            this.DefaultStats[1] = damage;
            this.DefaultStats[2] = defense;
            this.Vp = 0;
            this.Items = new List<AbstractItem>();
            AddItems(items);
        }
        
        /// <summary>
        /// Cura al personaje estableciendo su salud al mismo valor que fue indicado al crear el personaje.
        /// </summary>
        public void Cure()
        {
            this.Hp = DefaultStats[0];
        }
        
        /// <summary>
        /// Cura al personaje, añadiendo a sus puntos de salud el valor indicado.
        /// </summary>
        /// <param name="amount">Los puntos de salud a agregar.</param>
        public void Cure(int amount)
        {
            this.Hp += amount;
        }     


        /// <summary>
        /// Añade al personaje una lista de items y luego llama a UpdateStats() para actualizar
        /// sus estadísticas.
        /// </summary>
        /// <param name="items">La lista de items a agregar al personaje.</param>
        public void AddItems(List<AbstractItem> items)
        {
            //Guardo el bool que verifica si este personaje es mágico
            //para no tener que verificarlo en cada repetición del for.
            //Rompo con patrón polimorfismo ya que los personajes mágicos son
            //los únicos que pueden obtener items de tipo mágico
            var isMagic = this is AbstractMagicHero || this is AbstractMagicVillain;
            foreach (var item in items)
            {
                if (isMagic || !(item is MagicItem))
                {
                    Items.Add(item);
                }
            }
            UpdateStats();
        }

        /// <summary>
        /// Añade al personaje un item y luego llama a UpdateStats() para actualizar
        /// sus estadísticas.
        /// </summary>
        /// <param name="item">El item a agregar al personaje.</param>
        public void AddItem(AbstractItem item)
        {
            //Rompo con patrón polimorfismo ya que los personajes mágicos son los únicos que pueden
            //obtener items de timpo mágico
            if ((!(this is AbstractMagicHero) && !(this is AbstractMagicVillain)) && (item is MagicItem)) 
                throw new CannotAddItemException(
                    "No puedes agregar un item mágico a un personaje que no sea mágico");
            
            Items.Add(item);
            UpdateStats();
        }

        /// <summary>
        /// Actualiza las estadísticas del personaje de acuerdo a los items que este posee.
        /// </summary>
        protected void UpdateStats()
        {
            this.Hp = this.DefaultStats[0];
            this.Damage = this.DefaultStats[1];
            this.Defense = this.DefaultStats[2];
            foreach (var item in this.Items)
            {
                //Rompo nuevamente con polimorfismo para poder agregar la función especial
                //de la DarkSword con las ElementalGem
                if (item is ElementalGem)
                {
                    foreach (var item2 in Items)
                    {
                        if (item2 is DarkSword)
                        {
                            Items.Add(((DarkSword) item2).Combine((ElementalGem) item));
                            Items.Remove(item);
                            Items.Remove(item2);
                            UpdateStats();
                            return;
                        }
                    }
                    //Las ElementalGem por si solas no debieran agregar estadísticas directamente
                    //al personaje si no a la DarkSword
                    continue;
                }  
                
                //Rompo nuevamente con polimorfismo para poder agregar la función especial
                //del SpellBook con los Spells
                if (item is Spell)
                {
                    foreach (var item2 in Items)
                    {
                        if (item2 is SpellBook)
                        {
                            Items.Add(((SpellBook) item2).Combine((Spell) item));
                            Items.Remove(item);
                            Items.Remove(item2);
                            UpdateStats();
                            return;
                        }
                    }
                    //Los spells por si solos no debieran agregar estadísticas directamente
                    //al personaje si no al SpellBook
                    continue;
                }

                this.Damage += item.DamageValue;
                this.Defense += item.DefenseValue;
                this.Hp += item.HealthValue;
            }
        }
    

        /// <summary>
        /// Hace que este personaje ceda un item dado a otro personaje dado.
        /// Utilizado en encuentros de intercambio (<see cref="ExchangeEncounter"/>).
        /// </summary>
        /// <param name="character">El personaje a entregar el item.</param>
        /// <param name="item">El item a entregar.</param>
        /// <exception cref="DoesNotContainItemException">Arrojado cuando este personaje no contiene el item dado.</exception>
        public void GiveItem(AbstractCharacter character, AbstractItem item)
        {
            if (!this.Items.Contains(item))
            {
                throw new DoesNotContainItemException($"Este {this.ToString()} no contiene el item que iba a entregar");
            }
            character.AddItem(item);
            this.Items.Remove(item);
            UpdateStats();
        }

        /// <summary>
        /// Verifica que este personaje se encuentre con vida.
        /// </summary>
        /// <returns>true si el valor de los puntos de salud de este personaje es mayor a 0.</returns>
        public bool IsAlive()
        {
            return this.Hp > 0;
        }

        /// <summary>
        /// Remueve un item dado de la lista de items de este personaje.
        /// </summary>
        /// <param name="item">El item a remover.</param>
        /// <exception cref="DoesNotContainItemException">Arrojado si este personaje no contiene el item.</exception>
        public void RemoveItem(AbstractItem item)
        {
            if (!this.Items.Contains(item))
            {
                throw new DoesNotContainItemException($"Este {this.ToString()} no contiene el item que se le iba a remover.");
            }
            this.Items.Remove(item);
            UpdateStats();
        }

        /// <summary>
        /// Obtiene el nombre de este héroe, utilizado en batallas y registros de Honor & Glory (<see cref="TorreDeLosCaidos"/>).
        /// </summary>
        /// <returns>El nombre de este personaje.</returns>
        public abstract override string ToString();
    }
}