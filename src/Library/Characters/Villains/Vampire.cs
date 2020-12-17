using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Villains
{
    public class Vampire : AbstractVillain
    {
        public Vampire(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }

        public override string ToString()
        {
            return "Vampire";
        }
    }
}