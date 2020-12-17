namespace Library.Items.CommonItems.Potions
{
    public class CuringPotion : AbstractItem
    {
        public CuringPotion(int healthValue) : base(false, false, 0, 0, healthValue)
        {
        }

        public override string ToString()
        {
            return "Curing potion";
        }
    }
}