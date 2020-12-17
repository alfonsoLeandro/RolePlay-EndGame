namespace Library.Items.CommonItems
{
    public class Trident : AbstractItem
    {
        public Trident(bool isCompound, bool isMagic, int defenseValue, int damageValue, int healthValue) : base(isCompound, isMagic, defenseValue, damageValue, healthValue)
        {
        }

        public override string ToString()
        {
            return "Trident";
        }
    }
}