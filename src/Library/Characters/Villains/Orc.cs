using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Villains
{
    public class Orc : AbstractVillain
    {
        public Orc(int hp, int damage, int defense) : base(hp, damage, defense)
        {
        }
        
        public Orc(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }
        
        public override string ToString()
        {
            return "Orc";
        }
    }
}