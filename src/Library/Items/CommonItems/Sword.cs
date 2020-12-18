namespace Library.Items.CommonItems
{
    public class Sword : NonMagicItem
    {
        public Sword(int damageValue) : base(0, damageValue, 0)
        {
        }

        public override string ToString()
        {
            return "Sword";
        }
    }
}