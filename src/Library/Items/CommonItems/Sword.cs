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
        
        //Combinations: sword+sword, sword+shield, sword+sharp shield

        public CompoundNonMagicItem Combine(Sword sword)
        {
            return new CompoundNonMagicItem(
                0,
                this.DamageValue+sword.DamageValue,
                0,
                "Crossed swords");
        }    
        
        public CompoundNonMagicItem Combine(Shield shield)
        {
            return new CompoundNonMagicItem(
                shield.DefenseValue,
                this.DamageValue,
                0,
                "Sword and shield");
        }    
        
        public CompoundNonMagicItem Combine(SharpShield shield)
        {
            return new CompoundNonMagicItem(
                shield.DefenseValue,
                this.DamageValue+shield.DamageValue,
                0,
                "Sword and sharp shield");
        }
    }
}