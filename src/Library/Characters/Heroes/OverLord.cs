using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Heroes
{
    public class OverLord : AbstractHero
    {
        public OverLord(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }

        public override string ToString()
        {
            return "Overlord";
        }
    }
}