namespace Library.Items.CommonItems
{
    public class Shield : NonMagicItem
    {
        public Shield(int defenseValue) : base(defenseValue, 0, 0)
        {
        }

        public override string ToString()
        {
            return "Shield";
        }
        
        //Combinations: shield+sword, shield+trident

        public CompoundNonMagicItem Combine(Sword sword)
        {
            return new CompoundNonMagicItem(this, sword,
                "Shield and sword");
        }    
        
        public CompoundNonMagicItem Combine(Trident trident)
        {
            return new CompoundNonMagicItem(this, trident,
                "Shield and trident");
        }
    }
}