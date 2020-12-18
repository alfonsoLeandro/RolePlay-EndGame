using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Villains
{
    public class Caronte : AbstractVillain
    {
        public List<string> AlmasEnPena { get; }
        public Caronte(int hp, int damage, int defense) : this(hp, damage, defense, new List<AbstractItem>())
        {
        }
        
        public Caronte(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
            AlmasEnPena = new List<string>();
        }

        public override string ToString()
        {
            return "Caronte";
        }

        public override void Update(AbstractCharacter killer, AbstractCharacter killed)
        {
            base.Update(killer, killed);
            if (killer.Equals(this))
            {
                AlmasEnPena.Add(killed.ToString());
            }
        }
    }
}