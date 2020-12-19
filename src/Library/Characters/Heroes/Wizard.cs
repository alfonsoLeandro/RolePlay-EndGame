using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Heroes
{
    public class Wizard : AbstractMagicHero
    {
        public static Dictionary<string,List<string>> LibroDeLaSabiduria { get; } = new Dictionary<string, List<string>>();
        
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
            string killerName = killer.ToString() + $"({killer.Id})";
            if (LibroDeLaSabiduria.ContainsKey(killerName))
            {
                LibroDeLaSabiduria[killerName].Add(killed.ToString());
            }
            else
            { 
                LibroDeLaSabiduria.Add(killerName, new List<string>(){killed.ToString()});
            }
        }
    }
}