namespace Library.Items.CommonItems.Potions
{
    public class StrengthPotion : NonMagicItem
    {
        public StrengthPotion(int damageValue) : base(0, damageValue, 0)
        {
        }

        public override string ToString()
        {
            return "Strength potion";
        }
    }
}