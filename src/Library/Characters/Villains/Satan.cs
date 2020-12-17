using System.Collections.Generic;
using Library.Items;

namespace Library.Characters.Villains
{
    public class Satan : AbstractVillain
    {
        public Satan(int hp, int damage, int defense, List<AbstractItem> items) : base(hp*2, damage*2, defense, items)
        {
            RpCore.GetInstance().Logger.Log("Satan has awaken");
        }

        public override string ToString()
        {
            return "Satan";
        }
    }
}