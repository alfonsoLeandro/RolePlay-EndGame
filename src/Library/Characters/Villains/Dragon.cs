using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Villains
{
    public class Dragon : AbstractVillain
    {
        public Dragon(int hp, int damage, int defense) : base(hp, damage, defense)
        {
        }
        
        public Dragon(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }
        
        public override string ToString()
        {
            return "Dragon";
        }
    }
}