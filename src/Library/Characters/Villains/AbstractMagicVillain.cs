using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Villains
{
    public abstract class AbstractMagicVillain : AbstractVillain
    {
        protected AbstractMagicVillain(int hp, int damage, int defense) : base(hp, damage, defense)
        {
        }

        protected AbstractMagicVillain(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }
    }
}