using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Heroes
{
    public abstract class AbstractMagicHero : AbstractHero
    {
        protected AbstractMagicHero(int hp, int damage, int defense) : this(hp, damage, defense, new List<AbstractItem>())
        {
        }

        protected AbstractMagicHero(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }
    }
}