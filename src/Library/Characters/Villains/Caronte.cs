using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Villains
{
    public class Caronte : AbstractVillain
    {
        public static List<string> AlmasEnPena { get; } = new List<string>();
        public Caronte(int hp, int damage, int defense) : base(hp, damage, defense)
        {
        }
        
        public Caronte(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
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