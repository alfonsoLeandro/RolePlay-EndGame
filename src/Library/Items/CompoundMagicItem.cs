namespace Library.Items
{
    public class CompoundMagicItem : MagicItem
    {
        private readonly string itemName;
        
        public CompoundMagicItem(int defenseValue, int damageValue, int healthValue, string itemName) : base(defenseValue, damageValue, healthValue)
        {
            this.itemName = itemName;
        }

        public override string ToString()
        {
            return itemName;
        }
    }
}