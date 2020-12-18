using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Heroes
{
    public class Angel : AbstractHero
    {
        public List<string> PerdonadosPorDios { get; }
        public Angel(int hp, int damage, int defense) : this(hp, damage, defense, new List<AbstractItem>())
        {
        }

        public Angel(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
            PerdonadosPorDios = new List<string>();
        }


        public override string ToString()
        {
            return "Holy angel";
        }

        public override void Update(AbstractCharacter killer, AbstractCharacter killed)
        {
            base.Update(killer, killed);
            if (killed is AbstractHero)
            {
                PerdonadosPorDios.Add(killed.ToString());
            }
        }
    }
}