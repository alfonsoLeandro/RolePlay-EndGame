namespace Library.Items.CommonItems
{
    public class SharpShield : NonMagicItem
    {
        public SharpShield(int defenseValue, int damageValue) : base(defenseValue, damageValue, 0)
        {
        }

        public override string ToString()
        {
            return "Sharp shield";
        }
        
        //Combinations: shield+sword, shield+trident

        public CompoundNonMagicItem Combine(Sword sword)
        {
            return new CompoundNonMagicItem(this, sword,
                "Sharp shield and sword");
        }    
        
        public CompoundNonMagicItem Combine(Trident trident)
        {
            return new CompoundNonMagicItem(this, trident,
                "Sharp shield and trident");
        }


    }
}