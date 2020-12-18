using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Villains
{
    public class Werewolf : AbstractVillain
    {
        public Werewolf(int hp, int damage, int defense) : base(hp, damage, defense)
        {
        }
        
        public Werewolf(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }

        public override string ToString()
        {
            return "Werewolf";
        }
    }
}