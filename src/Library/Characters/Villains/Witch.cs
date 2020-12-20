using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Villains
{
    public class Witch : AbstractMagicVillain
    {
        public Witch(int hp, int damage, int defense) : base(hp, damage, defense)
        {
        }
        
        public Witch(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }

        public override string ToString()
        {
            return "Witch";
        }
    }
}