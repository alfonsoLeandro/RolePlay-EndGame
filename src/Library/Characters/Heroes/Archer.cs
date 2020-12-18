using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Heroes
{
    public class Archer : AbstractHero
    {
        public Archer(int hp, int damage, int defense) : base(hp, damage, defense)
        {
        }
        
        public Archer(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }

        public override string ToString()
        {
            return "Legolas, the archer";
        }
    }
}