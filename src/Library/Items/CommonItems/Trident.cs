namespace Library.Items.CommonItems
{
    public class Trident : NonMagicItem
    {
        public Trident(int defenseValue, int damageValue) : base(defenseValue, damageValue, 0)
        {
        }

        public override string ToString()
        {
            return "Trident";
        }
    }
}