using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Heroes
{
    public class Knight : AbstractHero
    {
        public Knight(int hp, int damage, int defense) : base(hp, damage, defense)
        {
        }
        
        public Knight(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }

        public override string ToString()
        {
            return "Almighty Sir Lancelot";
        }
    }
}