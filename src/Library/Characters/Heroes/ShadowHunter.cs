using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Heroes
{
    public class ShadowHunter : AbstractHero
    {
        public ShadowHunter(int hp, int damage, int defense) : base(hp, damage, defense)
        {
        }
        
        public ShadowHunter(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }

        public override string ToString()
        {
            return "Brave shadow hunter";
        }
    }
}