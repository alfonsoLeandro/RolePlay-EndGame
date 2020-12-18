namespace Library.Items.CommonItems.Potions
{
    public class CuringPotion : NonMagicItem
    {
        public CuringPotion(int healthValue) : base(0, 0, healthValue)
        {
        }

        public override string ToString()
        {
            return "Curing potion";
        }
    }
}