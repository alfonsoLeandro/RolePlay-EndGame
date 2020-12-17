namespace Library.Items.Common_items
{
    public class Sword : AbstractItem
    {
        public Sword(int damageValue) : base(false, false, 0, damageValue, 0)
        {
        }

        public override string ToString()
        {
            return "Sword";
        }
    }
}