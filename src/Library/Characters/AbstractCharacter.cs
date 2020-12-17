using System.Collections.Generic;
using Library.Characters.Heroes;
using Library.Exceptions;
using Library.Items;

namespace Library.Characters
{
    public abstract class AbstractCharacter
    {
        public int Hp { get; set; }
        private int[] DefaultStats { get; set; } = new int[3];
        public int Damage { get; private set; }
        public int Defense { get; private set; }
        public int Vp { get; set; }
        public List<AbstractItem> Items { get; }

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
            this.Cure(DefaultStats[0]);
        }
        
        public void Cure(int amount)
        {
            this.Hp += amount;
        }     


        public void AddItems(List<AbstractItem> items)
        {
            //Guardo el bool que verifica si este item es un wizard
            //para no tener que verificarlo en cada repeticion del for.
            //Rompo con patrón polimorfismo ya que el wizard es el único que puede obtener items de timpo mágico
            var wizard = GetType() == typeof(Wizard);
            foreach (var item in items)
            {
                if (wizard || !item.IsMagic)
                {
                    Items.Add(item);
                }
            }
            UpdateStats();
        }

        public void AddItem(AbstractItem abstractItem)
        {
            //Rompo con patrón polimorfismo ya que el wizard es el único que puede obtener items de timpo mágico
            if (GetType() != typeof(Wizard) && abstractItem.IsMagic) 
                throw new CannotAddItemException(
                    "No puedes agregar un item mágico a un personaje que no sea un Wizard");
            
            Items.Add(abstractItem);
            UpdateStats();
        }

        private void UpdateStats()
        {
            this.Hp = this.DefaultStats[0];
            this.Damage = this.DefaultStats[1];
            this.Defense = this.DefaultStats[2];
            foreach (var item in this.Items)
            {
                if (item.IsMagic && GetType() != typeof(Wizard)) continue;
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

        public void AddVp(int vp)
        {
            //TODO
        }

        public abstract override string ToString();


    }
}