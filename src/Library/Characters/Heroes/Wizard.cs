using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Heroes
{
    public class Wizard : AbstractHero
    {
        public static Dictionary<string,string> LibroDeLaSabiduria { get; } = new Dictionary<string, string>();
        
        public Wizard(int hp, int damage, int defense) : this(hp, damage, defense, new List<AbstractItem>())
        {
        }
        
        public Wizard(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }
        
        
        public override string ToString()
        {
            return "Wizard";
        }

        public override void Update(AbstractCharacter killer, AbstractCharacter killed)
        {
            base.Update(killer, killed);
            LibroDeLaSabiduria.Add(killer.ToString(), killed.ToString());
        }
    }
}