using System.Collections.Generic;
using Library.Characters.Heroes;
using Library.Characters.Villains;
using Library.Exceptions;
using Library.Items;
using Library.Items.ExceptionalItems;

namespace Library.Characters
{
    public abstract class AbstractCharacter
    {
        public int Hp { get; set; }
        private int[] DefaultStats { get; } = new int[3];
        public int Damage { get; private set; }
        public int Defense { get; private set; }
        public int Vp { get; set; }
        public List<AbstractItem> Items { get; }

        protected AbstractCharacter(int hp, int damage, int defense)
            : this(hp, damage, defense, new List<AbstractItem>())
        {
        }
        
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

 
        public void Cure()
        {
            this.Hp = DefaultStats[0];
        }
        
        public void Cure(int amount)
        {
            this.Hp += amount;
        }     


        public void AddItems(List<AbstractItem> items)
        {
            //Guardo el bool que verifica si este item es un wizard
            //para no tener que verificarlo en cada repeticion del for.
            //Rompo con patrón polimorfismo ya que el wizard y el brujo son
            //los únicos que pueden obtener items de timpo mágico
            var wizard = GetType() == typeof(Wizard) || GetType() == typeof(Witch);
            foreach (var item in items)
            {
                if (wizard || !(item is MagicItem))
                {
                    Items.Add(item);
                }
            }
            UpdateStats();
        }

        public void AddItem(AbstractItem item)
        {
            //Rompo con patrón polimorfismo ya que el wizard y el witch son los únicos que pueden
            //obtener items de timpo mágico
            if ((GetType() != typeof(Wizard) && GetType() != typeof(Witch)) && (item is MagicItem)) 
                throw new CannotAddItemException(
                    "No puedes agregar un item mágico a un personaje que no sea un Wizard o un Witch");
            
            Items.Add(item);
            UpdateStats();
        }

        protected void UpdateStats()
        {
            this.Hp = this.DefaultStats[0];
            this.Damage = this.DefaultStats[1];
            this.Defense = this.DefaultStats[2];
            foreach (var item in this.Items)
            {
                //Rompo nuevamente con polimorfismo para poder agregar la funcion especial
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
                    //Las ElementalGem por si solas no deberian agregar estadisticas directamente
                    //al personaje si no a la DarkSword
                    continue;
                }  
                
                //Rompo nuevamente con polimorfismo para poder agregar la funcion especial
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
                    //Los spells por si solos no deberian agregar estadisticas directamente
                    //al personaje si no al SpellBook
                    continue;
                }

                this.Damage += item.DamageValue;
                this.Defense += item.DefenseValue;
                this.Hp += item.HealthValue;
            }
        }
    

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

        public bool IsAlive()
        {
            return this.Hp > 0;
        }

        public void RemoveItem(AbstractItem item)
        {
            if (!this.Items.Contains(item))
            {
                throw new DoesNotContainItemException($"Este {this.ToString()} no contiene el item que se le iba a remover.");
            }
            this.Items.Remove(item);
            UpdateStats();
        }


        public abstract override string ToString();
    }
}