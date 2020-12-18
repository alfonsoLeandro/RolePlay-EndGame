namespace Library.Items
{
    public abstract class NonMagicItem : AbstractItem
    {
        public NonMagicItem(int defenseValue, int damageValue, int healthValue) : base(defenseValue, damageValue, healthValue)
        {
        }
    }
}