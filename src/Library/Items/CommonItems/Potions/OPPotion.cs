namespace Library.Items.CommonItems.Potions
{
    public class OPPotion : NonMagicItem
    {
        public OPPotion(int defenseValue, int damageValue, int healthValue) : base(defenseValue*2, damageValue*2, healthValue*2)
        {
        }

        public override string ToString()
        {
            return "OP Potion";
        }
    }
}