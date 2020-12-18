namespace Library.Items.ExceptionalItems
{
    public class AscleipoStaff : NonMagicItem
    {
        public AscleipoStaff(int defenseValue, int damageValue, int healthValue) : base(defenseValue, damageValue, healthValue)
        {
        }

        public override string ToString()
        {
            return "Ascleipo staff";
        }
        
        //Combinations: staff+NONMAGIC

        public CompoundNonMagicItem Combine(MagicItem item)
        {
            return new CompoundNonMagicItem(
                this.DefenseValue+item.DefenseValue,
                this.DamageValue+item.DamageValue,
                this.HealthValue+item.HealthValue,
                "Ascleipo staff and "+item.ToString());
        }    
        
    }
}