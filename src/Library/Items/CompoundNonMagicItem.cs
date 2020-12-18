namespace Library.Items
{
    public class CompoundNonMagicItem : NonMagicItem
    {
        private readonly string itemName;
        
        public CompoundNonMagicItem(int defenseValue, int damageValue, int healthValue, string itemName) : base(defenseValue, damageValue, healthValue)
        {
            this.itemName = itemName;
        }

        public override string ToString()
        {
            return itemName;
        }
    }
}