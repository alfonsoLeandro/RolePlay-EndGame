using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Villains
{
    public class Satan : AbstractVillain
    {
        public Satan(int hp, int damage, int defense) : base(hp, damage*2, defense)
        {
            RpCore.Instance.Logger.Log("Satan has awaken");
        }
        
        public Satan(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage*2, defense, items)
        {
            RpCore.Instance.Logger.Log("Satan has awaken");
        }

        public override string ToString()
        {
            return "Satan";
        }
    }
}