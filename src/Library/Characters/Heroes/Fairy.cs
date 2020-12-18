using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Heroes
{
    public class Fairy : AbstractHero
    {
        public Fairy(int hp, int damage, int defense) : base(hp, damage, defense*3)
        {
        }
        
        public Fairy(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense*3, items)
        {
        }

        public override string ToString()
        {
            return "Fairy";
        }
    }
}