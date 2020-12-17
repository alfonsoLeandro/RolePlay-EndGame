using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Villains
{
    public class Cerberus : AbstractVillain
    {
        public Cerberus(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }

        public override string ToString()
        {
            return "Cerberus, the three headed beast";
        }
    }
}