using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Heroes
{
    public class Elf : AbstractHero
    {
        public Elf(int hp, int damage, int defense) : base(hp, damage, defense)
        {
        }
        
        public Elf(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }

        public override string ToString()
        {
            return "Trusty elf";
        }
    }
}