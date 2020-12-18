namespace Library.Items
{
    public class CompoundMagicItem : MagicItem
    {
        private readonly string itemName;
        
        public CompoundMagicItem(AbstractItem item1, AbstractItem item2, string itemName) :
            this(item1.DefenseValue+item2.DefenseValue, 
                item1.DamageValue+item2.DamageValue, 
                item1.HealthValue+item2.HealthValue, 
                itemName)
        {
        }
        
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