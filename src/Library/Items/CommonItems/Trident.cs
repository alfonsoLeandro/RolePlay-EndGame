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
        
          
        //Combinations: trident+shield, trident+sharp shield

        
        public CompoundNonMagicItem Combine(Shield shield)
        {
            return new CompoundNonMagicItem(this, shield,
                "Trident and shield");
        }    
        
        public CompoundNonMagicItem Combine(SharpShield shield)
        {
            return new CompoundNonMagicItem(this, shield,
                "Trident and sharp shield");
        }
    }
}