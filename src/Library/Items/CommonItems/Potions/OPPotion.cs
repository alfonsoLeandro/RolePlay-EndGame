﻿namespace Library.Items.Common_items.Potions
{
    public class OPPotion : AbstractItem
    {
        public OPPotion(int defenseValue, int damageValue, int healthValue) : base(false, false, defenseValue, damageValue, healthValue)
        {
        }

        public override string ToString()
        {
            return "OP Potion";
        }
    }
}