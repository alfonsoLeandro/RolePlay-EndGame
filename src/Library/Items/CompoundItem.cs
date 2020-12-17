
namespace Library.Items
{
    public class CompoundItem : AbstractItem
    {
        private readonly string itemName;
        
        public CompoundItem(AbstractItem item1, AbstractItem item2, string itemName) : 
            this(item1.IsMagic || item2.IsMagic,
                item1.DefenseValue + item2.DefenseValue, 
                item1.DamageValue + item2.DamageValue, 
                item1.HealthValue + item2.HealthValue, 
                itemName)
        {
        }   
        
        public CompoundItem(bool isMagic, int defenseValue, int damageValue, int healthValue, string itemName) : 
            base(true,
                isMagic,
                defenseValue, 
                damageValue, 
                healthValue)
        {
            this.itemName = itemName;
        }

        public override string ToString()
        {
            return itemName;
        }
    }
}