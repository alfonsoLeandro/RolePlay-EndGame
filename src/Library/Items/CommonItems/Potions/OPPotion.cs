namespace Library.Items.CommonItems.Potions
{
    public class OPPotion : NonMagicItem
    {
        public OPPotion(int defenseValue, int damageValue, int healthValue) : base(defenseValue, damageValue, healthValue)
        {
        }

        public override string ToString()
        {
            return "OP Potion";
        }
    }
}