namespace Library.Items.CommonItems
{
    public class SharpShield : AbstractItem
    {
        public SharpShield(bool isCompound, bool isMagic, int defenseValue, int damageValue, int healthValue) : base(isCompound, isMagic, defenseValue, damageValue, healthValue)
        {
        }

        public override string ToString()
        {
            return "Sharp shield";
        }
    }
}