namespace Library.Items.Common_items.Potions
{
    public class StrengthPotion : AbstractItem
    {
        public StrengthPotion(int damageValue) : base(false, false, 0, 10, 0)
        {
        }

        public override string ToString()
        {
            return "Strength potion";
        }
    }
}